USE [RSManpowerSchDb]
GO

/****** Object:  View [dbo].[vwAllAccountCodes]    Script Date: 03/18/2013 08:27:57 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwAllAccountCodes]'))
DROP VIEW [dbo].[vwAllAccountCodes]
GO

USE [RSManpowerSchDb]
GO

/****** Object:  View [dbo].[vwAllAccountCodes]    Script Date: 03/18/2013 08:27:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vwAllAccountCodes]
AS

SELECT DISTINCT * FROM (
SELECT Code, Description, 1000 as digit  from SY_AccountCodeDisciplines where Deleted = 0
union
SELECT Code, Description, 100 as digit  from SY_AccountCodeTasks  where Deleted = 0
union
SELECT Code, Description, 10 as digit  from SY_AccountCodeCategorys where Deleted = 0
union
SELECT Code, Description, 1  as digit from SY_AccountCodeActivitys where Deleted = 0
) codes



GO







USE [RSManpowerSchDb]
GO

/****** Object:  View [dbo].[vwAllUsedAccountCodes]    Script Date: 03/18/2013 08:28:05 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwAllUsedAccountCodes]'))
DROP VIEW [dbo].[vwAllUsedAccountCodes]
GO

USE [RSManpowerSchDb]
GO

/****** Object:  View [dbo].[vwAllUsedAccountCodes]    Script Date: 03/18/2013 08:28:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwAllUsedAccountCodes]
AS

--SELECT DISTINCT top 100 * FROM [DT_BudgetLines]
SELECT used.Code--, al.Description
FROM (
SELECT DISTINCT [DeptGroup] as Code FROM [DT_BudgetLines] where Quantity > 0 OR HoursEach > 0 OR TotalHours > 0
union
SELECT DISTINCT [Task] as Code  FROM [DT_BudgetLines] where Quantity > 0 OR HoursEach > 0 OR TotalHours > 0
union
SELECT DISTINCT [Category] as Code  FROM [DT_BudgetLines] where Quantity > 0 OR HoursEach > 0 OR TotalHours > 0
union
SELECT DISTINCT [Activity] as Code  FROM [DT_BudgetLines] where Quantity > 0 OR HoursEach > 0 OR TotalHours > 0
)used
--LEFT JOIN vwAllAccountCodes al on used.Code = al.Code


GO






USE [RSManpowerSchDb]
GO

/****** Object:  View [dbo].[vwAllNotUsedAccountCodes]    Script Date: 03/18/2013 08:28:20 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwAllNotUsedAccountCodes]'))
DROP VIEW [dbo].[vwAllNotUsedAccountCodes]
GO

USE [RSManpowerSchDb]
GO

/****** Object:  View [dbo].[vwAllNotUsedAccountCodes]    Script Date: 03/18/2013 08:28:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwAllNotUsedAccountCodes]
AS
 
 
SELECT al.Code, al.Description FROM vwAllAccountCodes al
Left JOIN vwAllUsedAccountCodes used on al.Code = used.Code
where used.Code is null



GO




