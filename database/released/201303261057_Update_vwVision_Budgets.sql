USE [RSManpowerSchDb_test]
GO

/****** Object:  View [dbo].[vwVision_Budgets]    Script Date: 03/26/2013 10:58:12 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVision_Budgets]'))
DROP VIEW [dbo].[vwVision_Budgets]
GO

USE [RSManpowerSchDb_test]
GO

/****** Object:  View [dbo].[vwVision_Budgets]    Script Date: 03/26/2013 10:58:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwVision_Budgets]
AS

/*
SELECT top 1000 * FROM [dbo].[vwVision_Budgets]
SELECT 	COUNT(*) FROM [dbo].[vwVision_Budgets] --33142 
*/

SELECT
	vision.[Project]
	, vision.[Phase]
	, vision.[BudgetHrs]
	, vision.[Budget]
	, ISNULL( codes.[group], alt_group_code.Code) as GroupCode
FROM (
	SELECT
		bud.[WBS1] AS [Project]
		, isnull(map.NewCode, WBS3) as [Phase]
		,bud.[HrsBud] AS [BudgetHrs]
		,bud.[BillBud] AS [Budget]
		,ISNULL( map.NewCode, case when ISNUMERIC([WBS3]) = 1 then CONVERT( decimal, [WBS3]) else null end ) as Code
	FROM
		[Vision].[HGAVISIONDATABASE].dbo.[LB] bud
		left join CodeMappings map on LTRIM(RTRIM([WBS3])) = map.OldCode
) vision
	
	
left join (
	SELECT distinct 
		al.code, d.Code as [group] 
		FROM vwAllAccountCodes al 
	left join SY_AccountCodeActivitys   a on al.code = a.Code
	left join SY_AccountCodeCategorys   c on a.CategoryID = c.ID OR al.code = c.Code
	left join SY_AccountCodeTasks       t on c.CategoryID = t.ID OR al.code = t.Code
	left join SY_AccountCodeDisciplines d on t.CategoryID = d.ID OR al.code = d.Code
) codes on vision.Code = codes.code
left join SY_AccountCodeDisciplines alt_group_code on vision.code / 1000 = alt_group_code.Code / 1000
		

GO


