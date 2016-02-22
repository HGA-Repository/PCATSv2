USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetLine_ListByBudget]    Script Date: 04/11/2013 09:30:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudgetLine_ListByBudget]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudgetLine_ListByBudget]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetLine_ListByBudget]    Script Date: 04/11/2013 09:30:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBudgetLine_ListByBudget]
@BudgetID	int,
@GroupID	int,
@WBS	varchar(5)
AS

DECLARE @IsGovern bit
SELECT @IsGovern = p.[IsGovernment] FROM DT_Projects p LEFT JOIN dt_Budgets b ON p.[ID] = b.[ProjectID] WHERE b.[ID] = @BudgetID

SELECT
	bl.[ID],
	bl.[BudgetID],
	bl.[DeptGroup],
	bl.[Task],
	bl.[EntryLevel],
	bl.[WBS],
	ac.[TaskDesc] AS [TaskDesc],
	bl.[Category],
	ISNULL(ac.[CatDesc], ac.[TaskDesc]) AS [CatDesc],
	bl.[Activity],
	ISNULL(ac.[ActDesc], ISNULL(ac.[CatDesc], ac.[TaskDesc])) AS [ActDesc],
	bl.[Description],
	bl.[Quantity],
	bl.[HoursEach],
	bl.[TotalHours],
	bl.[LoadedRate],
	bl.[TotalDollars],
	bl.[BareRate],
	bl.[BareDollars]
FROM
	DT_BudgetLines bl
	LEFT JOIN
	(SELECT * FROM vwAccountCodes) ac ON bl.[Task] = ac.[Task] AND bl.[Category] = ac.[Category] AND bl.[Activity] = ac.[Activity]
WHERE
	bl.[Deleted] = 0
	AND
	bl.[BudgetID] = @BudgetID
	AND
	bl.[DeptGroup] = @GroupID
	AND
	bl.[WBS] LIKE @WBS + '%'
	--AND ac.[IsGovernment] = @IsGovern
ORDER BY
	bl.[Task] ASC, bl.[Category] ASC, bl.[Activity] ASC

GO


