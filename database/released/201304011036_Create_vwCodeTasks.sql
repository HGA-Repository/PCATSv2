USE [RSManpowerSchDb_dev]
GO


IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwCodeTasks]'))
DROP VIEW [dbo].[vwCodeTasks]
GO

USE [RSManpowerSchDb_dev]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[vwCodeTasks]
AS

/* 

	Displays all codes and their task level groups
	SELECT * FROM [dbo].[vwCodeTasks]

*/


SELECT 
	al.code 
	,codes.[TaskCode] as [TaskCode]
FROM vwAllAccountCodes al

left join (
	SELECT distinct 
		al.code, t.Code as [TaskCode] 
		FROM vwAllAccountCodes al 
	left join SY_AccountCodeActivitys   a on al.code = a.Code
	left join SY_AccountCodeCategorys   c on a.CategoryID = c.ID OR al.code = c.Code
	left join SY_AccountCodeTasks       t on c.CategoryID = t.ID OR al.code = t.Code

) codes on codes.code = al.Code



GO


