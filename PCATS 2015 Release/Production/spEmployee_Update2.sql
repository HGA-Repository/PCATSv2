USE [RSManpowerSchDbBeta2]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_Update2]    Script Date: 7/13/2015 1:55:52 PM ******/
DROP PROCEDURE [dbo].[spEmployee_Update2]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_Update2]    Script Date: 7/13/2015 1:55:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spEmployee_Update2]
@ID		int,
@Number		varchar(10),
@Name		varchar(100),
@Abbrev		varchar(50),
@EmpTitleID		int,
@MinHrs		money,
@MaxRegHrs		money,
@MaxAllHrs		money,
@IsActive		bit,
@IsProjectManager	bit,
@IsRelManager	bit, --Added 7/13/15
@Contractor	bit,
@OfficeLocation varchar(50),
@EngineerType varchar(50)
AS
UPDATE
	DT_Employees
SET
	[Number] = @Number,
	[Name] = @Name,
	[Abbrev] = @Abbrev,
	[EmpTitleID] = @EmpTitleID,
	[MinHrs] = @MinHrs,
	[MaxRegHrs] = @MaxRegHrs,
	[MaxAllHrs] = @MaxAllHrs,
	[IsActive] = @IsActive,
	[IsProjectManager] = @IsProjectManager,
	[IsRelManager] = @IsRelManager,
	[Contractor] = @Contractor,
	[OfficeLocation] = @OfficeLocation,
	[EngineerType] = @EngineerType
WHERE
	[ID] = @ID



GO

