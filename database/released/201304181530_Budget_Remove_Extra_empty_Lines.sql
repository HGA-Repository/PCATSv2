--exec spBudgetLine_ListByBudget @BudgetID=5207,@GroupID=11000,@WBS=''

DELETE FROM DT_BudgetLines where Quantity = 0 AND HoursEach = 0 AND TotalHours = 0 AND TotalDollars = 0
DELETE FROM DT_BudgetExpenseLines where Quantity = 0 and TotalDollars = 0

BEGIN TRANSACTION

	INSERT INTO SY_AccountCodeCategorys
	SELECT CategoryID, code, Description,0, DateLastModified, DateCreated FROM SY_AccountCodeTasks where code = 11100
	INSERT INTO SY_AccountCodeActivitys
	SELECT ID, 11100, Description, 0, 0, 0, GETDATE(),GETDATE() FROM SY_AccountCodeCategorys where code = 11100
	UPDATE DT_BudgetLines set Category = 11100 where Activity = 11100
	
	UPDATE SY_AccountCodeActivitys 
	SET CategoryID = (SELECT ID FROM SY_AccountCodeCategorys where code = 12490)
	where code = 12501
	UPDATE DT_BudgetLines set Category = 12490 where Activity = 12501
	UPDATE DT_BudgetLines set Task = 12490 where Activity = 12501
	UPDATE DT_BudgetLines set DeptGroup = 12000 where Activity = 12501


COMMIT







