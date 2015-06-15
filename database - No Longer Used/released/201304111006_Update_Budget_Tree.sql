BEGIN TRANSACTION


	UPDATE DT_BudgetLines
		SET Category = cat.CategoryCode
		, Task = task.TaskCode
		, DeptGroup = grp.CodeGroup	
	FROM DT_BudgetLines b
	join vwCodeCategorys cat on b.Activity = cat.code
	join vwCodeTasks task on b.Activity = task.code
	join vwCodeGroups grp on b.Activity = grp.code
	


	--SELECT top 100 * FROM DT_BudgetLines where Activity = 11910 and Quantity > 0 and Deleted = 0 order by BudgetID desc

COMMIT









