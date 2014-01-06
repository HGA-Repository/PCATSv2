USE [RSManpowerSchDb_test]
GO


IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwCodeGroups]'))
DROP VIEW [dbo].[vwCodeGroups]
GO

USE [RSManpowerSchDb_test]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE VIEW [dbo].[vwCodeGroups]
AS

/* 

	Displays all codes and their top level groups
	SELECT * FROM [dbo].[vwCodeGroups]

*/


SELECT 
	al.code 
	,codes.[group] as CodeGroup
FROM vwAllAccountCodes al

left join (
	SELECT distinct 
		al.code, d.Code as [group] 
		FROM vwAllAccountCodes al 
	left join SY_AccountCodeActivitys   a on al.code = a.Code
	left join SY_AccountCodeCategorys   c on a.CategoryID = c.ID OR al.code = c.Code
	left join SY_AccountCodeTasks       t on c.CategoryID = t.ID OR al.code = t.Code
	left join SY_AccountCodeDisciplines d on t.CategoryID = d.ID OR al.code = d.Code
) codes on codes.code = al.Code


GO


