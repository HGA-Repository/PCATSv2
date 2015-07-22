USE [RSManpowerSchDbBeta2]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_CostReport_NewAcct2_Vision]    Script Date: 7/22/2015 1:24:01 PM ******/
DROP PROCEDURE [dbo].[spRPRT_CostReport_NewAcct2_Vision]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_CostReport_NewAcct2_Vision]    Script Date: 7/22/2015 1:24:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spRPRT_CostReport_NewAcct2_Vision]
	@Project	varchar(50),
	@Rprtdate	smalldatetime,
	@ReportCase int,
	@records int output
AS


--Clean the data , leading 'E'
UPDATE DT_ForecastToCompletes set AccountGroup = SUBSTRING( AccountGroup ,2 , 4 ) where AccountGroup like 'E%'

set @records = (select count(project.Project)

FROM vwVision_Projects project
LEFT JOIN DT_Projects project_full on project.Project = project_full.Number and project_full.Deleted = 0
LEFT JOIN DT_Customers customer ON project_full.[CustomerID] = customer.[ID]
LEFT JOIN DT_Locations location ON project_full.[LocationID] = location.[ID]
LEFT JOIN SY_States state ON location.[StateID] = state.[ID]
LEFT JOIN DT_Employees employee ON project_full.[ProjMngrID] = employee.[ID]
LEFT JOIN DT_Employees lemployee ON project_full.[LeadProjMngrID] = lemployee.[ID]
LEFT JOIN SY_AccountCodeDisciplines groups on groups.Code > 1000



--Budgeted Info
full outer JOIN (
	SELECT 
		GroupCode
		, SUM(BudgetHrs) as BudgetHrs
		, SUM(Budget) as Budget
	FROM vwVision_Budgets b
	where b.Project = @Project
	
	--and ISNULL(BudgetHrs,0) > 0 and ISNULL(Budget,0) > 0
	--and BudgetHrs > 0 and Budget > 0

	GROUP BY GroupCode
) as budgets on budgets.GroupCode = groups.Code

--Actuals Info
full outer JOIN (
	SELECT 
		GroupCode  
		, SUM(TotalHrs) as TotalHrs
		, SUM(Billed) as Billed
	FROM [vwVision_Emp_Proj_Time] b
	where b.WBS1 = @Project

	--and ISNULL(Billed,0) > 0 and ISNULL(TotalHrs,0) > 0
	--and Billed > 0 and TotalHrs > 0

	GROUP BY GroupCode
) as actuals on actuals.GroupCode = groups.Code

-- Jobstat information
full outer JOIN (
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
		
		--where ISNULL(d.[RemainingHrs],0) > 0 and ISNULL(d.[BudgetHrs],0) > 0
		--d.[RemainingHrs] > 0 and d.[BudgetHrs] > 0
	GROUP BY groups.CodeGroup
) js on js.CodeGroup = groups.Code


-- manpower data
full outer JOIN (
	SELECT 
		d.[AcctGroup]
		,SUM(sh.[PHrs]) AS Projected
		,SUM(sh.[FHrs]) AS Forecast
	 FROM DT_ScheduleHours sh
	JOIN DT_Projects p on p.ID = sh.ProjectID and sh.Deleted = 0 and p.Number = @Project
	JOIN SY_WeekLists w ON sh.[WeekID] = w.[ID] and w.EndOfWeek >= @Rprtdate
	LEFT JOIN DT_Departments d ON sh.[DepartmentID] = d.[ID]
	LEFT JOIN [dbo].[vwCodeGroups] groups on d.AcctGroup = groups.code
	--where ISNULL(sh.PHrs,0) > 0
	--sh.PHrs > 0
	GROUP BY [AcctGroup]
) mp on mp.[AcctGroup] = groups.Code

--FC
full outer JOIN (
	
	SELECT 
		ftc.[AccountGroup]
		,max( ftc.[ForecastHrs] ) as [ForecastHrs]
		,max( ftc.[ForecastAmnt] ) as [ForecastAmnt]
		,fu.[DateLastModified] AS FCUpdate
	FROM DT_ForecastUpdates fu
	LEFT JOIN DT_ForecastToCompletes ftc ON fu.[ID] = ftc.[ForecastID]
	LEFT JOIN [vwCodeGroups] groups on groups.code = ftc.AccountGroup
	where fu.Project = @Project
		and fu.DateCreated = ( SELECT MAX([DateCreated]) FROM DT_ForecastUpdates WHERE [Project] = @Project)
		AND fu.Deleted = 0 and AccountGroup is not null
		--and ISNULL(ftc.[ForecastAmnt],0) > 0 and ISNULL(ftc.[ForecastHrs],0) > 0
		--and ftc.[ForecastAmnt] > 0 and ForecastHrs > 0
	GROUP BY AccountGroup, fu.DateLastModified
	
) fc on fc.[AccountGroup] = groups.Code


where 
	project.Project = @Project
	AND ISNULL(budgets.Budget,0) + ISNULL(budgets.BudgetHrs,0) + ISNULL(actuals.TotalHrs,0) 
		+ ISNULL(actuals.Billed,0) + ISNULL(js.[BudgetHrs],0) + ISNULL(js.[RemainingHrs],0) 
		+ ISNULL(fc.[ForecastHrs],0) + ISNULL(fc.[ForecastAmnt],0) + ISNULL(mp.[Projected],0) > 0)
