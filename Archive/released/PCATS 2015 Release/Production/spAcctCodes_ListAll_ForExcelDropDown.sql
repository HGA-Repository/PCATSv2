CREATE PROCEDURE [dbo].[spAcctCodes_ListAll_ForExcelDropDown]
AS
--SELECT	top 10 Code
SELECT	  Code
FROM DT_ActivityCodes
ORDER BY
	Code ASC


GO


