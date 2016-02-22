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
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.E9011', N'Tmp_E110', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.E9012', N'Tmp_E120_1', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.E9013', N'Tmp_E130_2', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.E9014', N'Tmp_E140_3', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.E9015', N'Tmp_E150_4', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.E9016', N'Tmp_E160_5', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.E9017', N'Tmp_E170_6', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.E9018', N'Tmp_E180_7', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.E9019', N'Tmp_E190_8', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.Tmp_E110', N'E110', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.Tmp_E120_1', N'E120', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.Tmp_E130_2', N'E130', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.Tmp_E140_3', N'E140', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.Tmp_E150_4', N'E150', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.Tmp_E160_5', N'E160', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.Tmp_E170_6', N'E170', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.Tmp_E180_7', N'E180', 'COLUMN' 
	GO
	EXECUTE sp_rename N'dbo.DT_BudgetExpenseSheets.Tmp_E190_8', N'E190', 'COLUMN' 
	GO
	ALTER TABLE dbo.DT_BudgetExpenseSheets SET (LOCK_ESCALATION = TABLE)
	GO
	
COMMIT
