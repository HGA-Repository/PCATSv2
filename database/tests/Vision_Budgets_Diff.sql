
SELECT 

new_hotness.Project
, new_hotness.BudgetHrs - old_jank.BudgetHrs
, new_hotness.Budget - old_jank.Budget

FROM
(

SELECT Project, SUM(BudgetHrs) as BudgetHrs, SUM(Budget) as Budget FROM RSManpowerSchDb_dev.dbo.vwVision_Budgets where GroupCode is not null group by Project
) new_hotness
FULL OUTER JOIN
(SELECT Project, SUM(BudgetHrs) as BudgetHrs, SUM(Budget) as Budget FROM RSManpowerSchDb_dev.dbo.vwVision_Budgets where GroupCode is not null group by Project) old_jank 
	on new_hotness.Project = old_jank.Project

ORDER BY ABS(new_hotness.Budget - old_jank.Budget) , ABS(new_hotness.BudgetHrs - old_jank.BudgetHrs)




--SELECT Project, SUM(BudgetHrs) as BudgetHrs, SUM(Budget) as Budget FROM RSManpowerSchDb_dev.dbo.vwVision_Budgets where GroupCode is not null group by Project