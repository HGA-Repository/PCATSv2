
--Any Added Or Missing
SELECT * FROM RSManpowerSchDb_dev.dbo.vwVision_Emp_Proj_Time n
FULL OUTER JOIN RSManpowerSchDb.dbo.vwVision_Emp_Proj_Time o on n.PKey = o.PKey
WHERE n.PKey is null or o.PKey is null

SELECT --Diff In RegHrs
n.PKey, n.WBS1,
o.RegHrs - n.RegHrs as diff
FROM RSManpowerSchDb_dev.dbo.vwVision_Emp_Proj_Time n
JOIN RSManpowerSchDb.dbo.vwVision_Emp_Proj_Time o on n.PKey = o.PKey
WHERE o.RegHrs - n.RegHrs <> 0
ORDER BY ABS( o.RegHrs - n.RegHrs )

SELECT --Diff In AcctCode
n.PKey, n.WBS1, n.WBS3,
n.AcctCode, o.AcctCode
FROM RSManpowerSchDb_dev.dbo.vwVision_Emp_Proj_Time n
JOIN RSManpowerSchDb.dbo.vwVision_Emp_Proj_Time o on n.PKey = o.PKey
WHERE n.AcctCode <> o.AcctCode
ORDER BY n.WBS1


SELECT --Diff In GroupCode
n.PKey, n.WBS1, n.WBS3,
n.GroupCode, o.GroupCode
FROM RSManpowerSchDb_dev.dbo.vwVision_Emp_Proj_Time n
JOIN RSManpowerSchDb.dbo.vwVision_Emp_Proj_Time o on n.PKey = o.PKey
WHERE n.GroupCode <> o.GroupCode
ORDER BY n.WBS1


SELECT top 100 * FROM RSManpowerSchDb_dev.dbo.vwVision_Emp_Proj_Time

SELECT GroupCode FROM RSManpowerSchDb.dbo.vwVision_Emp_Proj_Time