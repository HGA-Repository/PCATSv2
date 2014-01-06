USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spUtility_VisionPullTime_1]    Script Date: 08/30/2013 09:37:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spUtility_VisionPullTime_1]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spUtility_VisionPullTime_1]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spUtility_VisionPullTime_1]    Script Date: 08/30/2013 09:37:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUtility_VisionPullTime_1]
AS
INSERT INTO
	dt_VisionProcessTime
	(
		[PKey]
		,[TransDate]
		,[RegHrs]
		,[OvtHrs]
		,[TotalHrs]
		,[Billed]
		,[WBS1]
		,[Employee]
		,[EmpName]
		,[AcctCode]
		,[WBS3]
	)
	SELECT
		vt.[PKey]
		,vt.[TransDate]
		,vt.[RegHrs]
		,vt.[OvtHrs]
		,vt.[TotalHrs]
		,vt.[Billed]
		,vt.[WBS1]
		,vt.[Employee]
		,vt.[EmpName]
		,vt.[AcctCode]
		,vt.[WBS3]
	FROM
		vwVision_Emp_Proj_Time vt
		LEFT JOIN
		dt_VisionProcessTime wpt ON vt.[PKey] = wpt.[PKey]
	WHERE
		wpt.[PKey] Is NULL
		and vt.AcctCode >= 10000
		
		
DECLARE @ResultVals varchar(500)
SET @ResultVals = 'Rows changed ' + cast(@@rowcount as varchar(10))
--SET @ResultVals = 'Rows changed ' + @@rowcount
EXEC spUtility_CreateLogEntry 'spUtility_VisionPullTime', @ResultVals
GO


