USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwVision_Emp_Proj_Time]    Script Date: 04/02/2013 15:36:21 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVision_Emp_Proj_Time]'))
DROP VIEW [dbo].[vwVision_Emp_Proj_Time]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwVision_Emp_Proj_Time]    Script Date: 04/02/2013 15:36:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE VIEW [dbo].[vwVision_Emp_Proj_Time]
AS

/*
SELECT top 1000 * FROM [dbo].[vwVision_Emp_Proj_Time]
SELECT count([PKey]) FROM [dbo].[vwVision_Emp_Proj_Time] --626878 -- 1:04
*/

SELECT
	vision.*
	, ISNULL( codes.[group], alt_group_code.Code) as GroupCode
FROM

(
	SELECT 
		[PKey]
		,[TransDate]
		,[RegHrs]
		,[OvtHrs]
		,[RegHrs] + [OvtHrs] AS [TotalHrs]
		,[BillExt] AS [Billed]
		,[BillStatus]
		,[WBS1]
		,[Employee]
		,[Name] AS [EmpName]
		,ISNULL( map.NewCode, case when ISNUMERIC([WBS3]) = 1 then CONVERT( decimal, [WBS3]) else null end ) as AcctCode
		,[WBS3]
		,[LaborCode]
	FROM
		[Vision].[HGAVISIONDATABASE].dbo.[LD] v
		left join CodeMappings map on [WBS3] = map.OldCode	
	WHERE
		[TransDate] > '1/1/2007'
		AND
		LEFT([WBS3],3) <> 'NON'
		AND
		LEN([WBS3]) > 2
) vision


left join (
	SELECT distinct 
		al.code, d.Code as [group] 
		FROM vwAllAccountCodes al 
	left join SY_AccountCodeActivitys   a on al.code = a.Code
	left join SY_AccountCodeCategorys   c on a.CategoryID = c.ID OR al.code = c.Code
	left join SY_AccountCodeTasks       t on c.CategoryID = t.ID OR al.code = t.Code
	left join SY_AccountCodeDisciplines d on t.CategoryID = d.ID OR al.code = d.Code
) codes on codes.code = vision.AcctCode

left join SY_AccountCodeDisciplines alt_group_code on vision.AcctCode / 1000 = alt_group_code.Code / 1000

	
	
	
	--	left join CodeMappings map on LTRIM(RTRIM([WBS3])) = map.OldCode	
	--left join (
	--	SELECT distinct 
	--		al.code, d.Code as [group] 
	--		FROM vwAllAccountCodes al 
	--	left join SY_AccountCodeActivitys   a on al.code = a.Code
	--	left join SY_AccountCodeCategorys   c on a.CategoryID = c.ID OR al.code = c.Code
	--	left join SY_AccountCodeTasks       t on c.CategoryID = t.ID OR al.code = t.Code
	--	left join SY_AccountCodeDisciplines d on t.CategoryID = d.ID OR al.code = d.Code
	--) codes on codes.code = map.NewCode





GO


