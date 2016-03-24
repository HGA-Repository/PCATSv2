CREATE PROCEDURE [dbo].[spAcctCodeAct_DepartmentGroup_ListAll]
AS
SELECT
	[ID],
	--[CategoryID],
	[Code],
	[Description]
	--[DescriptionShort]
FROM
	SY_AccountCodeDisciplines
	where code <> 0
ORDER BY
	[Code] ASC


GO


