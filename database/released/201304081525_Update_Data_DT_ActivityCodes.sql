

BEGIN TRANSACTION

	DECLARE @now datetime
	set @now = GETDATE()


	TRUNCATE TABLE dbo.DT_ActivityCodes

	INSERT INTO dbo.DT_ActivityCodes
	SELECT al.code, al.Description, null , cleaned.IsDepartment, 0, @now, @now
	FROM (
		SELECT map.NewCode as Code, max( CONVERT(int,IsDepartment) ) as IsDepartment from codes_v1.DT_ActivityCodes ac
		join CodeMappings map on map.OldCode = ac.Code
		where Deleted = 0 and map.NewCode is not null and map.NewCode > 9999
		group by map.NewCode
	) cleaned
	left join vwAllAccountCodes al on cleaned.Code = al.code
	
	
	
	--Remap TotalOn Field using the old data
	Update dbo.DT_ActivityCodes 
		set TotalOn = newtot.id
	FROM dbo.DT_ActivityCodes a
    join ( SELECT ac.TotalOn , map.NewCode as code FROM codes_v1.DT_ActivityCodes ac join CodeMappings map on ac.Code = map.OldCode ) old on old.code = a.Code
    join ( SELECT ac.id, map.NewCode as code FROM codes_v1.DT_ActivityCodes ac join CodeMappings map on ac.Code = map.OldCode )       tot on old.TotalOn = tot.id
    join (select * from dbo.DT_ActivityCodes) newtot on tot.code = newtot.code
    
    
	--remap DT_DrawingLogs ids using the old data
    UPDATE DT_DrawingLogs
    set ActCodeID = ac.id
    from DT_DrawingLogs dl
    join codes_v1.DT_ActivityCodes old on old.id = dl.ActCodeID
    join CodeMappings map on old.Code = map.OldCode
    join DT_ActivityCodes ac on ac.Code = map.NewCode
    
    

	--SELECT * FROM DT_ActivityCodes
	--SELECT * FROM DT_DrawingLogs





COMMIT





