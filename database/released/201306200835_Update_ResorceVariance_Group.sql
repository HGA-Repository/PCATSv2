USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_ResourceVarianceByDeptGroup]    Script Date: 06/20/2013 08:34:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_ResourceVarianceByDeptGroup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_ResourceVarianceByDeptGroup]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_ResourceVarianceByDeptGroup]    Script Date: 06/20/2013 08:34:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_ResourceVarianceByDeptGroup]
@DeptGroup  int
AS

SELECT
	d.Name AS [SortVal]
	,ps.AcctGroup AS [DeptGroup]
	,fms.[ProjectType] AS [Indust]
	,proj.Number AS [ProjNumber]
	,proj.Description AS [ProjTitle]
	,cust.Name AS [Customer]
	, JSRmn = CASE 
	    WHEN ps.AcctGroup = 11000 THEN ROUND(ps.MPRmn,0)
		ELSE ROUND(ps.JSRmn,0) END
	,ROUND(ps.MPRmn,0) AS MPRmn
	,ROUND(ps.budTot,0) AS budTot
	,ROUND(ps.ForToCmp,0) AS ForToCmp
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
	LEFT JOIN
	dt_FMSProjectData fms ON proj.[Number] = fms.[cproject]
WHERE
	ps.JSRmn + ps.MPRmn + ps.budTot + ps.ForToCmp > 0
	AND
	ps.AcctGroup = @DeptGroup
	AND
	CHARINDEX('X',proj.Number) < 1
	AND
	proj.[Deleted] = 0
ORDER BY
	ps.AcctGroup ASC
	,proj.Number ASC

GO


