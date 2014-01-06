BEGIN TRANSACTION

	UPDATE DT_DrawingLogs
		SET ActCodeID = ac.ID
	FROM DT_DrawingLogs dl 
	JOIN vwAllAccountCodes alc on alc.Description LIKE dl.Title1
	JOIN DT_ActivityCodes ac on ac.Code = alc.code
	where ActCodeID is null
	and ( select COUNT(vac.Description) from vwAllAccountCodes vac where vac.Description LIKE dl.Title1) = 1
	
	
	UPDATE DT_DrawingLogs
		SET ActCodeID = ac.ID
	FROM DT_DrawingLogs dl 
	JOIN vwAllAccountCodes alc on ISNUMERIC( LEFT(dl.HGANumber,5) ) = 1 AND alc.code = LEFT(dl.HGANumber,5)
	JOIN DT_ActivityCodes ac on ac.Code = alc.code
	where ActCodeID is null
	
	

COMMIT



