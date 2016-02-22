

USE [RSManpowerSchDb]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetSummary_Pipeline]    Script Date: 03/18/2013 16:28:50 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_BudgetSummary_Pipeline]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_BudgetSummary_Pipeline]
GO

USE [RSManpowerSchDb]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetSummary_Pipeline]    Script Date: 03/18/2013 16:28:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*
EXEC spRPRT_BudgetSummary_Pipeline 4505, ''
*/

CREATE PROCEDURE [dbo].[spRPRT_BudgetSummary_Pipeline]
@BudgetID	int,
@WBS	varchar(5)
AS

-- Budget
SELECT
	b.[ID]
	,b.[ProjectID]
	,b.[Revision]
	,b.[PCNID]
	,b.[IsDefault]
	,b.[IsActive]
	,b.[Description]
	,b.[PreparedBy]
	,b.[Contingency]
	,b.[DateLastModified]
	,rs.[Name] AS [RateSchedule]
	,p.[Multiplier]
	,p.[Overlay]
FROM
	DT_Budgets b
	LEFT JOIN
	DT_Projects p ON b.[ProjectID] = p.[ID]
	LEFT JOIN
	SY_RateSchedules rs ON p.[RateSchedID] = rs.[ID]
WHERE
	b.[ID] = @BudgetID
	
-- General
SELECT
	t.[Code]
	,t.[Description]
	,vals.[LoadedDollars]
	,0 AS [LoadedRate]
	,vals.[MHrs]
FROM
	(
	SELECT
		[Task]
		,SUM([TotalHours]) AS [MHrs]
		,SUM([TotalDollars]) [LoadedDollars]
	FROM
		DT_BudgetLines
	WHERE
		[BudgetID] = @BudgetID
		AND	([Task] / 1000) = 11
		AND [WBS] LIKE @WBS + '%'
		AND [Deleted] = 0
	GROUP BY
		[Task]

	) vals
	LEFT JOIN
	(
	SELECT
		act.[Code]
		,act.[Description]
	FROM
		SY_AccountCodeTasks act
		LEFT JOIN
		SY_AccountCodeDisciplines dis ON act.[CategoryID] = dis.[ID]
	WHERE
		dis.[IsGovernment] = 0
	) t ON vals.[Task] = t.[Code]
ORDER BY
	t.[Code] ASC




SELECT 
	Code AS [Code]
	,t.Description AS [Description]
	,Sum( ISNULL(TotalDollars,0) ) as LoadedDollars
	,0 AS [LoadedRate]
	,Sum( ISNULL(TotalHours,0) ) as [MHrs]
FROM DT_BudgetLines b
left join SY_AccountCodeTasks t on t.Code = b.Task
where b.BudgetID = @BudgetID and (b.Task / 1000) != 11 and ( TotalDollars > 0 OR TotalHours > 0 )
AND [WBS] LIKE @WBS + '%' AND b.[Deleted] = 0
GROUP BY Code, t.Description



-- Expenses
SELECT
	vals.[Code]
	,ag.[AcctGroup] AS [Description]
	,vals.[TotalDollars]
	,vals.[MarkupDollars]
	,0 AS [MHrs]
FROM
	(
	SELECT
		'E' + SUBSTRING([Code],2,3) + '0' AS [Code]
		,SUM([DollarsEach]) AS [DollarsEach]
		,SUM([Quantity]) AS [Quantity]
		,SUM([MarkupDollars]) AS [MarkupDollars]
		,SUM([TotalDollars]) AS [TotalDollars]
	FROM
		DT_BudgetExpenseLines
	WHERE
		[BudgetID] = @BudgetID
		AND
		SUBSTRING([Code],1,2) <> 'EM'
		AND
		[Deleted] = 0
	GROUP BY
		SUBSTRING([Code],2,3)
	) vals
	LEFT JOIN
	(
	SELECT
		'E' + [AcctNumber] AS [AcctNumber]
		,[AcctGroup]
	FROM
		SY_AccountGroups2
	WHERE
		[ReportGroup] = 1
		AND
		[DepartmentID] < 0
		AND [SpecialGroup] = 1
	) ag ON vals.[Code] = ag.[AcctNumber]

GO


