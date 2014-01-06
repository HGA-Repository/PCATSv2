USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwFTCForProjecGroups]    Script Date: 05/14/2013 15:01:49 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwFTCForProjecGroups]'))
DROP VIEW [dbo].[vwFTCForProjecGroups]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwFTCForProjecGroups]    Script Date: 05/14/2013 15:01:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE VIEW [dbo].[vwFTCForProjecGroups]
AS


/*
SELECT * FROM [vwFTCForProjecGroups] where project = '8.110001.00.0' order by GroupCode
*/


SELECT  
	project
	, code as GroupCode
	, CASE when ftc < 0 then 0 else ftc end as ftc
FROM
(


	SELECT 

		t_hours.project
		,t_hours.code 
		, ISNULL(ISNULL(fc.[ForecastHrs], budgets.BudgetHrs),0) - ISNULL(t_hours.TotalHrs,0) as FTC

	FROM 
	(


		SELECT 
			project_groups.* 
			, SUM( ISNULL(act.TotalHrs,0) ) as TotalHrs
		FROM 
		(
			SELECT project, groups.code from vwVision_Projects project LEFT JOIN SY_AccountCodeDisciplines groups on groups.Code > 1000
		) project_groups
		Left Join [vwVision_Emp_Proj_Time] act on act.GroupCode = project_groups.code and act.WBS1 = project_groups.project
		GROUP BY project_groups.project, project_groups.code

	) t_hours


	
	
	--Budgeted Info
	LEFT JOIN (
	SELECT 
		FU.[Project]
		, FTC.[AccountGroup]
		, FTC.ForecastHrs
	FROM DT_ForecastUpdates fu
	JOIN( SELECT MAX([DateCreated]) as [DateCreated], [Project] FROM DT_ForecastUpdates GROUP BY [Project] ) latest on fu.project = latest.project and fu.[DateCreated] = latest.[DateCreated]
	LEFT JOIN DT_ForecastToCompletes FTC ON fu.[ID] = ftc.[ForecastID]
	) fc on fc.[Project] = t_hours.project and t_hours.code = fc.[AccountGroup]
	
	
	--Budgeted Info
	LEFT JOIN (
		SELECT 
			GroupCode
			,Project
			, SUM(BudgetHrs) as BudgetHrs
		FROM vwVision_Budgets
		GROUP BY GroupCode, Project
	) as budgets on budgets.GroupCode = t_hours.Code and budgets.[Project] = t_hours.project
	

) ftc_select








GO


