

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
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

ALTER TABLE dbo.SY_AccountCodeDisciplines ADD
	DescriptionShort varchar(10) NULL
GO

ALTER TABLE dbo.SY_AccountCodeDisciplines SET (LOCK_ESCALATION = TABLE)
GO


ALTER TABLE dbo.SY_AccountCodeTasks ADD
	DescriptionShort varchar(10) NULL
GO

ALTER TABLE dbo.SY_AccountCodeTasks SET (LOCK_ESCALATION = TABLE)
GO

COMMIT





update SY_AccountCodeDisciplines set DescriptionShort = 'Expenses'   where code = 0
update SY_AccountCodeDisciplines set DescriptionShort = 'Adm'    where code = 11000
update SY_AccountCodeDisciplines set DescriptionShort = 'Proc'    where code = 12000
update SY_AccountCodeDisciplines set DescriptionShort = 'M/P' where code = 13000
update SY_AccountCodeDisciplines set DescriptionShort = 'CSA'        where code = 14000
update SY_AccountCodeDisciplines set DescriptionShort = 'Elect' where code = 15000
update SY_AccountCodeDisciplines set DescriptionShort = 'Instr' where code = 16000
update SY_AccountCodeDisciplines set DescriptionShort = 'Spec' where code = 17000
update SY_AccountCodeDisciplines set DescriptionShort = 'PLE'   where code = 18000
update SY_AccountCodeDisciplines set DescriptionShort = 'Surv'     where code = 19000
update SY_AccountCodeDisciplines set DescriptionShort = 'ROW'        where code = 20000
update SY_AccountCodeDisciplines set DescriptionShort = 'CM/I' where code = 21000
update SY_AccountCodeDisciplines set DescriptionShort = 'Env'        where code = 22000
update SY_AccountCodeDisciplines set DescriptionShort = 'PM'    where code = 50000


/*
ID	CategoryID	Code	Description	Deleted	DateLastModified	DateCreated	DescriptionShort
1	1	100	Travel & Subsistence	0	2013-03-27 10:33:00	2013-03-27 10:33:00	NULL
53	1	200	Office & Field Expenses	0	2013-03-27 10:33:00	2013-03-27 10:33:00	NULL
67	1	300	Professional Services Subcontracts	0	2013-03-27 10:33:00	2013-03-27 10:33:00	NULL
68	1	500	Equipment	0	2013-03-27 10:33:00	2013-03-27 10:33:00	NULL
76	1	600	Software	0	2013-03-27 10:33:00	2013-03-27 10:33:00	NULL
*/

update dbo.SY_AccountCodeTasks set DescriptionShort = 'Travel'    where code = 100
update dbo.SY_AccountCodeTasks set DescriptionShort = 'Office'    where code = 200
update dbo.SY_AccountCodeTasks set DescriptionShort = 'Services'    where code = 300
update dbo.SY_AccountCodeTasks set DescriptionShort = 'Equipment'    where code = 500
update dbo.SY_AccountCodeTasks set DescriptionShort = 'Software'    where code = 600