USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_CostReport_NewAcct2_Vision]    Script Date: 04/30/2013 13:24:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_CostReport_NewAcct2_Vision]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_CostReport_NewAcct2_Vision]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_CostReport_NewAcct2_Vision]    Script Date: 04/30/2013 13:24:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spRPRT_CostReport_NewAcct2_Vision]
	@Project	varchar(50),
	@Rprtdate	smalldatetime,
	@ReportCase int
AS

/*
exec spRPRT_CostReport_NewAcct2_Vision @Project='0.120057.00.0',@Rprtdate='2013-04-15 00:00:00',@ReportCase=0
exec spRPRT_CostReport_NewAcct2_Vision @Project='0.120057.00.0',@Rprtdate='2013-04-30 00:00:00',@ReportCase=0

*/
--Clean the data , leading 'E'
UPDATE DT_ForecastToCompletes set AccountGroup = SUBSTRING( AccountGroup ,2 , 4 ) where AccountGroup like 'E%'


SELECT 
	project.Project
	,project_full.Description
	, customer.Name as [Customer]
	, location.[City] + ', ' + state.[Abbrev] AS [Location]
	, groups.code as BudgetGroup
	, ISNULL(groups.DescriptionShort, groups.Description) as AcctGroup
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
LEFT JOIN DT_Projects project_full on project.Project = project_full.Number
LEFT JOIN DT_Customers customer ON project_full.[CustomerID] = customer.[ID]
LEFT JOIN DT_Locations location ON project_full.[LocationID] = location.[ID]
LEFT JOIN SY_States state ON location.[StateID] = state.[ID]
LEFT JOIN DT_Employees employee ON project_full.[ProjMngrID] = employee.[ID]
LEFT JOIN DT_Employees manger ON manger.ID = project_full.ProjMngrID
LEFT JOIN SY_AccountCodeDisciplines groups on groups.Code > 1000
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

	@Project as project
	, tasks.Code  as AcctNumber
	, ISNULL( tasks.DescriptionShort, tasks.Description) as AcctGroup
	, convert( varchar, tasks.Code) + ' ' + tasks.Description as AcctNumberGroup
	, ISNULL( budget.budget, 0) as budget
	, ISNULL( act.[costs], 0) as [costs]
	, ISNULL( forecast.ForecastHrs, 0) as ForecastHrs
	, ISNULL( forecast.ForecastAmnt, 0) as ForecastAmnt
	
FROM SY_AccountCodeTasks tasks


FULL OUTER JOIN (
	SELECT 
		task.[TaskCode]
		, SUM( ISNULL( bud.[BillBud],0 )) as budget
	FROM [Vision].[HGAVisionDatabase].dbo.[EB] bud
		left join CodeMappings map on map.OldCode = SUBSTRING(bud.[Account],6,4)
		left join vwCodeTasks task on ISNULL(map.NewCode,SUBSTRING(bud.[Account],6,4) ) = task.code
	where bud.WBS1 = @Project AND ISNUMERIC(SUBSTRING(bud.[Account],6,4)) = 1
	GROUP BY task.[TaskCode]
) budget on budget.[TaskCode] = tasks.Code


FULL OUTER JOIN (
	SELECT 
		task.[TaskCode]
		, SUM( Amount ) as Amount
		, SUM( BillExt ) as costs
	FROM vwVision_Expenses ex
	left join vwCodeTasks task on task.code = ex.CodeStrc
	where ex.WBS1 = @Project
	GROUP BY task.[TaskCode]
) act on act.[TaskCode] = tasks.Code


LEFT JOIN(

   select 
     f.code
     ,sum( [ForecastHrs] ) as [ForecastHrs]
	 ,sum( [ForecastAmnt] ) as [ForecastAmnt]
   from
   (
    SELECT
        ISNULL( task.TaskCode ,  ftc.[AccountGroup] ) as code
		,[ForecastHrs]
		,[ForecastAmnt]
	FROM DT_ForecastUpdates fu
	JOIN DT_ForecastToCompletes ftc on ftc.ForecastID = fu.ID AND fu.Project = @Project 
		and fu.DateCreated = ( SELECT MAX([DateCreated]) FROM DT_ForecastUpdates WHERE [Project] = @Project )
		and [AccountGroup] < 9999
	left join vwCodeTasks task on ftc.AccountGroup = task.code
	) f
	WHERE [ForecastHrs] is not null or [ForecastAmnt] is not null
	GROUP BY f.code

) forecast on forecast.code = tasks.Code
WHERE budget > 0 OR costs > 0







GO