--**************************************************************************************************

if @records = 0


begin
SELECT top 1
	project.Project
	,project_full.Description
	, customer.Name as [Customer]
	, location.[City] + ', ' + state.[Abbrev] AS [Location]
	, groups.code as BudgetGroup
	, ISNULL(groups.DescriptionShort, groups.Description) as AcctGroup
	--,dbo.funcProjMang2(manger.Name) AS [Manager]
	,Case 
		When employee.Name <> lemployee.name Then dbo.funcProjMang2(employee.Name) + '/' + dbo.funcProjMang2(lemployee.Name)
		Else dbo.funcProjMang2(employee.Name)
	 End  AS [Manager]
	--,dbo.funcProjMang2(employee.Name) + '/' + dbo.funcProjMang2(lemployee.Name) AS [Manager]
	,project.[billtype] + ' ' + project_full.[POAmount] AS BillType

FROM vwVision_Projects project
LEFT JOIN DT_Projects project_full on project.Project = project_full.Number and project_full.Deleted = 0
LEFT JOIN DT_Customers customer ON project_full.[CustomerID] = customer.[ID]
LEFT JOIN DT_Locations location ON project_full.[LocationID] = location.[ID]
LEFT JOIN SY_States state ON location.[StateID] = state.[ID]
LEFT JOIN DT_Employees employee ON project_full.[ProjMngrID] = employee.[ID]
LEFT JOIN DT_Employees lemployee ON project_full.[LeadProjMngrID] = lemployee.[ID]
LEFT JOIN SY_AccountCodeDisciplines groups on groups.Code > 1000

where 
	project.Project = @Project

end
--**************************************************************************************************
else
begin
--**************************************************************************************************

SELECT 
	project.Project
	,project_full.Description
	, customer.Name as [Customer]
	, location.[City] + ', ' + state.[Abbrev] AS [Location]
	, groups.code as BudgetGroup
	, ISNULL(groups.DescriptionShort, groups.Description) as AcctGroup
	--,dbo.funcProjMang2(manger.Name) AS [Manager]
	,Case 
		When employee.Name <> lemployee.name Then dbo.funcProjMang2(employee.Name) + '/' + dbo.funcProjMang2(lemployee.Name)
		Else dbo.funcProjMang2(employee.Name)
	 End  AS [Manager]
	--,dbo.funcProjMang2(employee.Name) + '/' + dbo.funcProjMang2(lemployee.Name) AS [Manager]
	,project.[billtype] + ' ' + project_full.[POAmount] AS BillType
	, Case
		When Left (project.project, 3) = '2.D' 		
		Then ISNULL(budgets.Budget,0) / 3.67
		Else ISNULL(budgets.Budget,0)
	End as [BudgetDlrs]
	, ISNULL(budgets.BudgetHrs,0) as BudgetHrs
	, ISNULL(actuals.TotalHrs,0) as ActualTime
	--, ISNULL(actuals.Billed,0) as ActualAmnt
	, Case 
	When Left (project.project, 3) = '2.D' 
	Then ISNULL(actuals.Billed,0) / 3.67 
	Else ISNULL(actuals.Billed,0)
	End as ActualAmnt
	, ISNULL(js.[BudgetHrs],0) AS [JSBudgetHrs]
	, ISNULL(js.[RemainingHrs],0) AS [RemainingHrs]
	, Case
		When groups.code = '11000' Then ' '
		Else ISNULL(js.[LastUpdated],'1/1/1900')
		End AS [JSLastUpdated]
	, ISNULL(budgets.[BudgetHrs],0) - ISNULL(js.[RemainingHrs],0) AS [EarnedHrs]
	, ISNULL(mp.[Projected],0) AS [ProjectedHrs]
	, ISNULL(mp.[Forecast],0) AS [ForecastHrs]
	, ISNULL(fc.[ForecastHrs],-9999) AS FTCHrs
	, ISNULL(fc.[ForecastAmnt],-9999) AS FTCAmnt
	, ISNULL(fc.[FCUpdate],GETDATE()) AS FTCUpdate
	

FROM vwVision_Projects project
LEFT JOIN DT_Projects project_full on project.Project = project_full.Number and project_full.Deleted = 0
LEFT JOIN DT_Customers customer ON project_full.[CustomerID] = customer.[ID]
LEFT JOIN DT_Locations location ON project_full.[LocationID] = location.[ID]
LEFT JOIN SY_States state ON location.[StateID] = state.[ID]
LEFT JOIN DT_Employees employee ON project_full.[ProjMngrID] = employee.[ID]
LEFT JOIN DT_Employees lemployee ON project_full.[LeadProjMngrID] = lemployee.[ID]
LEFT JOIN SY_AccountCodeDisciplines groups on groups.Code > 1000



