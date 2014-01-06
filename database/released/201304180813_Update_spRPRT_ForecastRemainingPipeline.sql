USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_ForecastRemainingForPipeline]    Script Date: 04/05/2013 09:33:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_ForecastRemainingForPipeline]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_ForecastRemainingForPipeline]
GO

USE [RSManpowerSchDb_dev]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_ForecastRemainingForPipeline]
AS

/* 
EXEC [spRPRT_ForecastRemainingForPipeline]  

old codes lookup
SELECT * FROM CodeMappings where OldCode in ('1000','8100','8300','8500','8600','8700','8800')
SELECT * FROM codes_v1.SY_AccountCodeTasks where code in ('1000','8100','8300','8500','8600','8700','8800')

old codes
1000
8100	Administration
8300	Engineering
8500	Construction Management/Inspection
8600	Survey
8700	Right of Way/Permits
8800	Environment

New Codes
11000
18000	Pipeline Services
21000	Construction Management/Inspection
19000	Survey
20000	Right of Way/Permits
22000	Environment
50000	Program Management
*/






SELECT * FROM (
SELECT 

	proj.Number
	,cust.[Name] AS [Customer]
	,proj.[Description]
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByPipeline where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 11000),0) as ftc11000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByPipeline where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 18000),0) as ftc12000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByPipeline where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 21000),0) as ftc13000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByPipeline where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 19000),0) as ftc14000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByPipeline where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 20000),0) as ftc15000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByPipeline where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 22000),0) as ftc16000
	--, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByPipeline where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 50000),0) as ftc17000
	,null as ftc17000
	,[Status] = CASE
		WHEN proj.[ReportingStatus] = 1 THEN 'IA'
		WHEN proj.[ReportingStatus] = 2 THEN 'H'
		ELSE 'A'
	END
	,proj.ID as [ProjectID]
	

FROM DT_Projects proj
LEFT JOIN DT_Customers cust ON proj.[CustomerID] = cust.[ID]
WHERE
	
	CHARINDEX('X',proj.Number) < 1
	AND proj.[Deleted] = 0
	AND LEFT(proj.[Number],2) = '8.'
	
) sums
WHERE ftc11000 + ftc12000 + ftc13000 + ftc14000 + ftc15000 + ftc16000  > 0
ORDER BY [Number] ASC


	

GO


