USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spUtility_VisionCreateMissingSchedules_4]    Script Date: 09/03/2013 11:34:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUtility_VisionCreateMissingSchedules_4]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUtility_VisionCreateMissingSchedules_4]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spUtility_VisionCreateMissingSchedules_4]    Script Date: 09/03/2013 11:34:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spUtility_VisionCreateMissingSchedules_4]
AS
-- Load any missing schedules
INSERT INTO
	dt_ScheduleHours
	(
		[ProjectID]
		,[EmployeeID]
		,[WeekID]
		,[DepartmentID]
	)
	SELECT
		visTime.[ProjectID]
		,visTime.[EmployeeID]
		,visTime.[WeekID]
		,visTime.[DeptId] AS [DepartmentID]
	FROM
		(
		SELECT
			vpt.[TransDate]
			,vpt.[TotalHrs]
			,proj.[ID] AS [ProjectID]
			,emp.[ID] AS [EmployeeID]
			,dbo.funcWeekIDbyDate(vpt.[TransDate]) AS [WeekID]
			, d.ID as [DeptId]
		FROM
			dt_VisionProcessTime vpt
			LEFT JOIN dt_Projects proj ON vpt.[WBS1] = proj.[Number]
			LEFT JOIN dt_Employees emp ON vpt.[Employee] = emp.[Number]
			LEFT JOIN DT_Departments d on d.AcctGroup = (vpt.AcctCode / 1000) * 1000
		WHERE
			vpt.[Processed] = 0
			AND proj.[Deleted] = 0
			AND emp.[Deleted] = 0
		) visTime
		
								
		LEFT JOIN dt_ScheduleHours sh ON visTime.[ProjectID] = sh.[ProjectID] 
								AND visTime.[EmployeeID] = sh.[EmployeeID] 
								AND visTime.[WeekID] = sh.[WeekID] 
								AND visTime.[DeptId] = sh.[DepartmentID]
								
	WHERE sh.[ID] Is NULL
								
								

		
DECLARE @ResultVals varchar(500)
SET @ResultVals = 'Rows changed ' + cast(@@rowcount as varchar(10))
EXEC spUtility_CreateLogEntry 'spUtility_VisionCreateMissingSchedules_4', @ResultVals

GO


