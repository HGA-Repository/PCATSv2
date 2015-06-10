USE [RSManpowerSchDb_dev]
GO


IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwCodeCategorys]'))
DROP VIEW [dbo].[vwCodeCategorys]
GO

USE [RSManpowerSchDb_dev]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[vwCodeCategorys]
AS

/* 

	Displays all codes and their task level groups
	SELECT * FROM [dbo].[vwCodeCategorys]

*/


SELECT 
	al.code 
	,codes.[CategoryCode] as [CategoryCode]
FROM vwAllAccountCodes al

left join (
	SELECT distinct 
		al.code, c.Code as [CategoryCode] 
		FROM vwAllAccountCodes al 
	left join SY_AccountCodeActivitys   a on al.code = a.Code
	left join SY_AccountCodeCategorys   c on a.CategoryID = c.ID OR al.code = c.Code

) codes on codes.code = al.Code



GO


