USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spForecastToComplete_InsertUpdateNew2_Vision]    Script Date: 05/28/2013 15:08:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spForecastToComplete_InsertUpdateNew2_Vision]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spForecastToComplete_InsertUpdateNew2_Vision]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spForecastToComplete_InsertUpdateNew2_Vision]    Script Date: 05/28/2013 15:08:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spForecastToComplete_InsertUpdateNew2_Vision]
@ForecastID	int,
@AccountGroup	varchar(50),
@ForecastHrs	money,
@ForecastRate	money,
@SpecialGroup int
AS

DECLARE @PROJECT varchar(50)
DECLARE @ACTUALAHRS money
DECLARE @ACTUALDLRS money


DECLARE @HOURS money
DECLARE @RATE money
DECLARE @AMOUNT money


BEGIN
SELECT @PROJECT = [Project] FROM DT_ForecastUpdates WHERE [ID] = @ForecastID
END

IF @ForecastHrs > 0
BEGIN
	BEGIN
	
		SELECT
		  @ACTUALAHRS = SUM( ISNULL(ept.[RegHrs],0) + ISNULL(ept.[OvtHrs],0) )
		  , @ACTUALDLRS = SUM(ISNULL(ept.[Billed],0))
		FROM vwVision_Emp_Proj_Time ept 
		WHERE ept.WBS1 = @PROJECT AND ept.GroupCode = @AccountGroup
		GROUP BY ept.[WBS1]

	END

	BEGIN
	INSERT INTO
		DT_ForecastToCompletes
	(
		[ForecastID]
		,[AccountGroup]
		,[ForecastHrs]
		,[ForecastRate]
		,[ForecastAmnt]
	)
	VALUES
	(
		@ForecastID
		,@AccountGroup
		,ISNULL(@ACTUALAHRS,0) + @ForecastHrs
		,@ForecastRate
		,ISNULL(@ACTUALDLRS,0) + @ForecastHrs * @ForecastRate
	)
	END
END
ELSE
BEGIN
	BEGIN

		SELECT
		  @ACTUALAHRS = SUM( ISNULL(ept.[RegHrs],0) + ISNULL(ept.[OvtHrs],0) )
		  , @ACTUALDLRS = SUM(ISNULL(ept.[Billed],0))
		FROM vwVision_Emp_Proj_Time ept 
		WHERE ept.WBS1 = @PROJECT AND ept.GroupCode = @AccountGroup
		GROUP BY ept.[WBS1]
		
	END


	BEGIN
	INSERT INTO
		DT_ForecastToCompletes
	(
		[ForecastID]
		,[AccountGroup]
		,[ForecastHrs]
		,[ForecastRate]
		,[ForecastAmnt]
	)
	VALUES
	(
		@ForecastID
		,@AccountGroup
		,ISNULL( @ACTUALAHRS, 0)
		,ISNULL( @ForecastRate,0 )
		,ISNULL( @ACTUALDLRS, 0)
	)
	END
END


GO


