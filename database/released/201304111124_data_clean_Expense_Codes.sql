DELETE FROM DT_BudgetExpenseLines where Code like 'E____' and Quantity = 0

UPDATE DT_BudgetExpenseLines
	SET Code = 'E000'
where Code like 'E____' and Quantity > 0




