
UPDATE DT_BudgetExpenseLines
	set Code = 'E' + m.NewCode
FROM DT_BudgetExpenseLines e
JOIN CodeMappings m on e.Code = 'E' + m.oldCode



UPDATE [DT_BudgetPCNExpenses]
	set Code = 'E' + m.NewCode
FROM [DT_BudgetPCNExpenses] e
JOIN CodeMappings m on e.Code = 'E' + m.oldCode



UPDATE dbo.DT_BudgetPCNHours
	set Code = m.NewCode
FROM dbo.DT_BudgetPCNHours e
JOIN CodeMappings m on e.Code =  m.oldCode


UPDATE dbo.[DT_DepartmentDivisions]
	set [AccountGroup] = m.NewCode
FROM dbo.[DT_DepartmentDivisions] e
JOIN CodeMappings m on e.[AccountGroup] =  m.oldCode


UPDATE dbo.[DT_Departments]
	set [AcctGroup] = m.NewCode
FROM dbo.[DT_Departments] e
JOIN CodeMappings m on e.[AcctGroup] =  m.oldCode


--UPDATE dbo.[dt_VisionProcessTime]
--	set [AcctCode] = m.NewCode
--FROM dbo.[dt_VisionProcessTime] e
--JOIN CodeMappings m on e.[AcctCode] =  m.oldCode


UPDATE dbo.[SY_ExpenseAccounts]
	set [Code] = 'E' + m.NewCode
FROM dbo.[SY_ExpenseAccounts] e
JOIN CodeMappings m on e.[Code] = 'E' + m.oldCode





	



