
BEGIN TRANSACTION 

	DECLARE @now DateTIME
	set @now = GETDATE()

	
	--disable the Budget Lines that were not mapped ("UNUSED")
	UPDATE [DT_BudgetLines] set Deleted = 1 where Activity > 999 and Activity < 10000 and TotalDollars = 0
	UPDATE [DT_BudgetLines] set Deleted = 1 where Task > 999 and Task < 10000 and TotalDollars = 0
	UPDATE [DT_BudgetLines] set Deleted = 1 where Category > 999 and Category < 10000 and TotalDollars = 0
	UPDATE [DT_BudgetLines] set Deleted = 1 where DeptGroup > 999 and Category < 10000 and TotalDollars = 0
		
	
	
	--Fill in the holes for missing Categroy IDs
	declare @expence_id int
	SELECT @expence_id = id from SY_AccountCodeDisciplines where Description like 'Expenses'
	INSERT INTO SY_AccountCodeTasks
	SELECT 	@expence_id, '000', 'Expenses', 0, @now, @now
	
	
	insert INTO SY_AccountCodeCategorys
	select
		(SELECT id from SY_AccountCodeTasks where Code = 500)
		, 500
		, (SELECT Description from SY_AccountCodeTasks where Code = 500)
		, 0, @now, @now
		
	
	insert INTO SY_AccountCodeCategorys
	select
		(SELECT id from SY_AccountCodeTasks where Code = 600)
		, 600 , 'Software', 0, @now, @now
		
		
	insert INTO SY_AccountCodeTasks
	select null	, 17900, 'Rework', 0, @now, @now
	
	insert INTO SY_AccountCodeCategorys
	select 
	(SELECT id from SY_AccountCodeTasks where Code = 17900) 
	, 17900, 'Rework', 0, @now, @now
	
	
	
	
	-- Update the Category ID for Every Level
	UPDATE dbo.SY_AccountCodeTasks set CategoryID = null
	UPDATE dbo.SY_AccountCodeTasks
	set categoryID = j.id
	from dbo.SY_AccountCodeTasks t
	join dbo.SY_AccountCodeDisciplines j on j.code / 1000 = t.code / 1000 and j.Deleted = 0
	
	UPDATE dbo.SY_AccountCodeCategorys set CategoryID = null
	UPDATE dbo.SY_AccountCodeCategorys
	set categoryID = j.id
	from dbo.SY_AccountCodeCategorys c
	join dbo.SY_AccountCodeTasks j on j.code / 100 = c.code / 100  and j.Deleted = 0
	
	UPDATE dbo.SY_AccountCodeActivitys set CategoryID = null
	UPDATE dbo.SY_AccountCodeActivitys
	set categoryID = j.id
	from dbo.SY_AccountCodeActivitys a
	join dbo.SY_AccountCodeCategorys j on j.code / 10 = a.code / 10  and j.Deleted = 0
	
    -- 50000 code do not have real categories
	UPDATE dbo.SY_AccountCodeActivitys
	set categoryID = j.id
	from dbo.SY_AccountCodeActivitys a
	join dbo.SY_AccountCodeCategorys j on j.code / 100 = a.code / 100 and a.Code / 10000 = 5	
	
	-- Map Rework codes
	UPDATE dbo.SY_AccountCodeActivitys
	set categoryID = j.id
	from dbo.SY_AccountCodeActivitys a
	join dbo.SY_AccountCodeCategorys j on j.code / 100 = a.code / 100 and a.Description like 'rework'	
	
	--Map "thru" Codes 12501-12599 => 12500
	UPDATE SY_AccountCodeActivitys
	set CategoryID = (SELECT ID FROM SY_AccountCodeCategorys where code = 12500)
	where code >= 12501 and code <= 12599

	--Map "thru" Codes 13601-13699 => 13600
	UPDATE SY_AccountCodeActivitys
	set CategoryID = (SELECT ID FROM SY_AccountCodeCategorys where code = 13600)
	where code >= 13601 and code <= 13699
	
	--Map "thru" Codes 17501-17599 => 17500
	UPDATE SY_AccountCodeActivitys
	set CategoryID = (SELECT ID FROM SY_AccountCodeCategorys where code = 17500)
	where code >= 17501 and code <= 17599
	
	/* Map Exceptions 15420 -> 15410 */
	UPDATE SY_AccountCodeActivitys
	set CategoryID = (SELECT ID FROM SY_AccountCodeCategorys where code = 15410)
	where code / 10 = 1542
	

		

	
	
	
   UPDATE [DT_BudgetLines] set
		[DeptGroup] = d.code
		, Task = t.Code
		, Category = c.Code
   FROM [DT_BudgetLines] b
   JOIN SY_AccountCodeActivitys a on b.Activity = a.Code
   JOIN SY_AccountCodeCategorys c on a.CategoryID = c.ID
   JOIN SY_AccountCodeTasks t on c.CategoryID = t.ID
   JOIN SY_AccountCodeDisciplines d on t.CategoryID = d.ID
   
	


	TRUNCATE TABLE DT_ProjectsCodeDisciplines
	
	INSERT INTO DT_ProjectsCodeDisciplines
	SELECT DISTINCT * FROM (

		SELECT b.ProjectID, l.DeptGroup FROM [DT_BudgetLines] l
		join [DT_Budgets] b on l.BudgetID = b.ID
		where l.Quantity > 0 OR l.TotalDollars > 0 OR l.TotalHours > 0
		
		UNION

		SELECT b.ProjectID, l.DeptGroup FROM [DT_BudgetExpenseLines] l
		join [DT_Budgets] b on l.BudgetID = b.ID 
		where l.Quantity > 0 OR l.TotalDollars > 0 
		
	)c
	
	
	
	

			
	
	
	
COMMIT




