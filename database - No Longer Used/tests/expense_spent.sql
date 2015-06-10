
/*
SELECT ( SELECT SUM( BillExt ) from vwVision_Expenses where WBS1 = '8.110001.00.0') - 
(SELECT SUM( BillExt ) from RSManpowerSchDb.dbo.vwVision_Expenses where WBS1 = '8.110001.00.0')
SELECT * FROM vwVision_Expenses
SELECT * FROM RSManpowerSchDb.dbo.vwVision_Expenses
*/


SELECT  
p.Number
, (n.BillExt - o.BillExt) as diff
FROM DT_Projects p 
JOIN (
	SELECT 
		p.number
		, SUM( BillExt ) as BillExt
	FROM DT_Projects p 
	JOIN vwVision_Expenses v on WBS1 like p.Number
	GROUP BY p.number
) n on n.Number = p.Number

JOIN (
	SELECT 
		p.number
		, SUM( BillExt ) as BillExt
	FROM DT_Projects p 
	JOIN RSManpowerSchDb.dbo.vwVision_Expenses v on WBS1 like p.Number
	GROUP BY p.number
) o on o.Number = p.Number

order by ABS(n.BillExt - o.BillExt) desc



