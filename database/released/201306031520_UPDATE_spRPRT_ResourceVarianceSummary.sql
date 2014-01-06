USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_ResourceVarianceSummary]    Script Date: 06/03/2013 15:08:28 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_ResourceVarianceSummary]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_ResourceVarianceSummary]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_ResourceVarianceSummary]    Script Date: 06/03/2013 15:08:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_ResourceVarianceSummary]
AS

SELECT
	d.Name AS [SortVal]
	,SUM(ROUND(ps.JSRmn,0)) AS JSRmn
	,SUM(ROUND(ps.MPRmn,0)) AS MPRmn
	,SUM(ROUND(ps.budTot,0)) AS budTot
	,SUM(ROUND(ps.ForToCmp,0)) AS ForToCmp
	,w.EndOfWeek
FROM
	(
	SELECT
		ps.ProjID
		,ps.AcctGroup
		,SUM(ps.budTot) AS [budTot]
		,SUM(ps.JSRmn) AS [JSRmn]
		,SUM(ps.MPRmn) AS [MPRmn]
		,SUM(ps.ForToCmp) AS [ForToCmp]
	FROM
		vwProjectStatusByDept ps
	GROUP BY
		ps.AcctGroup, ps.ProjID
	) ps
	LEFT JOIN
	DT_Projects proj ON ps.ProjID = proj.ID
	LEFT JOIN
	DT_Employees pm ON proj.ProjMngrID = pm.ID
	LEFT JOIN
	DT_Customers cust ON proj.CustomerID = cust.ID
	LEFT JOIN
	(
	SELECT
		AcctGroup
		,[Name]
	FROM
		DT_Departments
	WHERE
		[Deleted] = 0
		AND
		[ID] <> 9
	) d ON ps.AcctGroup = d.AcctGroup 
	LEFT JOIN
	(
	SELECT
		0 AS [ProjAdd]
		,[EndOfWeek]
	FROM
		SY_WeekLists 
	WHERE
		GETDATE() BETWEEN [StartOfWeek] AND [EndOfWeek]
	) w ON ps.[ProjID] > w.[ProjAdd]
WHERE
	--ps.JSRmn + ps.MPRmn + ps.budTot + ps.ForToCmp > 0
	--AND
	CHARINDEX('X',proj.Number) < 1
	AND
	proj.[Deleted] = 0
--ORDER BY
--	ps.AcctGroup ASC
--	,proj.Number ASC
GROUP BY
	d.Name
	,w.EndOfWeek

GO


