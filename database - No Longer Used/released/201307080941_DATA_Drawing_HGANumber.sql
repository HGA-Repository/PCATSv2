BEGIN TRANSACTION

	SELECT  [ID]  ,[DepartmentID]  ,[ProjectID]  ,[ProjectLeadID]  ,[WBS]  ,[HGANumber]  ,[ClientNumber]  ,[CADNumber]  ,[ActCodeID]  ,[IsTask]  ,[DrawingSizeID]  ,[BudgetHrs]  ,[PercentComplete]  ,[RemainingHrs]  ,[EarnedHrs]  ,[Title1]  ,[Title1IsTitle]  ,[Title1IsDesc]  ,[Title2]  ,[Title2IsTitle]  ,[Title2IsDesc]  ,[Title3]  ,[Title3IsTitle]  ,[Title3IsDesc]  ,[Title4]  ,[Title4IsTitle]  ,[Title4IsDesc]  ,[Title5]  ,[Title5IsTitle]  ,[Title5IsDesc]  ,[Title6]  ,[Title6IsTitle]  ,[Title6IsDesc]  ,[Revision]  ,[ReleasedDrawingID]  ,[DateRevised]  ,[DateDue]  ,[DateLate]  ,[BudgetLineGUID]  ,[Deleted]  ,[DateLastModified]  ,[DateCreated]  INTO codes_v1.DT_DrawingLogs FROM DT_DrawingLogs


	UPDATE DT_DrawingLogs
		SET HGANumber = map.NewCode + RIGHT(dl.HGANumber, LEN(dl.HGANumber) - 4)
	FROM DT_DrawingLogs dl
	join CodeMappings map on substring(dl.HGANumber,1,4) = map.OldCode


	UPDATE DT_DrawingLogs
		SET HGANumber = ac.Code + RIGHT(dl.HGANumber,2)
	FROM DT_DrawingLogs dl
		LEFT JOIN DT_ActivityCodes ac ON dl.[ActCodeID] = ac.[ID]
		where HGANumber like '*-_' and ac.Code is not null
		
	UPDATE DT_DrawingLogs
		SET HGANumber = ac.Code +  RIGHT(dl.HGANumber,3)
	FROM DT_DrawingLogs dl
		LEFT JOIN DT_ActivityCodes ac ON dl.[ActCodeID] = ac.[ID]
		where HGANumber like '*-__' and ac.Code is not null
		

COMMIT