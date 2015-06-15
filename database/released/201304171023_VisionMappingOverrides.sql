--DROP TABLE dbo.VisionMappingOverrides



/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.VisionMappingOverrides
	(
	id int NOT NULL IDENTITY (1, 1),
	WBS1 varchar(30) NOT NULL,
	WBS3 varchar(7) NOT NULL,
	code int NOT NULL,
	AccountGroup int NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.VisionMappingOverrides ADD CONSTRAINT
	PK_VisionMappingOverrides PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
CREATE UNIQUE NONCLUSTERED INDEX IX_VisionMappingOverrides ON dbo.VisionMappingOverrides
	(
	WBS1,
	WBS3
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE dbo.VisionMappingOverrides SET (LOCK_ESCALATION = TABLE)
GO
COMMIT



BEGIN TRANSACTION


	INSERT INTO dbo.VisionMappingOverrides
	SELECT DISTINCT  WBS1, WBS3, codes.AcctCode,
	ISNULL( isnull(groups.CodeGroup, map2.NewCode), ((codes.AcctCode / 1000) * 1000)) as CodeGroup
	FROM 
	(
		SELECT distinct WBS1, WBS3, convert( int, LEFT([WBS3],4)) as [AcctCode] from (
			SELECT WBS1, WBS3 from [Vision].[HGAVISIONDATABASE].dbo.[LB]
			UNION
			SELECT WBS1, WBS3 from [Vision].[HGAVISIONDATABASE].dbo.[LD] WHERE [TransDate] > '1/1/2007'
		)v
		WHERE LEN([WBS3]) > 2 and ISNUMERIC( LEFT([WBS3],4)) = 1
	) codes
	LEFT JOIN CodeMappings map1 on ISNUMERIC( map1.OldCode) = 1 AND codes.[AcctCode] = map1.OldCode and map1.NewCode is not null
	LEFT JOIN vwCodeGroups groups on map1.NewCode = groups.code

	LEFT JOIN codes_v1.SY2_AccountGroups2 ag_old on codes.AcctCode >= ag_old.StartNew AND codes.AcctCode <= ag_old.EndNew 
	LEFT JOIN CodeMappings map2 on ISNUMERIC( map2.OldCode) = 1 AND convert( int,ag_old.AcctNumber) = convert(int, map2.OldCode) and map2.NewCode is not null


	--cleanup
	UPDATE dbo.VisionMappingOverrides SET AccountGroup = 13000 where AccountGroup = 7000
	
	UPDATE dbo.VisionMappingOverrides 
	SET code = map.NewCode 
	FROM  dbo.VisionMappingOverrides ovr
	join CodeMappings map on map.OldCode = ovr.code and map.NewCode is not null


COMMIT






BEGIN TRANSACTION


	UPDATE dbo.VisionMappingOverrides
	set code = map.NewCode
	from dbo.VisionMappingOverrides v
	JOIN CodeMappings map on map.OldCode = (v.code / 10) * 10 and map.NewCode is not null

	UPDATE dbo.VisionMappingOverrides
	set code = map.NewCode
	from dbo.VisionMappingOverrides v
	JOIN CodeMappings map on map.OldCode = (v.code / 100) * 100 and map.NewCode is not null

	UPDATE dbo.VisionMappingOverrides
	set code = map.NewCode
	from dbo.VisionMappingOverrides v
	JOIN CodeMappings map on map.OldCode = (v.code / 1000) * 1000 and map.NewCode is not null


COMMIT


--update cache tables
--EXEC spUtility_UpdateBudgetsFromFMS
--EXEC spUtility_UpdateTimeFromFMS

