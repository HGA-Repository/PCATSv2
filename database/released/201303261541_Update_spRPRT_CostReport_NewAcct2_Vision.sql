USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_CostReport_NewAcct2_Vision]    Script Date: 03/25/2013 14:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_CostReport_NewAcct2_Vision]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_CostReport_NewAcct2_Vision]
GO

USE [RSManpowerSchDb_dev]
GO

/*
spRPRT_CostReport_NewAcct2_Vision @Project='8.110011.00.0',@Rprtdate='2013-03-25 00:00:00',@ReportCase=1
*/



SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_CostReport_NewAcct2_Vision]
	@Project	varchar(50),
	@Rprtdate	smalldatetime,
	@ReportCase int
AS


SELECT 
	project.Project
	,project_full.Description
	, customer.Name as [Customer]
	, location.[City] + ', ' + state.[Abbrev] AS [Location]
	, groups.code as BudgetGroup
	, groups.Description as AcctGroup
	,dbo.funcProjMang2(manger.Name) AS [Manager]
	,project.[billtype] + ' ' + project_full.[POAmount] AS BillType
	, ISNULL(budgets.Budget,0) as [BudgetDlrs]
	, ISNULL(budgets.BudgetHrs,0) as BudgetHrs
	, ISNULL(actuals.TotalHrs,0) as ActualTime
	, ISNULL(actuals.Billed,0) as ActualAmnt
	, ISNULL(js.[BudgetHrs],0) AS [JSBudgetHrs]
	, ISNULL(js.[RemainingHrs],0) AS [RemainingHrs]
	, ISNULL(js.[LastUpdated],'1/1/1900') AS [JSLastUpdated]
	, ISNULL(budgets.[BudgetHrs],0) - ISNULL(js.[RemainingHrs],0) AS [EarnedHrs]
	, ISNULL(mp.[Projected],0) AS [ProjectedHrs]
	, ISNULL(mp.[Forecast],0) AS [ForecastHrs]
	, ISNULL(fc.[ForecastHrs],-9999) AS FTCHrs
	, ISNULL(fc.[ForecastAmnt],-9999) AS FTCAmnt
	, ISNULL(fc.[FCUpdate],GETDATE()) AS FTCUpdate
	

FROM vwVision_Projects project
LEFT JOIN DT_Projects project_full on project.Project like project_full.Number
LEFT JOIN DT_Customers customer ON project_full.[CustomerID] = customer.[ID]
LEFT JOIN DT_Locations location ON project_full.[LocationID] = location.[ID]
LEFT JOIN SY_States state ON location.[StateID] = state.[ID]
LEFT JOIN DT_Employees employee ON project_full.[ProjMngrID] = employee.[ID]
LEFT JOIN DT_Employees manger ON manger.ID = project_full.ProjMngrID
LEFT JOIN SY_AccountCodeDisciplines groups on 1 = 1
--LEFT JOIN (SELECT * FROM SY_AccountCodeDisciplines union SELECT null,null,null,null,null,null,null ) groups on 1 = 1


--Budgeted Info
LEFT JOIN (
	SELECT 
		GroupCode
		, SUM(BudgetHrs) as BudgetHrs
		, SUM(Budget) as Budget
	FROM vwVision_Budgets b
	where b.Project = @Project
	GROUP BY GroupCode
) as budgets on budgets.GroupCode = groups.Code

--Actuals Info
LEFT JOIN (
	SELECT 
		GroupCode  
		, SUM(TotalHrs) as TotalHrs
		, SUM(Billed) as Billed
	FROM [vwVision_Emp_Proj_Time] b
	where b.WBS1 = @Project
	GROUP BY GroupCode
) as actuals on actuals.GroupCode = groups.Code

-- Jobstat information
LEFT JOIN (
	SELECT 
		groups.CodeGroup
		, SUM(d.[BudgetHrs]) AS BudgetHrs
		, SUM(d.[RemainingHrs]) AS RemainingHrs
		, SUM(d.[BudgetHrs] - d.[RemainingHrs]) AS EarnedHrs
		, MAX(d.DateLastModified) as [LastUpdated]
		
	FROM DT_DrawingLogs d 
		JOIN DT_Projects p on p.Number = @Project and d.ProjectID = p.ID and d.Deleted = 0
		LEFT JOIN DT_ActivityCodes ac ON d.[ActCodeID] = ac.[ID]
		LEFT JOIN [dbo].[vwCodeGroups] groups on ac.Code = groups.code
	GROUP BY groups.CodeGroup
) js on js.CodeGroup = groups.Code


-- manpower data
LEFT JOIN (
	SELECT 
		d.[AcctGroup]
		,SUM(sh.[PHrs]) AS Projected
		,SUM(sh.[FHrs]) AS Forecast
	 FROM DT_ScheduleHours sh
	JOIN DT_Projects p on p.ID = sh.ProjectID and sh.Deleted = 0 and p.Number = @Project
	JOIN SY_WeekLists w ON sh.[WeekID] = w.[ID] and w.EndOfWeek >= @Rprtdate
	LEFT JOIN DT_Departments d ON sh.[DepartmentID] = d.[ID]
	LEFT JOIN [dbo].[vwCodeGroups] groups on d.AcctGroup = groups.code
	GROUP BY [AcctGroup]
) mp on mp.[AcctGroup] = groups.Code

