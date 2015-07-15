USE [RSManpowerSchDbBeta2]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_Insert2]    Script Date: 7/13/2015 1:57:22 PM ******/
DROP PROCEDURE [dbo].[spEmployee_Insert2]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_Insert2]    Script Date: 7/13/2015 1:57:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spEmployee_Insert2]
@ID		int	output,
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
@Contractor		bit,
@OfficeLocation varchar(50),
@EngineerType varchar(50)
AS
INSERT INTO
	DT_Employees
(
	[Number],
	[Name],
	[Abbrev],
	[EmpTitleID],
	[MinHrs],
	[MaxRegHrs],
	[MaxAllHrs],
	[IsActive],
	[IsProjectManager],
	[IsRelManager],
	[Contractor],
	[OfficeLocation],
	[EngineerType]
)
VALUES
(
	@Number,
	@Name,
	@Abbrev,
	@EmpTitleID,
	@MinHrs,
	@MaxRegHrs,
	@MaxAllHrs,
	@IsActive,
	@IsProjectManager,
	@IsRelManager,
	@Contractor,
	@OfficeLocation,
	@EngineerType
)


SELECT @ID = @@IDENTITY



GO

