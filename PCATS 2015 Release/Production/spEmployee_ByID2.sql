USE [RSManpowerSchDbBeta2]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_ByID2]    Script Date: 7/13/2015 1:55:26 PM ******/
DROP PROCEDURE [dbo].[spEmployee_ByID2]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_ByID2]    Script Date: 7/13/2015 1:55:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spEmployee_ByID2]
@ID		int
AS
SELECT
	[ID],
	[Number],
	[Name],
	[Abbrev],
	[EmpTitleID],
	[MinHrs],
	[MaxRegHrs],
	[MaxAllHrs],
	[IsActive],
	[IsProjectManager],
	[IsRelManager],			-- Added 7/13/2015
	[Contractor],
	[OfficeLocation],
	[EngineerType]
	
	
FROM
	DT_Employees
WHERE
	[ID] = @ID



GO