--FC
LEFT JOIN (
	SELECT 
		ftc.[AccountGroup]
		,ftc.[ForecastHrs]
		,ftc.[ForecastAmnt]
		,fu.[DateLastModified] AS FCUpdate
	FROM DT_ForecastUpdates fu
	LEFT JOIN DT_ForecastToCompletes ftc ON fu.[ID] = ftc.[ForecastID]
	LEFT JOIN [vwCodeGroups] groups on groups.code = ftc.AccountGroup
	where fu.Project = @Project and fu.DateCreated = ( SELECT MAX([DateCreated]) FROM DT_ForecastUpdates WHERE [Project] = @Project)
) fc on fc.[AccountGroup] = groups.Code


where 
	project.Project = @Project
	AND ISNULL(budgets.Budget,0) + ISNULL(budgets.BudgetHrs,0) + ISNULL(actuals.TotalHrs,0)	+ ISNULL(actuals.Billed,0) + ISNULL(js.[BudgetHrs],0) + ISNULL(js.[RemainingHrs],0)	+ ISNULL(mp.[Projected],0) > 0

	 
	 
	 



SELECT
	proj.[project]
	,ag2.[AcctNumber]
	,ag2.[AcctGroup]
	,ag2.[AcctNumber] + ' ' + ag2.[AcctGroup] AS AcctNumberGroup
	,ISNULL(bud.[budget],0) AS budget
	,ISNULL(act.[costs],0) AS costs
	,ISNULL(fc.[ForecastHrs],-9999) AS ForecastHrs
	,ISNULL(fc.[ForecastAmnt],-9999) AS ForecastAmnt
--	*
FROM
	vwVision_Projects proj
	CROSS JOIN
	(
	SELECT
		*
	FROM
		SY_AccountGroups2 ag2
	WHERE
		[DepartmentID] < 0
		AND
		[ReportGroup] = 1
		AND [SpecialGroup] = @ReportCase
	) ag2
	LEFT JOIN
	(
	SELECT
		bud.[WBS1]
		,ag2.[AcctNumber]
		,SUM(bud.[BillBud]) AS budget
	FROM
		[Vision].[HGAVisionDatabase].dbo.[EB] bud
		LEFT JOIN
		SY_AccountGroups2 ag2 ON ag2.[StartNew] <= SUBSTRING(bud.[Account],6,4) AND ag2.[EndNew] >= SUBSTRING(bud.[Account],6,4)
	WHERE
		ISNUMERIC(SUBSTRING(bud.[Account],6,4)) = 1
		AND
		ag2.[DepartmentID] < 0
		AND
		ag2.[ReportGroup] = 1
		AND [SpecialGroup] = @ReportCase
	GROUP BY
		bud.[WBS1], ag2.[AcctNumber]
	) bud ON proj.[Project] = bud.[WBS1] AND ag2.[AcctNumber] = bud.[AcctNumber]
	LEFT JOIN
	(
	SELECT
		ex.[WBS1]
		,ag2.[AcctNumber]
		,SUM(ex.[BillExt]) AS costs
	FROM
		vwVision_Expenses ex
		LEFT JOIN
		SY_AccountGroups2 ag2 ON ag2.[StartNew] <= ex.[CodeStrc] AND ag2.[EndNew] >= ex.[CodeStrc]
	WHERE
		ag2.[DepartmentID] < 0
		AND
		ag2.[ReportGroup] = 1
		AND [SpecialGroup] = @ReportCase
	GROUP BY
		ex.[WBS1], ag2.[AcctNumber]
	) act ON proj.[Project] = act.[WBS1] AND ag2.[AcctNumber] = act.[AcctNumber]
	LEFT JOIN
	(
	SELECT
		fu.[Project]
		,ag.[AcctNumber] AS AccountGroup
		--,SUM(ISNULL(ftc.[ForecastHrs],-9999)) AS ForecastHrs
		--,SUM(ISNULL(ftc.[ForecastAmnt],-9999)) AS ForecastAmnt
		,[ForecastHrs] = CASE
							WHEN SUM(ISNULL(ftc.[ForecastHrs], 0)) > 0 THEN SUM(ISNULL(ftc.[ForecastHrs], 0))
							ELSE SUM(ISNULL(ftc.[ForecastHrs],-9999))
							END
		,[ForecastAmnt] = CASE
							WHEN SUM(ISNULL(ftc.[ForecastAmnt], 0)) > 0 THEN SUM(ISNULL(ftc.[ForecastAmnt], 0))
							ELSE SUM(ISNULL(ftc.[ForecastAmnt],-9999))
							END
	FROM
		(
		SELECT
			*
		FROM
			SY_AccountGroups2
		WHERE
			[DepartmentID] < 0
			AND
			[ReportGroup] = 1
			AND [SpecialGroup] = @ReportCase
		) ag
		LEFT JOIN
		DT_ForecastToCompletes ftc ON ag.[StartNew] <= ftc.[AccountGroup] AND ag.[EndNew] >= ftc.[AccountGroup]
		LEFT JOIN
		DT_ForecastUpdates fu ON ftc.[ForecastID] = fu.[ID]
	WHERE
		fu.[Project] = @Project
		AND
		fu.[DateCreated] =
							(
							SELECT
								MAX([DateCreated])
							FROM
								DT_ForecastUpdates
							WHERE
								[Project] = @Project
							)
	GROUP BY
		fu.[Project], ag.[AcctNumber]
	) fc ON proj.[project] = fc.[Project] AND ag2.[AcctNumber] = fc.[AccountGroup]
WHERE
	proj.[project] = @Project
ORDER BY
	ag2.[AcctNumber] ASC

GO


