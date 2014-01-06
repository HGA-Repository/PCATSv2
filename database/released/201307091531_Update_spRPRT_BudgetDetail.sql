USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetDetail]    Script Date: 07/09/2013 15:12:33 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_BudgetDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_BudgetDetail]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetDetail]    Script Date: 07/09/2013 15:12:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spRPRT_BudgetDetail]
@BudgetID	int,
@WBS	varchar(5)
AS


DECLARE @ProjectID int
SELECT @ProjectID=ProjectID from DT_Budgets where ID = @BudgetID



SELECT DISTINCT code as DeptGroup into #codes FROM (
	SELECT DISTINCT c.[Code] FROM
		SY_AccountCodeDisciplines c
	join DT_ProjectsCodeDisciplines j on c.Code = j.Code AND j.Project_ID = @ProjectID
	where c.Code > 1000
	UNION
	SELECT DISTINCT disc.Code FROM DT_BudgetLines l
	join DT_Budgets b on l.BudgetID = b.ID and b.ProjectID = @ProjectID
	join SY_AccountCodeDisciplines disc on disc.Code = l.DeptGroup
	WHERE Quantity > 0 OR TotalDollars > 0 OR TotalHours > 0
) codes




SELECT
	deptGrps.[DeptGroup]
	,bl.[Task]
	,bl.[Category]
	,bl.[Activity]
	,bl.[Description]
	,bl.[Quantity]
	,bl.[HoursEach]
	,bl.[TotalHours]
	,bl.[LoadedRate]
	,bl.[TotalDollars]
	,bl.[WBS]
	,cd.[Description] AS [Discipline]
	,ac.[TaskDesc] AS [TaskDescription]
	,ac.[CatDesc] AS [CategoryDescription]
	,ac.[ActDesc] AS [ActivityDescription]
FROM #codes deptGrps

LEFT JOIN
	(
	SELECT
		*
	FROM
		DT_BudgetLines
	WHERE
		[BudgetID] = @BudgetID
		AND [Quantity] <> 0
		AND [Deleted] = 0
	) bl ON deptGrps.[DeptGroup] = bl.[DeptGroup]
	LEFT JOIN SY_AccountCodeDisciplines cd ON bl.[DeptGroup] = cd.[Code]
	LEFT JOIN vwAccountCodes ac ON bl.[Activity] = ac.[Activity]
WHERE
	(bl.[BudgetID] = @BudgetID OR bl.[BudgetID] Is NULL)
	AND (bl.[Quantity] <> 0 OR bl.[Quantity] Is NULL)
	AND (bl.[WBS] LIKE @WBS + '%' OR bl.WBS IS NULL)
ORDER BY
	deptGrps.[DeptGroup] ASC, bl.[Activity] ASC




-- list expenses
SELECT 
	bel.[DeptGroup]
	,bel.[EntryLevel]
	,bel.[Code]
	,bel.[Description]
	,bel.[MarkUp]
	,bel.[UOMID]
	,bel.[DollarsEach]
	,bel.[Quantity]
	,bel.[MarkupDollars]
	,bel.[TotalDollars]
	,ISNULL(uom.[Code],'') AS [UOMCode]
FROM
	DT_BudgetExpenseLines bel
	LEFT JOIN
	SY_UnitOfMeasures uom ON bel.[UOMID] = uom.[ID]
WHERE
	bel.[BudgetID] = @BudgetID
	AND
	bel.[Quantity] <> 0
	AND
	bel.[Deleted] = 0
ORDER BY
	bel.[Code] ASC



drop table #codes


GO


