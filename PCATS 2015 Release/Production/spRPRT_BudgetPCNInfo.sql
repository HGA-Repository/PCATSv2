USE [RSManpowerSchDbBeta2]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetPCNInfo]    Script Date: 7/8/2015 8:32:54 AM ******/
DROP PROCEDURE [dbo].[spRPRT_BudgetPCNInfo]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetPCNInfo]    Script Date: 7/8/2015 8:32:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_BudgetPCNInfo]
@PCNID	int
AS

-- get pcn title information
SELECT
	pcn.[ID]
	,pcn.[DepartmentID]
	,pcn.[ProjectID]
	,pcn.[BudgetID]
	,pcn.[InitiatedByID]
	,pcn.[PCNNumber]
	,pcn.[PCNTitle]
	,pcn.[PCNStatusID]
	,pcn.[DateInitiated]
	,pcn.[RequestedBy]
	,pcn.[DateRequested]
	,pcn.[DescOfChange]
	,pcn.[ReasonDesignError]
	,pcn.[ReasonVendorError]
	,pcn.[ReasonEstimatingError]
	,pcn.[ReasonContractorError]
	,pcn.[ReasonSchedule]
	,pcn.[ReasonScopeAdd]
	,pcn.[ReasonScopeDel]
	,pcn.[ReasonDesignChange]
	,pcn.[ReasonOther]
	,pcn.[OtherReasonDesc]
	,pcn.[EstimatedEngrHrs]
	,pcn.[EstimatedEngrDlrs]
	,pcn.[EstimatedTICDlrs]
	,pcn.[EstimateAccuracy]
	,pcn.[ScheduleImpact]
	,pcn.[IsApproved]
	,pcn.[IsDisapproved]
	,pcn.[PrepareControlEstimate]
	,pcn.[ProjectManagerID]
	,pcn.[DateApproved]
	,pcn.[Comments]
	,c.[Name] AS [Client]
	,dbo.funcGetProjNumber(pcn.[ProjectID]) + '-' + pcn.[PCNNumber] AS [PCNNumber]
	,hrs.[SubHrs]
	,hrs.[SubDlrs]
	,ISNULL(exps.[ExpDlrs],0.0) AS [ExpDlrs]
	,hrs.[SubHrs] AS [TotalHours]
	,hrs.[SubDlrs] + ISNULL(exps.[ExpDlrs],0.0) AS [TotalDollars]
FROM
	DT_BudgetPCNs pcn
	LEFT JOIN
	DT_Projects p ON pcn.[ProjectID] = p.[ID]
	LEFT JOIN
	DT_Customers c ON p.[CustomerID] = c.[ID]
	LEFT JOIN
	(
	SELECT
		[PCNID]
		,SUM([SubtotalHrs]) AS [SubHrs]
		,SUM([SubtotalDlrs]) AS [SubDlrs]
	FROM	
		DT_BudgetPCNHours
	GROUP BY
		[PCNID]
	) hrs ON pcn.[ID] = hrs.[PCNID]
	LEFT JOIN
	(
	SELECT
		[PCNID]
		,SUM(ISNULL([TotalCost],0)) AS [ExpDlrs]
	FROM
		DT_BudgetPCNExpenses
	GROUP BY
		[PCNID]
	) exps ON pcn.[ID] = exps.[PCNID]
WHERE
	pcn.[ID] = @PCNID



-- list pcn hours
SELECT
	[Code],
	[WBS],
	[Description],
	[Quantity],
	[HoursPerItem],
	[Rate],
	[SubtotalHrs],
	[SubtotalDlrs]
FROM
	DT_BudgetPCNHours
WHERE
	[Deleted] = 0
	AND
	[PCNID] = @PCNID
ORDER BY
	[WBS] ASC, [Code] ASC, [Description] ASC


-- list pcn expenses
SELECT
	[Code],
	[Description],
	[DlrsPerItem],
	[NumItems],
	[MUPerc],
	[MarkUp],
	[TotalCost]
FROM
	DT_BudgetPCNExpenses
WHERE
	[Deleted] = 0
	AND
	[PCNID] = @PCNID
ORDER BY
	[Code] ASC, [Description] ASC

GO

