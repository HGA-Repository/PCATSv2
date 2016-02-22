USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseLine_AddMissingLines]    Script Date: 04/24/2013 15:25:38 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudgetExpenseLine_AddMissingLines]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudgetExpenseLine_AddMissingLines]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseLine_AddMissingLines]    Script Date: 04/24/2013 15:25:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spBudgetExpenseLine_AddMissingLines]
@BudgetID	int,
@GroupID	int,
@WBS	varchar(5)
AS

DECLARE @now DateTime
set @now = GETDATE()



INSERT INTO DT_BudgetExpenseLines

SELECT
	@BudgetID
	, @GroupID
	, 1
	, ea.Code
	, ea.Description
	, ea.DefaultMU
	, ea.UOMID
	, ea.DefaultRate
	, 0 , 0 , 0 , NEWID() , 0 , @now, @now
FROM
	SY_ExpenseAccounts ea
	LEFT JOIN SY_UnitOfMeasures uom ON ea.[UOMID] = uom.[ID]
	LEFT JOIN DT_BudgetExpenseLines b on b.Code = ea.Code and b.BudgetID = @BudgetID and b.DeptGroup = @GroupID
WHERE b.ID is null



/*
SELECT top 100 * FROM DT_BudgetExpenseLines
SELECT top 100 * FROM SY_ExpenseAccounts


INSERT INTO DT_BudgetLines
SELECT 
 @BudgetID, @GroupID, 1 , a.Task, a.Category, a.Activity, @WBS, a.ActDesc, 0,0,0,100,0,0,0,	NEWID(),0,	@now, @now
FROM vwAccountCodes a
Left JOIN DT_BudgetLines l on l.Activity = a.Activity and l.BudgetID = @BudgetID and (WBS like @WBS + '')
where a.Discipline = @GroupID and l.ID is null
ORDER BY a.Activity
*/

GO


