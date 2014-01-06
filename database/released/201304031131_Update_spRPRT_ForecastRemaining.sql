USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_ForecastRemaining]    Script Date: 04/03/2013 10:51:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_ForecastRemaining]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_ForecastRemaining]
GO

USE [RSManpowerSchDb_dev]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_ForecastRemaining]
AS





/*
EXEC [dbo].[spRPRT_ForecastRemaining]
*/



SELECT * FROM (


SELECT 

	proj.Number
	,cust.[Name] AS [Customer]
	,proj.[Description]
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByDept where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 11000),0) as ftc11000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByDept where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 12000),0) as ftc12000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByDept where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 13000),0) as ftc13000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByDept where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 14000),0) as ftc14000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByDept where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 15000),0) as ftc15000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByDept where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 16000),0) as ftc16000
	, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByDept where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 17000),0) as ftc17000
	--, ISNULL((SELECT SUM(ROUND(ForToCmp,0,0)) FROM vwProjectStatusByDept where ForToCmp > 0 and [ProjID] = proj.ID AND AcctGroup = 50000),0) as ftc50000
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
	
	-- remove the pipeline
	AND	LEFT(proj.[Number],2) <> '8.'
	AND	LEFT(proj.[Number],3) <> 'P.8'
	-- remove 'N' jobs
	AND	LEFT(proj.[Number],1) <> 'N'
	
) sums
WHERE ftc11000 + ftc12000 + ftc13000 + ftc14000 + ftc15000 + ftc16000 + ftc17000  > 0
ORDER BY [Number] ASC

GO


