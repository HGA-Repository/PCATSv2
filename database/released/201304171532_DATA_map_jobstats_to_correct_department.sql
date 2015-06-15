


UPDATE DT_Departments SET AcctGroup = 50000 WHERE  Name = 'PM'


UPDATE DT_DrawingLogs
	set DepartmentID = dep.id
FROM DT_DrawingLogs d
join DT_ActivityCodes c on d.ActCodeID = c.ID
JOIN vwCodeGroups groups on groups.code = c.Code
JOIN DT_Departments dep on dep.AcctGroup = groups.CodeGroup
