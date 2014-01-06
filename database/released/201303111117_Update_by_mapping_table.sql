

--ALTER TABLE dbo.SY_AccountCodeActivitys RENAME TO dbo.SY_AccountCodeActivitys_old
--ALTER TABLE dbo.SY_AccountCodeCategorys RENAME TO dbo.SY_AccountCodeCategorys_old
--ALTER TABLE dbo.SY_AccountCodeDisciplines RENAME TO dbo.SY_AccountCodeDisciplines_old
--ALTER TABLE dbo.SY_AccountCodeTasks RENAME TO dbo.SY_AccountCodeTasks_old


UPDATE dbo.SY_AccountCodeActivitys
SET Code = m.NewCode
, Description = m.newDesc
FROM dbo.SY_AccountCodeActivitys c
join dbo.CodeMappings m on c.Code = m.OldCode


UPDATE dbo.SY_AccountCodeCategorys
SET Code = m.NewCode
, Description = m.newDesc
FROM dbo.SY_AccountCodeCategorys c
join dbo.CodeMappings m on c.Code = m.OldCode


UPDATE dbo.SY_AccountCodeDisciplines
SET Code = m.NewCode
, Description = m.newDesc
FROM dbo.SY_AccountCodeDisciplines c
join dbo.CodeMappings m on c.Code = m.OldCode


UPDATE dbo.SY_AccountCodeTasks
SET Code = m.NewCode
, Description = m.newDesc
FROM dbo.SY_AccountCodeTasks c
join dbo.CodeMappings m on c.Code = m.OldCode



UPDATE dbo.DT_BudgetLines
SET Task = ctask.NewCode
, Category = ccat.NewCode
, Activity = cact.NewCode
, DeptGroup = cgroup.NewCode
FROM dbo.DT_BudgetLines c
join dbo.CodeMappings ctask on c.Task = ctask.OldCode
join dbo.CodeMappings ccat on c.Category = ccat.OldCode
join dbo.CodeMappings cact on c.Activity = cact.OldCode
join dbo.CodeMappings cgroup on c.DeptGroup = cgroup.OldCode



UPDATE dbo.[DT_ActivityCodes]
SET Code = m.NewCode
FROM dbo.[DT_ActivityCodes] c
join dbo.CodeMappings m on c.Code = m.OldCode 




UPDATE dbo.[DT_BudgetExpenseLines]
SET [DeptGroup] = m.NewCode
FROM dbo.[DT_BudgetExpenseLines] c
join dbo.CodeMappings m on c.[DeptGroup] = m.OldCode 




UPDATE dbo.DT_BudgetExpenseSheets
SET [DeptGroup] = m.NewCode
FROM dbo.DT_BudgetExpenseSheets c
join dbo.CodeMappings m on c.[DeptGroup] = m.OldCode 




UPDATE dbo.[DT_BudgetExportStagings]
SET [DeptGroup] = m.NewCode
FROM dbo.[DT_BudgetExportStagings] c
join dbo.CodeMappings m on c.[DeptGroup] = m.OldCode 

UPDATE dbo.[DT_BudgetExportStagings]
SET Task = m.NewCode
FROM dbo.[DT_BudgetExportStagings] c
join dbo.CodeMappings m on c.Task = m.OldCode 

UPDATE dbo.[DT_BudgetExportStagings]
SET [Category] = m.NewCode
FROM dbo.[DT_BudgetExportStagings] c
join dbo.CodeMappings m on c.[Category] = m.OldCode 

UPDATE dbo.[DT_BudgetExportStagings]
SET [Activity] = m.NewCode
FROM dbo.[DT_BudgetExportStagings] c
join dbo.CodeMappings m on c.[Activity] = m.OldCode 



UPDATE dbo.[DT_BudgetImportTmp]
SET [Code] = m.NewCode
FROM dbo.[DT_BudgetImportTmp] c
join dbo.CodeMappings m on c.[Code] = m.OldCode 



UPDATE dbo.[DT_BudgetWorksheets]
SET [DeptGroup] = m.NewCode
FROM dbo.[DT_BudgetWorksheets] c
join dbo.CodeMappings m on c.[DeptGroup] = m.OldCode 



UPDATE dbo.[DT_ForecastToCompletes]
SET [AccountGroup] = m.NewCode
FROM dbo.[DT_ForecastToCompletes] c
join dbo.CodeMappings m on c.[AccountGroup] = m.OldCode 



UPDATE dbo.[DT_ForecastToCompletes]
SET [AccountGroup] = m.NewCode
FROM dbo.[DT_ForecastToCompletes] c
join dbo.CodeMappings m on c.[AccountGroup] = m.OldCode 



--UPDATE dbo.Sheet1
--SET Code = m.NewCode
--, Name = m.NewDesc
--FROM dbo.Sheet1 c
--join dbo.CodeMappings m on c.Code = m.OldCode 


UPDATE dbo.SY_AccountGroups_old
SET AcctNumber = m.NewCode
, AcctGroup = m.NewDesc
FROM dbo.SY_AccountGroups_old c
join dbo.CodeMappings m on c.AcctNumber = m.OldCode 



UPDATE dbo.SY_AccountGroups2
SET AcctNumber = m.NewCode
, AcctGroup = m.NewDesc
FROM dbo.SY_AccountGroups2 c
join dbo.CodeMappings m on c.AcctNumber = m.OldCode




UPDATE dbo.sy_VisionToChartExpenses
SET AccountCode = m.NewCode
FROM dbo.sy_VisionToChartExpenses c
join dbo.CodeMappings m on c.AccountCode = m.OldCode



































