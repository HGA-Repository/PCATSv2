USE [RSManpowerSchDb]
GO


BEGIN TRANSACTION

DECLARE @now DATETIME
SET @now = GETDATE()


INSERT INTO dbo.SY_AccountCodeDisciplines
SELECT NewCode, NewDesc,0,0, @now, @now  from CodeMappings where OldCode is null AND NewCode % 1000 = 0


INSERT INTO SY_AccountCodeTasks
SELECT null, NewCode, NewDesc,0, @now, @now from CodeMappings where OldCode is null AND NewCode % 1000 != 0 AND NewCode % 100 = 0


INSERT INTO [SY_AccountCodeCategorys]
SELECT null, NewCode, NewDesc,0, @now, @now from CodeMappings where OldCode is null AND NewCode % 1000 != 0 AND NewCode % 100 != 0 AND NewCode % 10 = 0


INSERT INTO SY_AccountCodeActivitys
SELECT null, NewCode, NewDesc,1,1,0, @now, @now  from CodeMappings where OldCode is null AND NewCode % 1000 != 0 AND NewCode % 100 != 0 AND NewCode % 10 != 0


COMMIT



















