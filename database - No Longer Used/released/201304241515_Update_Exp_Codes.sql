
BEGIN TRANSACTION


	INSERT INTO SY_ExpenseAccounts
	SELECT
		ac.ecode, ac.Description, 7, 10, 0.0, 2, RIGHT('000'+ CONVERT(VARCHAR,ac.CODE ),3) , null, null, null, 0, getdate(), getdate()
	FROM SY_ExpenseAccounts ea
	RIGHT JOIN
	(

		SELECT 
		'E' + RIGHT('000'+ CONVERT(VARCHAR,CODE ),3) as ecode
		,c.*
		FROM SY_AccountCodeCategorys c where code < 1000

	) ac on ac.ecode = ea.Code
	where ea.Code is null and (ac.Code % 100) != 0 and ac.Description is not null


	UPDATE SY_ExpenseAccounts
		SET Ordinal = o.r
	FROM SY_ExpenseAccounts a
	join 
	(SELECT id, ROW_NUMBER() OVER(ORDER BY NumberCode) as r FROM SY_ExpenseAccounts) o
	on o.ID = a.ID

COMMIT

