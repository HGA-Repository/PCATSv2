
TRUNCATE TABLE CodeMappings


INSERT INTO CodeMappings
SELECT
convert( int, [Old Code] )
, [Old Desc]
, 1
, convert( int, [New Code] ) + 10000
, [New Desc]
, 2
FROM [RSManpowerSchDb].[dbo].[mappings_raw]

/*
DROP TABLE mappings_raw
*/

