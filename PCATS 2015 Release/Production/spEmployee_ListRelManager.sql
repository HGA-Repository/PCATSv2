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


