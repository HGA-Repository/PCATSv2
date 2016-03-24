

DELETE FROM DT_BudgetExpenseLines where Quantity = 0 and TotalDollars = 0

DELETE FROM [SY_ExpenseAccounts]
where Code in ('E210','E520','E540','E550','E560','E590','E596')


UPDATE SY_AccountCodeDisciplines
SET Description = 'Pipeline Engineering'
WHERE code = 18000
