USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetSummary]    Script Date: 04/11/2013 10:27:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_BudgetSummary]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_BudgetSummary]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetSummary]    Script Date: 04/11/2013 10:27:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spRPRT_BudgetSummary]
@BudgetID	int,
@WBS	varchar(5)
AS

/*
exec spRPRT_BudgetSummary @BudgetID=4505,@WBS=''
*/

--DECLARE @IsGovern bit
--SELECT @IsGovern = p.[IsGovernment] FROM DT_Projects p LEFT JOIN dt_Budgets b ON p.[ID] = b.[ProjectID] WHERE b.[ID] = @BudgetID

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
		'E' + convert(  varchar, t.Code) as Code
		, t.Description
		,SUM( e.[TotalDollars] ) as [TotalDollars]
		,SUM( e.[MarkupDollars] ) as [MarkupDollars]
		,SUM(0) AS [MHrs]
	FROM
		DT_BudgetExpenseLines e
		left join vwCodeTasks task on task.code = SUBSTRING(e.[Code],2,3)
		left join SY_AccountCodeTasks t on t.Code = task.TaskCode
	WHERE
		[BudgetID] = @BudgetID AND e.[Deleted] = 0
		and (e.TotalDollars > 0 OR e.MarkupDollars > 0)
	GROUP BY t.Code,  t.Description
	
	



GO


