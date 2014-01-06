
--SELECT * FROM vwAllAccountCodes where Description like 'Future Use'
--SELECT * FROM SY_AccountCodeActivitys where Description like 'Future Use' 

UPDATE SY_AccountCodeActivitys 
	SET Show = 0
where Description like 'Future Use' 