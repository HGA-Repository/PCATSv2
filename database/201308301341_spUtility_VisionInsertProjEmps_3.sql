USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spUtility_VisionInsertProjEmps_3]    Script Date: 08/30/2013 13:08:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUtility_VisionInsertProjEmps_3]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUtility_VisionInsertProjEmps_3]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spUtility_VisionInsertProjEmps_3]    Script Date: 08/30/2013 13:08:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spUtility_VisionInsertProjEmps_3]
AS
INSERT INTO
	dt_ProjectEmployees
(
	[ProjectID]
	,[EmployeeID]
	,[DepartmentID]
)
SELECT DISTINCT
	missingEmp.[projectID] AS [ProjectID]
	,missingEmp.[empID] AS [EmployeeID]
	,deptSys.[ID] AS [DepartmentID]
FROM
	(
	SELECT DISTINCT
		p.[ID] AS [projectID]
		,emp.[ID] AS [empID]
		,((vpt.AcctCode / 1000) * 1000) as DeptAcctGroup
	FROM
		dt_VisionProcessTime vpt
		LEFT JOIN dt_Projects p ON vpt.[WBS1] = p.[Number]
		LEFT JOIN dt_Employees emp ON vpt.[Employee] = emp.[Number]
		LEFT JOIN dt_ProjectEmployees pe ON p.[ID] = pe.[ProjectID] AND emp.[ID] = pe.[EmployeeID]
	WHERE
		vpt.[Processed] = 0
		AND p.[Number] Is Not NULL
		AND p.[Deleted] = 0
		AND emp.[Deleted] = 0
		AND pe.[EmployeeID] Is NULL
	) missingEmp
	LEFT JOIN
	(
	SELECT
		[ID]
		,CAST([AcctGroup] as varchar(5)) AS [AcctGroup]
	FROM
		dt_Departments
	WHERE
		[DisplayInList] = 1
		AND [Deleted] = 0
	) deptSys ON missingEmp.[DeptAcctGroup] = deptSys.[AcctGroup]
WHERE
	deptSys.[ID] Is Not NULL


		
DECLARE @ResultVals varchar(500)
SET @ResultVals = 'Rows changed ' + cast(@@rowcount as varchar(10))
EXEC spUtility_CreateLogEntry 'spUtility_VisionInsertProjEmps_3', @ResultVals
GO