--Budgeted Info
full outer JOIN (
	SELECT 
		GroupCode
		, SUM(BudgetHrs) as BudgetHrs
		, SUM(Budget) as Budget
	FROM vwVision_Budgets b
	where b.Project = @Project
	
	--and ISNULL(BudgetHrs,0) > 0 and ISNULL(Budget,0) > 0
	--and BudgetHrs > 0 and Budget > 0

	GROUP BY GroupCode
) as budgets on budgets.GroupCode = groups.Code

--Actuals Info
full outer JOIN (
	SELECT 
		GroupCode  
		, SUM(TotalHrs) as TotalHrs
		, SUM(Billed) as Billed
	FROM [vwVision_Emp_Proj_Time] b
	where b.WBS1 = @Project

	--and ISNULL(Billed,0) > 0 and ISNULL(TotalHrs,0) > 0
	--and Billed > 0 and TotalHrs > 0

	GROUP BY GroupCode
) as actuals on actuals.GroupCode = groups.Code

-- Jobstat information
full outer JOIN (
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
		
		--where ISNULL(d.[RemainingHrs],0) > 0 and ISNULL(d.[BudgetHrs],0) > 0
		--d.[RemainingHrs] > 0 and d.[BudgetHrs] > 0
	GROUP BY groups.CodeGroup
) js on js.CodeGroup = groups.Code


-- manpower data
full outer JOIN (
	SELECT 
		d.[AcctGroup]
		,SUM(sh.[PHrs]) AS Projected
		,SUM(sh.[FHrs]) AS Forecast
	 FROM DT_ScheduleHours sh
	JOIN DT_Projects p on p.ID = sh.ProjectID and sh.Deleted = 0 and p.Number = @Project
	JOIN SY_WeekLists w ON sh.[WeekID] = w.[ID] and w.EndOfWeek >= @Rprtdate
	LEFT JOIN DT_Departments d ON sh.[DepartmentID] = d.[ID]
	LEFT JOIN [dbo].[vwCodeGroups] groups on d.AcctGroup = groups.code
	--where ISNULL(sh.PHrs,0) > 0
	--sh.PHrs > 0
	GROUP BY [AcctGroup]
) mp on mp.[AcctGroup] = groups.Code

--FC
full outer JOIN (
	
	SELECT 
		ftc.[AccountGroup]
		,max( ftc.[ForecastHrs] ) as [ForecastHrs]
		,max( ftc.[ForecastAmnt] ) as [ForecastAmnt]
		,fu.[DateLastModified] AS FCUpdate
	FROM DT_ForecastUpdates fu
	LEFT JOIN DT_ForecastToCompletes ftc ON fu.[ID] = ftc.[ForecastID]
	LEFT JOIN [vwCodeGroups] groups on groups.code = ftc.AccountGroup
	where fu.Project = @Project
		and fu.DateCreated = ( SELECT MAX([DateCreated]) FROM DT_ForecastUpdates WHERE [Project] = @Project)
		AND fu.Deleted = 0 and AccountGroup is not null
		--and ISNULL(ftc.[ForecastAmnt],0) > 0 and ISNULL(ftc.[ForecastHrs],0) > 0
		--and ftc.[ForecastAmnt] > 0 and ForecastHrs > 0
	GROUP BY AccountGroup, fu.DateLastModified
	
) fc on fc.[AccountGroup] = groups.Code


where 
	project.Project = @Project
	AND ISNULL(budgets.Budget,0) + ISNULL(budgets.BudgetHrs,0) + ISNULL(actuals.TotalHrs,0) 
		+ ISNULL(actuals.Billed,0) + ISNULL(js.[BudgetHrs],0) + ISNULL(js.[RemainingHrs],0) 
		+ ISNULL(fc.[ForecastHrs],0) + ISNULL(fc.[ForecastAmnt],0) + ISNULL(mp.[Projected],0) > 0


end
--**************************************************************************************************
--*********************************************************************************************************************
SELECT

	@Project as project
	, tasks.Code  as AcctNumber
	, ISNULL( tasks.DescriptionShort, tasks.Description) as AcctGroup
	, convert( varchar, tasks.Code) + ' ' + ISNULL( tasks.DescriptionShort, tasks.Description) as AcctNumberGroup
	, Case
		When Left (@Project, 3) = '2.D' Then ISNULL( budget.budget, 0) / 3.67
		Else ISNULL( budget.budget, 0)
		End As budget
	, Case
		When Left (@Project, 3) = '2.D' Then ISNULL( act.[costs], 0) / 3.67
		Else ISNULL( act.[costs], 0)
		End As [costs]
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
		--,Case 
		--When Left (@Project, 3) = '2.D' Then SUM( Amount ) / 3.67
		--Else SUM ( Amount) 
		--End as Amount
		, SUM ( Amount ) as Amount
		--,Case 
		--When Left (@Project, 3) = '2.D' Then SUM( BillExt )  / 3.67 
		--Else SUM( BillExt ) 
		--End as costs
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

