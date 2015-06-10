
SELECT 
	ISNULL( new_hotness.project_id, old_jank.project_id ) as project_id
	, new_hotness.[BillHours] - old_jank.[BillHours] as [BillHours]
	, new_hotness.[BillAmnt] - old_jank.[BillAmnt] as [BillAmnt]
FROM (		

SELECT
  ept.[WBS1] as project_id --, ag.[AcctNumber]
  , SUM(ISNULL(ept.[RegHrs],0) + ISNULL(ept.[OvtHrs],0)) AS [BillHours]
  ,SUM(ISNULL(ept.[Billed],0)) AS [BillAmnt]
FROM vwVision_Emp_Proj_Time ept 
LEFT JOIN SY_AccountGroups2 ag ON ept.[AcctCode] BETWEEN ag.[StartNew] AND ag.[EndNew]
GROUP BY ept.[WBS1]
) new_hotness

FULL outer join

(
		
SELECT
  ept.[WBS1] as project_id --, ag.[AcctNumber]
  , SUM(ISNULL(ept.[RegHrs],0) + ISNULL(ept.[OvtHrs],0)) AS [BillHours]
  ,SUM(ISNULL(ept.[Billed],0)) AS [BillAmnt]
FROM RSManpowerSchDb.dbo.vwVision_Emp_Proj_Time ept 
--LEFT JOIN RSManpowerSchDb.dbo.SY_AccountGroups2 ag ON ept.[AcctCode] BETWEEN ag.[StartNew] AND ag.[EndNew]
WHERE ISNUMERIC( ept.[AcctCode] ) = 1 
GROUP BY ept.[WBS1]

) old_jank on new_hotness.project_id = old_jank.project_id

--ORDER BY ABS( new_hotness.[BillHours] - old_jank.[BillHours]) desc
ORDER BY ABS( new_hotness.[BillAmnt] - old_jank.[BillAmnt]) desc


