

BEGIN TRANSACTION 

	DECLARE @now DateTIME
	set @now = GETDATE()


	SELECT DISTINCT NewCode as Code, NewDesc as Description, 1 as EditLevel into #temp_codes FROM CodeMappings
	
	
	Update #temp_codes
	set EditLevel = a.EditLevel
	FROM #temp_codes c 
	JOIN SY_AccountCodeActivitys a on c.code = a.Code	
	
	
	TRUNCATE TABLE SY_AccountCodeDisciplines
	INSERT INTO SY_AccountCodeDisciplines
	SELECT code, Description, 0, 0, @now, @now FROM #temp_codes where code % 1000 = 0 order by code
	
    TRUNCATE TABLE SY_AccountCodeTasks
	INSERT INTO SY_AccountCodeTasks
	SELECT null, code, Description, 0, @now, @now FROM #temp_codes where code % 100 = 0 AND code % 1000 != 0 order by code
	
	TRUNCATE TABLE SY_AccountCodeCategorys
	INSERT INTO SY_AccountCodeCategorys
	SELECT null, code, Description, 0, @now, @now FROM #temp_codes where code % 10 = 0 AND code % 100 != 0 AND code % 1000 != 0 order by code


	TRUNCATE TABLE SY_AccountCodeActivitys
	INSERT INTO SY_AccountCodeActivitys
	SELECT null, code, Description, 1, EditLevel, 0, @now, @now FROM #temp_codes where code % 10 != 0 AND code % 100 != 0 AND code % 1000 != 0 order by code
	
	
	
	/*** NOTE: 50000 codes do not have a category, the extra 000X0 Diget is used in Activitys ***/
	INSERT INTO SY_AccountCodeActivitys	
	SELECT null, code, Description, 1, 1, 0, @now, @now FROM SY_AccountCodeCategorys where Code > 50000 and Code < 60000
	DELETE FROM SY_AccountCodeCategorys where Code > 50000 and Code < 60000
	
	--Add Dummy categories for 50000 codes
	INSERT INTO SY_AccountCodeCategorys	
	SELECT null, code, Description, 0, @now, @now FROM SY_AccountCodeTasks where Code > 50000 and Code < 60000
	
	--Add Dummy categories for Rework
	INSERT INTO SY_AccountCodeCategorys	
	SELECT null, code, Description, 0, @now, @now FROM SY_AccountCodeTasks where Description like 'rework'
	
	
	--Add Dummy categories for (12500, 13600, 17500)
	INSERT INTO SY_AccountCodeCategorys	
	SELECT null, code, Description, 0, @now, @now FROM SY_AccountCodeTasks where code in (12500, 13600, 17500)
	

	/*Move Exceptions to the correct level 12510, 13610 */
	INSERT INTO SY_AccountCodeActivitys
	SELECT null, code, Description, 1, 1, 0, @now, @now FROM SY_AccountCodeCategorys where code in (12510, 13610, 175010)
	DELETE FROM SY_AccountCodeCategorys where code in (12510, 13610, 175010)

	
	
	drop table #temp_codes
	

	
COMMIT




