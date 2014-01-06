USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spForecastToComplete_Insert2_Vision]    Script Date: 04/30/2013 15:41:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spForecastToComplete_Insert2_Vision]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spForecastToComplete_Insert2_Vision]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spForecastToComplete_Insert2_Vision]    Script Date: 04/30/2013 15:41:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spForecastToComplete_Insert2_Vision]
@ForecastID	int,
@AccountGroup	varchar(50),
@ForecastHrs	money,
@ForecastRate	money,
@SpecialGroup	int
AS

/*
exec spForecastToComplete_Insert2_Vision @ForecastID=39538,@AccountGroup='11000',@ForecastHrs=$123.0000,@ForecastRate=$123.0000,@SpecialGroup=0
*/


DECLARE @PROJECT varchar(50)
DECLARE @ACTUALAHRS money
DECLARE @ACTUALDLRS money


DECLARE @HOURS money
DECLARE @RATE money
DECLARE @AMOUNT money
DECLARE @DATELASTMODIFIED smalldatetime


BEGIN
SELECT @PROJECT = [Project] FROM DT_ForecastUpdates WHERE [ID] = @ForecastID
END

IF @ForecastHrs <> 0
BEGIN
	IF CONVERT(INT,@AccountGroup) > 1000
	BEGIN
		IF dbo.FuncIsOldJob(@PROJECT) = 0
		-- determine ftc from input
		BEGIN
			EXEC spForecastToComplete_InsertUpdateNew2_Vision @ForecastID, @AccountGroup, @ForecastHrs, @ForecastRate, @SpecialGroup
		END
		ELSE
		BEGIN
			EXEC spForecastToComplete_InsertUpdateOld2_Vision @ForecastID, @AccountGroup, @ForecastHrs, @ForecastRate
		END
	END
	ELSE
	BEGIN
		EXEC spForecastToComplete_InsertExpense2_Vision @ForecastID, @AccountGroup, @ForecastHrs, @ForecastRate
	END
END
ELSE
BEGIN
	BEGIN
	SELECT
		@HOURS = [ForecastHrs]
		,@RATE = [ForecastRate]
		,@AMOUNT = [ForecastAmnt]
	FROM
		DT_ForecastToCompletes
	WHERE
		[ForecastID] =
						(SELECT
							MAX(fu.[ID]) AS LastUpdateID
						FROM
							DT_ForecastUpdates fu
						WHERE
							fu.[ID] < @ForecastID
							AND
							fu.[Project] = @PROJECT)
		AND
		[AccountGroup] = @AccountGroup
	END

	BEGIN
	SELECT
		@DATELASTMODIFIED = ISNULL(MAX(ftc.[DateLastModified]),'1/1/1900')
	FROM
		DT_ForecastUpdates fu
		LEFT JOIN
		DT_ForecastToCompletes ftc ON fu.[ID] = ftc.[ForecastID]
	WHERE
		fu.[Project] = @PROJECT
		AND
		ftc.[AccountGroup] = @AccountGroup
		AND
		ftc.[ForecastHrs] != 0
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
		,[DateLastModified]
	)
	VALUES
	(
		@ForecastID
		,@AccountGroup
		,@HOURS
		,@RATE
		,@AMOUNT
		,@DATELASTMODIFIED
	)
	END
END


GO


