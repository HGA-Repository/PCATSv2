USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseLine_ListByBudget]    Script Date: 04/12/2013 14:09:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudgetExpenseLine_ListByBudget]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudgetExpenseLine_ListByBudget]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseLine_ListByBudget]    Script Date: 04/12/2013 14:09:35 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBudgetExpenseLine_ListByBudget]
@BudgetID	int,
@GroupID	int
AS
SELECT
	bel.[ID],
	bel.[Code],
	bel.[Description],
	bel.[MarkUp],
	ISNULL(uom.[Code], 'Each') AS [UOMCode],
	bel.[DollarsEach],
	bel.[Quantity],
	bel.[MarkupDollars],
	bel.[TotalDollars],
	ISNULL(uom.[ID], 0) AS [UOMID],
	ISNULL(ea.[DecimalPlaces], 2) as [DecimalPlaces]
FROM
	DT_BudgetExpenseLines bel
	LEFT JOIN SY_ExpenseAccounts ea ON bel.[Code] = ea.[Code]
	LEFT JOIN SY_UnitOfMeasures uom ON bel.[UOMID] = uom.[ID]
WHERE
	bel.[BudgetID] = @BudgetID
	AND
	bel.[DeptGroup] = @GroupID
	AND
	bel.[Deleted] = 0
ORDER BY
	bel.[Code] ASC

GO


