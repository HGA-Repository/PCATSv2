

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetSummary]    Script Date: 03/19/2013 09:21:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_BudgetSummary]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_BudgetSummary]
GO



/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetSummary]    Script Date: 03/19/2013 09:21:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_BudgetSummary]
@BudgetID	int,
@WBS	varchar(5)
AS

DECLARE @IsGovern bit

SELECT @IsGovern = p.[IsGovernment] FROM DT_Projects p LEFT JOIN dt_Budgets b ON p.[ID] = b.[ProjectID] WHERE b.[ID] = @BudgetID

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
		, t.[Description]
		, SUM([TotalDollars]) [LoadedDollars]
		, 0 AS [LoadedRate]
		, SUM([TotalHours]) AS [MHrs]
	FROM DT_BudgetLines b
	left join SY_AccountCodeCategorys cat on b.Category = cat.Code and cat.Deleted = 0
	left join SY_AccountCodeTasks t on t.ID = cat.CategoryID and t.Deleted = 0
	WHERE
		[BudgetID] = @BudgetID
		AND	([Task] / 1000) = 11
		AND [WBS] LIKE @WBS + '%'
		AND b.[Deleted] = 0 
		AND ( [TotalHours] > 0 OR [TotalDollars] > 0 )
	GROUP BY t.[Code], t.[Description]
	ORDER BY t.[Code]
	
	

	

-- Engineering
SELECT
	d.[Code]
	, d.[Description]	
	, SUM([TotalDollars]) [LoadedDollars]
	, 0 AS [LoadedRate]
	, SUM([TotalHours]) AS [MHrs]
FROM DT_BudgetLines b
left join SY_AccountCodeDisciplines d on d.Code = b.DeptGroup and d.Deleted = 0
WHERE
	[BudgetID] = @BudgetID
	AND	(DeptGroup / 1000) != 11
	AND [WBS] LIKE @WBS + '%'
	AND b.[Deleted] = 0 
	AND ( [TotalHours] > 0 OR [TotalDollars] > 0 )
GROUP BY d.[Code], d.[Description]
ORDER BY d.[Code]
	
	

-- Expenses
	SELECT  
		'E' + convert(  varchar, c.Code) as Code
		, c.Description
		,SUM( e.[TotalDollars] ) as [TotalDollars]
		,SUM( e.[MarkupDollars] ) as [MarkupDollars]
		,SUM(0) AS [MHrs]
	FROM
		DT_BudgetExpenseLines e
		left join SY_AccountCodeActivitys a on a.Code = SUBSTRING(e.[Code],2,3) and a.Deleted = 0
		left join SY_AccountCodeCategorys c on (c.Code = SUBSTRING(e.[Code],2,3) OR c.ID = a.CategoryID) and c.Deleted = 0
	WHERE
		[BudgetID] = @BudgetID AND e.[Deleted] = 0
		and (e.TotalDollars > 0 OR e.MarkupDollars > 0)
	GROUP BY c.Code,  c.Description
	
	


GO


