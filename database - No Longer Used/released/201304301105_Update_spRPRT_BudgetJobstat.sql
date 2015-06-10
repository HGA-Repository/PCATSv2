USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetJobstat]    Script Date: 04/30/2013 11:03:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_BudgetJobstat]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_BudgetJobstat]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetJobstat]    Script Date: 04/30/2013 11:03:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_BudgetJobstat]
@BudgetID	int,
@WBS	varchar(5)
AS
DECLARE @TOTHRS int

--DECLARE @IsGovern bit
--SELECT @IsGovern = p.[IsGovernment] FROM DT_Projects p LEFT JOIN dt_Budgets b ON p.[ID] = b.[ProjectID] WHERE b.[ID] = @BudgetID

SELECT
	@TOTHRS = SUM([TotalHours])
FROM
	DT_BudgetLines
WHERE
	[BudgetID] = @BudgetID
	AND
	[Quantity] <> 0
	AND
	[WBS] LIKE @WBS + '%'
	AND
	[Deleted] = 0


SELECT
	bl.[Activity]
	,bl.[WBS]
	,bl.[Description]
	,bl.[Quantity]
	,'Each' AS [UOM]
	,bl.[HoursEach]
	,bl.[TotalHours]
	,bl.[LoadedRate]
	,bl.[TotalDollars]
	,cd.[Description] AS [Discipline]
	,@TOTHRS AS [GrandTotalHours]
FROM
	DT_BudgetLines bl
	LEFT JOIN
	SY_AccountCodeDisciplines cd ON bl.[DeptGroup] = cd.[Code]
WHERE
	bl.[BudgetID] = @BudgetID
	AND
	bl.[Quantity] <> 0
	AND
	bl.[WBS] LIKE @WBS + '%'
	--AND
	--cd.[IsGovernment] = @IsGovern
	AND
	bl.[Deleted] = 0
ORDER BY
	bl.[Activity] ASC

GO


