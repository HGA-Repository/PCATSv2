BEGIN TRANSACTION

	DECLARE @now datetime
	set @now = GETDATE()
	
	INSERT INTO SY_AccountCodeActivitys
	SELECT
		ID
		, code
		, Description
		, 1,2,0,@now,@now
	 FROM SY_AccountCodeCategorys where code < 200
	

	

	SELECT * into #temp FROM SY_ExpenseAccounts
	TRUNCATE TABLE SY_ExpenseAccounts
	--DELETE FROM SY_ExpenseAccounts where code in ('E9036','E9037')
	
	
	UPDATE SY_ExpenseAccounts
	SET NumberCode = SUBSTRING( code,2,3)
	
	INSERT INTO SY_ExpenseAccounts
	SELECT 
		'E' + RIGHT('000'+ CONVERT(VARCHAR,a.Code),3)
		, isnull( a.Description, '')
		, ea.UOMID
		, ea.DefaultMU
		, ea.DefaultRate
		, isnull( ea.DecimalPlaces, 2)
		, RIGHT('000'+ CONVERT(VARCHAR,a.Code),3)
		, ROW_NUMBER() OVER (ORDER BY a.Code)
		, ea.OldDefaultMU
		, ea.OldDefaultRate
		, 0 , @now, @now
	FROM SY_AccountCodeActivitys a
	left join #temp ea on ea.Code = ('E' + RIGHT('000'+ CONVERT(VARCHAR,a.Code),3))
	where a.Code < 1000
	ORDER BY a.CODE
	
	
	--SELECT * FROM SY_UnitOfMeasures
	
	
	UPDATE SY_ExpenseAccounts
	SET UOMID = el.UOMID
	, DefaultMU = el.MarkUp
	, DefaultRate = el.DollarsEach
	FROM SY_ExpenseAccounts ea
	join ( SELECT top 10000 * from DT_BudgetExpenseLines  where Quantity = 0) el on ea.Description like el.Description




	
	
	Update SY_ExpenseAccounts 
	set UOMID = 7
	, DefaultMU = 10
	, DefaultRate = 0
	where UOMID is null
	
	
	--SELECT * FROM SY_ExpenseAccounts 
	--where UOMID is null
	
	drop table #temp

	--SELECT top 1 * from DT_BudgetExpenseLines where Quantity = 0
	--SELECT * FROM SY_UnitOfMeasures



COMMIT


