USE [RSManpowerSchDbBeta2]
GO

/****** Object:  StoredProcedure [dbo].[spEmployee_ListRelManager]    Script Date: 7/13/2015 1:54:45 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[spEmployee_ListRelManager]
AS
SELECT
	emp.[ID],
	emp.[Number],
	emp.[Name],
	emp.[Abbrev],
	emp.[EmpTitleID],
	emp.[MinHrs],
	emp.[MaxRegHrs],
	emp.[MaxAllHrs],
	emp.[IsActive],
	emp.[IsProjectManager],
	emp.[IsRelManager],
	emp.[Contractor],
	emp.[OfficeLocation],
	emp.[EngineerType]
FROM
	DT_Employees emp
WHERE
	emp.[Deleted] = 0
	AND
	emp.[IsRelManager] = 1
ORDER BY
	emp.[Name] ASC




GO

