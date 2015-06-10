
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
ALTER TABLE dbo.SY_AccountCodeTasks
	DROP CONSTRAINT DF_SY_AccountCodeTasks_Deleted
GO
ALTER TABLE dbo.SY_AccountCodeTasks
	DROP CONSTRAINT DF_SY_AccountCodeTasks_DateLastModified
GO
ALTER TABLE dbo.SY_AccountCodeTasks
	DROP CONSTRAINT DF_SY_AccountCodeTasks_DateCreated
GO
CREATE TABLE dbo.Tmp_SY_AccountCodeTasks
	(
	ID int NOT NULL IDENTITY (1, 1),
	CategoryID int NULL,
	Code int NULL,
	Description varchar(100) NULL,
	Deleted bit NULL,
	DateLastModified smalldatetime NULL,
	DateCreated smalldatetime NULL,
	DescriptionShort varchar(15) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_SY_AccountCodeTasks SET (LOCK_ESCALATION = TABLE)
GO
ALTER TABLE dbo.Tmp_SY_AccountCodeTasks ADD CONSTRAINT
	DF_SY_AccountCodeTasks_Deleted DEFAULT ((0)) FOR Deleted
GO
ALTER TABLE dbo.Tmp_SY_AccountCodeTasks ADD CONSTRAINT
	DF_SY_AccountCodeTasks_DateLastModified DEFAULT (getdate()) FOR DateLastModified
GO
ALTER TABLE dbo.Tmp_SY_AccountCodeTasks ADD CONSTRAINT
	DF_SY_AccountCodeTasks_DateCreated DEFAULT (getdate()) FOR DateCreated
GO
SET IDENTITY_INSERT dbo.Tmp_SY_AccountCodeTasks ON
GO
IF EXISTS(SELECT * FROM dbo.SY_AccountCodeTasks)
	 EXEC('INSERT INTO dbo.Tmp_SY_AccountCodeTasks (ID, CategoryID, Code, Description, Deleted, DateLastModified, DateCreated, DescriptionShort)
		SELECT ID, CategoryID, Code, Description, Deleted, DateLastModified, DateCreated, DescriptionShort FROM dbo.SY_AccountCodeTasks WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_SY_AccountCodeTasks OFF
GO
DROP TABLE dbo.SY_AccountCodeTasks
GO
EXECUTE sp_rename N'dbo.Tmp_SY_AccountCodeTasks', N'SY_AccountCodeTasks', 'OBJECT' 
GO
ALTER TABLE dbo.SY_AccountCodeTasks ADD CONSTRAINT
	PK_SY_AccountCodeTasks PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( PAD_INDEX = OFF, FILLFACTOR = 80, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE NONCLUSTERED INDEX IX_SY_AccountCodeTasks ON dbo.SY_AccountCodeTasks
	(
	ID,
	CategoryID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
COMMIT



UPDATE SY_AccountCodeTasks set DescriptionShort = 'Travel' where code = 100
UPDATE SY_AccountCodeTasks set DescriptionShort = 'Other Expenses' where code = 200
UPDATE SY_AccountCodeTasks set DescriptionShort = 'Prof Srvc Sub' where code = 300
UPDATE SY_AccountCodeTasks set DescriptionShort = 'Equipment' where code = 500
UPDATE SY_AccountCodeTasks set DescriptionShort = 'Software' where code = 600

--SELECT * FROM SY_AccountCodeTasks