USE [RSManpowerSchDbBeta2]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_ListAll2]    Script Date: 7/13/2015 1:56:22 PM ******/
DROP PROCEDURE [dbo].[spEmployee_ListAll2]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_ListAll2]    Script Date: 7/13/2015 1:56:22 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spEmployee_ListAll2]
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
	[IsRelManager], -- Added 7/13/15
	[Contractor],
	[OfficeLocation],
	[EngineerType]
FROM
	DT_Employees
WHERE
	[Deleted] = 0
ORDER BY
	[Name] ASC



GO

