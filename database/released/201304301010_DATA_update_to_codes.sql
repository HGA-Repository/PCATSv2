/**/
BEGIN TRANSACTION

	INSERT INTO SY_AccountCodeCategorys
	SELECT ID, code, 'Rework', 0, GETDATE(),GETDATE() FROM SY_AccountCodeTasks where code = 11900
	
	UPDATE SY_AccountCodeActivitys 
	set CategoryID = (SELECT ID from SY_AccountCodeCategorys where code = 11900)
	where Code = 11999
	
	UPDATE DT_BudgetLines set Category = 11900 where Activity = 11999
	DELETE FROM SY_AccountCodeActivitys where code % 1000 = 599
	
	UPDATE SY_AccountCodeActivitys
		SET CategoryID = (SELECT ID FROM SY_AccountCodeCategorys where code = 15420)
	where code > 15420 and code < 15430
	UPDATE DT_BudgetLines SET Category = 15420 where Activity > 15420 and Activity < 15430

COMMIT






