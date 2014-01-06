BEGIN TRANSACTION


	UPDATE DT_BudgetLines
		set Activity = 11110, Category = 11110
	Where Task = 11100 and Category = 11100 and Activity = 11100
	
	UPDATE DT_BudgetLines
		set Task = 12400
	Where Task = 12490 and Category = 12490 and Activity = 12501


COMMIT