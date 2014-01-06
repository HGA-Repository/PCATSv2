USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwProjDeptBudgetTotalsForPipeline]    Script Date: 04/18/2013 13:52:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwProjDeptBudgetTotalsForPipeline]'))
DROP VIEW [dbo].[vwProjDeptBudgetTotalsForPipeline]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwProjDeptBudgetTotalsForPipeline]    Script Date: 04/18/2013 13:52:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwProjDeptBudgetTotalsForPipeline]
AS


/*
SELECT * FROM vwProjDeptBudgetTotalsForPipeline
*/

SELECT
	b.Project
	,b.dept AS Dept
	,b.budTot AS budTot
	,ISNULL(b.actTot,0) AS actTot
FROM
	(
	SELECT
		pd.[Project]
		,pd.[AcctGroup] AS dept
		,ISNULL(b.[BudgetHrs],0) AS budTot
		,ISNULL(a.actTot,0) AS actTot
	FROM
		vwProjectWithDeptsForPipeline pd
		LEFT JOIN
		(
		SELECT
			b.Project
			,ag.AcctNumber
			,SUM(b.BudgetHrs) AS [BudgetHrs]
		FROM
			DT_FMSBudgetDATA b
			LEFT JOIN
			SY_AccountGroups2 ag ON b.[Phase] BETWEEN ag.[StartNew] AND ag.[EndNew]
		WHERE
			ISNUMERIC(b.[Phase]) = 1
			--AND ag.[SpecialGroup] = 1
		GROUP BY
			b.Project, ag.AcctNumber
		) b ON pd.Project = b.Project AND pd.AcctGroup = b.AcctNumber
		LEFT JOIN
		(
		SELECT
			td.CProject AS Project
			,ag.AcctNumber AS Dept
			,SUM(td.nreghours + td.nothours) AS actTot
		FROM
			(SELECT [cproject], CAST(cphaseid AS money) AS [cphaseid], [nreghours], [nothours] FROM DT_FMSTimeData WHERE ISNUMERIC([cphaseid]) = 1) td
			LEFT JOIN
			SY_AccountGroups2 ag ON td.cphaseid >= ag.StartNew AND td.cphaseid <= ag.EndNew
		--WHERE
			--ag.[SpecialGroup] = 1
		GROUP BY
			td.cproject, ag.AcctNumber
		) a ON pd.Project = a.Project AND pd.AcctGroup = a.Dept
--	WHERE
--		dbo.funcIsOldJob(pd.[Project]) = 0
	) b
WHERE
	b.dept Is Not NULL

GO


