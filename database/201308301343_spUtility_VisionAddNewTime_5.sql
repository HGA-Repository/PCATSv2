USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spUtility_VisionAddNewTime_5]    Script Date: 08/30/2013 13:19:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUtility_VisionAddNewTime_5]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUtility_VisionAddNewTime_5]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spUtility_VisionAddNewTime_5]    Script Date: 08/30/2013 13:19:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--SELECT * FROM vwVision_Emp_Proj_Time

CREATE PROCEDURE [dbo].[spUtility_VisionAddNewTime_5]
AS
-- Update with the new time
UPDATE
	sh
SET
	sh.[AHrs] = visHrs.[Hours]
FROM
	(
	SELECT
		visTime.[ProjectID]
		,visTime.[EmployeeID]
		,visTime.[WeekID]
		,deptSys.[ID] AS [DepartmentID]
		,SUM(visTime.[TotalHrs]) AS [Hours]
	FROM
		(
			SELECT
				vpt.[TransDate]
				,vpt.[TotalHrs]
				,proj.[ID] AS [ProjectID]
				,emp.[ID] AS [EmployeeID]
				,dbo.funcWeekIDbyDate(vpt.[TransDate]) AS [WeekID]
				,((vpt.AcctCode / 1000) * 1000) as DeptAcctGroup
			FROM
				dt_VisionProcessTime vpt
				LEFT JOIN dt_Projects proj ON vpt.[WBS1] = proj.[Number]
				LEFT JOIN dt_Employees emp ON vpt.[Employee] = emp.[Number]
			WHERE
				vpt.[Processed] = 0
				AND proj.[Deleted] = 0
				AND emp.[Deleted] = 0
			) visTime
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
			) deptSys ON visTime.[DeptAcctGroup] = deptSys.[AcctGroup]
	WHERE
		deptSys.[ID] Is Not NULL
	GROUP BY
		visTime.[ProjectID], visTime.[EmployeeID], visTime.[WeekID], deptSys.[ID]		
	) visHrs,
	dt_ScheduleHours sh
WHERE
	visHrs.[ProjectID] = sh.[ProjectID]
	AND visHrs.[EmployeeID] = sh.[EmployeeID]
	AND visHrs.[WeekID] = sh.[WeekID]
	AND visHrs.[DepartmentID] = sh.[DepartmentID]
	

		
DECLARE @ResultVals varchar(500)
SET @ResultVals = 'Rows changed ' + cast(@@rowcount as varchar(10))
EXEC spUtility_CreateLogEntry 'spUtility_VisionAddNewTime_5', @ResultVals

-- set all new time as updated
UPDATE
	dt_VisionProcessTime
SET
	[Processed] = 1
	,[DateLastModified] = getdate()
WHERE
	[Processed] = 0
	

SET @ResultVals = 'Rows changed ' + cast(@@rowcount as varchar(10))
EXEC spUtility_CreateLogEntry 'spUtility_VisionAddNewTime_5', @ResultVals
GO


