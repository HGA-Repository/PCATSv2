USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwVision_Emp_Proj_Time]    Script Date: 07/09/2013 09:58:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVision_Emp_Proj_Time]'))
DROP VIEW [dbo].[vwVision_Emp_Proj_Time]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwVision_Emp_Proj_Time]    Script Date: 07/09/2013 09:58:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO








CREATE VIEW [dbo].[vwVision_Emp_Proj_Time]
AS



SELECT
	[PKey]
	,[TransDate]
	,[RegHrs]
	,[OvtHrs] + [SpecialOvtHrs] AS [OvtHrs]
	,[RegHrs] + [OvtHrs] + [SpecialOvtHrs] AS [TotalHrs]
	,[BillExt] AS [Billed]
	,[BillStatus]
	,v.[WBS1]
	,[Employee]
	,[Name] AS [EmpName]
	, ISNULL( convert(varchar, vor.code), LEFT(v.[WBS3],5) ) as AcctCode
	,v.[WBS3]
	,[LaborCode]
	,GroupCode = CASE 
		WHEN vor.AccountGroup is not null then vor.AccountGroup
		WHEN ISNUMERIC( LEFT(v.[WBS3],5) ) = 1 then ((LEFT(v.[WBS3],5) / 1000) * 1000 )
		ELSE NULL END
FROM
	[Vision].[HGAVISIONDATABASE].dbo.[LD] v
	--NOTE: all old codes / projects are listed in the override table
	LEFT JOIN dbo.VisionMappingOverrides vor on v.WBS1 = vor.WBS1 and v.WBS3 = vor.WBS3
WHERE
	[TransDate] > '1/1/2007'
	AND ISNUMERIC( LEFT(v.[WBS3],4) ) = 1
	AND LEN(v.[WBS3]) > 2
	
	




GO


