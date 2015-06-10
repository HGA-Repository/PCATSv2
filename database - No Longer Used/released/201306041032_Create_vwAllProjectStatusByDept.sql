USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwProjectStatusByDept]    Script Date: 06/04/2013 10:41:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwAllProjectStatusByDept]'))
DROP VIEW [dbo].[vwAllProjectStatusByDept]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwProjectStatusByDept]    Script Date: 06/04/2013 10:41:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwAllProjectStatusByDept]
AS
SELECT
	p.ProjID
	,p.ProjMngrID
	,p.ProjNumber
	,p.Customer
	,p.ProjMngr
	,buds.AcctGroup
	,[budTot] = CASE
					WHEN ISNULL(buds.budTot,0) < ISNULL(buds.actTot,0) THEN 0
					ELSE ISNULL(buds.budTot,0) - ISNULL(buds.actTot,0)
					END
	,[JSRmn] = CASE
				WHEN ISNULL(buds.AcctGroup,0) = 1000 AND ISNULL(js.JSRemaining,0) <> ISNULL(mp.[MPRemaining],0) THEN ISNULL(mp.[MPRemaining],0)
				ELSE ISNULL(js.JSRemaining,0)
				END
	,ISNULL(mp.MPRemaining,0) AS [MPRmn]
	--,ftc.ftcHrs
	,[ForToCmp] = CASE
				WHEN ftc.ftcHrs Is NULL AND ISNULL(buds.budTot,0) > ISNULL(buds.actTot,0) THEN ISNULL(buds.budTot,0) - ISNULL(buds.actTot,0)
				WHEN ftc.ftcHrs Is NULL AND ISNULL(buds.budTot,0) < ISNULL(buds.actTot,0) THEN 0
				WHEN ISNULL(ftc.[ftcHrs],0) <= ISNULL(buds.actTot,0) THEN 0
				ELSE ISNULL(ftc.[ftcHrs],0) - ISNULL(buds.actTot,0)
				END

	,ftc.ftcHrs AS testFtc
	,buds.actTot AS testAct
	,buds.budTot AS testBud
FROM
	(		-- Project information
	SELECT
		proj.[ID] AS [ProjID]
		,proj.[Number] AS [ProjNumber]
		,proj.[Description] AS [ProjTitle]
		,c.[Name] AS [Customer]
		,proj.[ProjMngrID]
		,emp.[Name] AS [ProjMngr]
	FROM
		DT_Projects proj
		LEFT JOIN
		DT_Employees emp ON proj.ProjMngrID = emp.ID
		LEFT JOIN
		DT_Customers c ON proj.CustomerID = c.ID
	WHERE
		proj.IsActive = 1
		AND proj.Deleted = 0
		AND
		proj.[ID] Not IN (242,621,622,623,656,624,718,719,721,722,723,797,798,806,866,897,898,931,981,1004)
		AND LEFT(proj.[Number],2) <> '1.'
		AND LEFT(proj.[Number],2) <> '2.'
		AND LEFT(proj.[Number],2) <> '3.'
		--AND LEFT(proj.[Number],2) <> '8.'
		--AND LEFT(proj.[Number],2) <> 'P.8'	
		AND LEFT(proj.[Number],2) <> '6.'
		AND LEFT(proj.[Number],3) <> '000'
	) p
	LEFT JOIN
	(		-- Budget and actual information
	SELECT
		pd.projID
		,pd.Project
		,pd.AcctGroup
		,SUM(ISNULL(buds.budTot,0)) AS budTot
		,SUM(ISNULL(buds.actTot,0)) AS actTot
	FROM
		vwProjectWithDepts pd
		LEFT JOIN
		vwProjDeptBudgetTotals buds ON pd.Project = buds.Project AND pd.AcctGroup = buds.Dept
	GROUP BY
		pd.projID, pd.Project, pd.AcctGroup
	) buds ON p.ProjID = buds.projID
	LEFT JOIN
	(		-- Jobstat information
	SELECT
		dl.ProjectID
		,dept.AcctGroup
		,SUM(dl.RemainingHrs) AS JSRemaining
	FROM
		DT_DrawingLogs dl
		LEFT JOIN
		DT_Departments dept ON dl.DepartmentID = dept.ID
	WHERE
		dl.Deleted = 0
		AND
		dl.ActCodeID <> 0
	GROUP BY
		dl.ProjectID, dept.AcctGroup
	) js ON buds.projID = js.ProjectID AND buds.AcctGroup = js.AcctGroup
	LEFT JOIN	-- manpower time
	(
	SELECT
		sh.ProjectID
		,dept.AcctGroup
		,SUM(PHrs) AS MPRemaining
	FROM
		DT_ScheduleHours sh
		LEFT JOIN
		DT_Departments dept ON sh.DepartmentID = dept.ID
		LEFT JOIN
		SY_WeekLists wl ON sh.WeekID = wl.ID
	WHERE
		sh.Deleted = 0
		AND
		wl.EndOfWeek >= GETDATE()
	GROUP BY
		sh.ProjectID, dept.AcctGroup
	) mp ON buds.projID = mp.ProjectID AND buds.AcctGroup = mp.AcctGroup
	LEFT JOIN	-- forecast values
	(
	SELECT
		fu.ProjID
		,dept.AcctGroup
		,SUM(ftc.[ForecastHrs]) AS ftcHrs
	FROM				
		(
		SELECT
			p.ID AS [ProjID]
			,MAX(fu.[ID]) AS LastFU
		FROM
			DT_ForecastUpdates fu
			LEFT JOIN
			DT_Projects p ON fu.Project = p.Number
		WHERE
			fu.Deleted = 0
			AND
			p.Deleted = 0
		GROUP BY
			p.ID
		) fu
		LEFT JOIN
		DT_ForecastToCompletes ftc ON fu.LastFU = ftc.ForecastID
		LEFT JOIN
		DT_Departments dept ON ftc.AccountGroup = dept.AcctGroup
	WHERE
		ftc.Deleted = 0
		AND
		dept.Deleted = 0
		AND
		dept.ID <> 9
	GROUP BY
		fu.ProjID, dept.AcctGroup
	) ftc ON buds.projID = ftc.ProjID AND buds.AcctGroup = ftc.AcctGroup

GO


