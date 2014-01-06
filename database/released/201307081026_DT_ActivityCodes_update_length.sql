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
CREATE TABLE dbo.Tmp_DT_ActivityCodes
	(
	ID int NOT NULL IDENTITY (1, 1),
	Code varchar(10) NULL,
	Name varchar(100) NULL,
	TotalOn int NULL,
	IsDepartment bit NULL,
	Deleted bit NULL,
	DateLastModified smalldatetime NULL,
	DateCreated smalldatetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_DT_ActivityCodes SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_DT_ActivityCodes ON
GO
IF EXISTS(SELECT * FROM dbo.DT_ActivityCodes)
	 EXEC('INSERT INTO dbo.Tmp_DT_ActivityCodes (ID, Code, Name, TotalOn, IsDepartment, Deleted, DateLastModified, DateCreated)
		SELECT ID, Code, Name, TotalOn, IsDepartment, Deleted, DateLastModified, DateCreated FROM dbo.DT_ActivityCodes WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_DT_ActivityCodes OFF
GO
DROP TABLE dbo.DT_ActivityCodes
GO
EXECUTE sp_rename N'dbo.Tmp_DT_ActivityCodes', N'DT_ActivityCodes', 'OBJECT' 
GO
COMMIT
