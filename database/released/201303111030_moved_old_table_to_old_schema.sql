





IF  EXISTS (SELECT * FROM sys.schemas WHERE name = N'codes_v1')
DROP SCHEMA [codes_v1]
GO


CREATE SCHEMA [codes_v1] AUTHORIZATION [dbo]
GO



select * into codes_v1.SY_AccountCodeActivitys from dbo.SY_AccountCodeActivitys
select * into codes_v1.SY_AccountCodeCategorys from dbo.SY_AccountCodeCategorys
select * into codes_v1.SY_AccountCodeDisciplines from dbo.SY_AccountCodeDisciplines
select * into codes_v1.SY_AccountCodeTasks from dbo.SY_AccountCodeTasks
select * into codes_v1.SY_AccountGroups from dbo.SY_AccountGroups
select * into codes_v1.SY_AccountGroups2 from dbo.SY_AccountGroups2
select * into codes_v1.SY2_AccountCodeActivitys from dbo.SY2_AccountCodeActivitys
select * into codes_v1.SY2_AccountCodeCategorys from dbo.SY2_AccountCodeCategorys
select * into codes_v1.SY2_AccountCodeDisciplines from dbo.SY2_AccountCodeDisciplines
select * into codes_v1.SY2_AccountCodeTasks from dbo.SY2_AccountCodeTasks
select * into codes_v1.SY2_AccountGroups2 from dbo.SY2_AccountGroups2
select * into codes_v1.DT_ActivityCodes from dbo.DT_ActivityCodes



--ALTER TABLE dbo.SY_AccountCodeActivitys RENAME TO dbo.SY_AccountCodeActivitys_old
--ALTER TABLE dbo.SY_AccountCodeCategorys RENAME TO dbo.SY_AccountCodeCategorys_old
--ALTER TABLE dbo.SY_AccountCodeDisciplines RENAME TO dbo.SY_AccountCodeDisciplines_old
--ALTER TABLE dbo.SY_AccountCodeTasks RENAME TO dbo.SY_AccountCodeTasks_old
exec sp_RENAME 'dbo.SY_AccountGroups', 'SY_AccountGroups_old';
go
--exec sp_RENAME 'dbo.SY_AccountGroups2', 'SY_AccountGroups2_old';
--go
exec sp_RENAME 'dbo.SY2_AccountCodeActivitys', 'SY2_AccountCodeActivitys_old';
go
exec sp_RENAME 'dbo.SY2_AccountCodeCategorys', 'SY2_AccountCodeCategorys_old';
go
exec sp_RENAME 'dbo.SY2_AccountCodeDisciplines', 'SY2_AccountCodeDisciplines_old';
go
exec sp_RENAME 'dbo.SY2_AccountCodeTasks', 'SY2_AccountCodeTasks_old'; 
go
exec sp_RENAME 'dbo.SY2_AccountGroups2', 'SY2_AccountGroups2_old'; 
go





USE [RSManpowerSchDb]
GO
/****** Object:  View [dbo].[vwAllAccountCodes]    Script Date: 03/18/2013 11:13:44 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwAllAccountCodes]'))
DROP VIEW [dbo].[vwAllAccountCodes]
GO
USE [RSManpowerSchDb]
GO
/****** Object:  View [dbo].[vwAllAccountCodes]    Script Date: 03/18/2013 11:13:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[vwAllAccountCodes]
AS
SELECT 
j.code
, ISNULL( d1, ISNULL( d2, ISNULL( d3, ISNULL( d4, null) ) ) ) as Description
FROM
(
SELECT 
codes.Code
,( select top 1 Description from SY_AccountCodeDisciplines d where d.Code = Codes.code and Deleted = 0) as d1
,( select top 1 Description from SY_AccountCodeTasks d where d.Code = Codes.code and Deleted = 0) as d2
,( select top 1 Description from SY_AccountCodeCategorys d where d.Code = Codes.code and Deleted = 0) as d3
,( select top 1 Description from SY_AccountCodeActivitys d where d.Code = Codes.code and Deleted = 0) as d4
FROM (
	SELECT DISTINCT code from (
	SELECT Code from SY_AccountCodeDisciplines where Deleted = 0
	union
	SELECT Code from SY_AccountCodeTasks  where Deleted = 0
	union
	SELECT Code from SY_AccountCodeCategorys where Deleted = 0
	union
	SELECT Code from SY_AccountCodeActivitys where Deleted = 0
	)c
) codes
)j
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











/* CREATE MAPPING TABLE */
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.CodeMappings
	(
	ID int NOT NULL IDENTITY (1, 1),
	OldCode varchar(10) NULL,
	OldDesc varchar(400) NULL,
	OldVersion int NOT NULL,
	NewCode varchar(10) NULL,
	NewDesc varchar(400) NULL,
	NewVersion int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.CodeMappings ADD CONSTRAINT
	PK_CodeMappings PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.CodeMappings SET (LOCK_ESCALATION = TABLE)
GO
COMMIT





TRUNCATE TABLE CodeMappings


INSERT INTO CodeMappings
SELECT
  [Old Code]
, [Old Desc]
, 1
, [New Code]
, [New Desc]
, 2
FROM [RSManpowerSchDb].[dbo].[mappings_raw]


--Add E version of the Expenses Codes
--INSERT INTO CodeMappings
--SELECT 
--'E' + OldCode
--, OldDesc
--, 1
--, NewCode
--, NewDesc
--, 2
-- FROM CodeMappings where isnumeric(oldcode) = 1 and (convert( int, oldcode ) / 1000) = 9
 
 
 --Update to E-less version of the Expenses Codes
UPDATE CodeMappings 
set NewCode = SUBSTRING( NewCode ,2 , 10 )
where isnumeric(oldcode) = 1 and (convert( int, oldcode ) / 1000) = 9 and NewCode like 'E%'


UPDATE CodeMappings 
set NewCode = SUBSTRING( NewCode ,2 , 10 )
where NewCode like 'E%'









DROP TABLE Mappings_raw







/****************  SHOULD BE REMOVED WHEN CODES ARE FINISHED!!!  ********************/


--UPDATE CodeMappings 
--set NewCode = OldCode + 10000
--, NewDesc = OldDesc
--where OldCode is not null and NewCode is null

----make sure every code has a mapping
--UPDATE CodeMappings
--set NewCode = OldCode + 30000, newDesc = OldDesc
--where NewCode is null


--/* Add All Missing Codes */
--INSERT INTO CodeMappings
--SELECT 
--al.Code, al.Description, 1
--,al.Code + 40000, al.Description, 1
--FROM vwAllAccountCodes al
--LEFT JOIN CodeMappings mp on al.Code = mp.OldCode
--where mp.OldCode is null
--order by Code

































