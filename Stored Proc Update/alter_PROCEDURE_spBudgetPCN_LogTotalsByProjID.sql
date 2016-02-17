USE [RSManpowerSchDb2014]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetPCN_LogTotalsByProjID]    Script Date: 2/17/2016 1:27:36 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter PROCEDURE [dbo].[spBudgetPCN_LogTotalsByProjID]
@ProjectID	int
AS
SELECT
	SUM([EstimatedEngrHrs]) AS [EstimatedEngrHrs]
	,SUM([EstimatedEngrDlrs]) AS [EstimatedEngrDlrs]
	,SUM([BudgetMHAdd]) AS [BudgetMHAdd]
	,SUM([BudgetDollarAdd]) AS [BudgetDollarAdd]
	,SUM([TrendValue]) AS [TrendValue]
FROM
	(
	SELECT
		pcn.[EstimatedEngrHrs]
		,pcn.[EstimatedEngrDlrs]
		,[BudgetMHAdd] = CASE
							WHEN pcn.[IsApproved] = 1 THEN pcn.[EstimatedEngrHrs]
							ELSE 0
							END
		,[BudgetDollarAdd] = CASE
							WHEN pcn.[IsApproved] = 1 THEN pcn.[EstimatedEngrDlrs]
							ELSE 0
							END
		,[TrendValue] = CASE
							WHEN pcn.[PrepareControlEstimate] = 1 THEN pcn.[EstimatedEngrDlrs]
							ELSE 0
							END
		,ISNULL(pcn.[Comments],'') AS [Comments]
	FROM
		DT_BudgetPCNs pcn
		LEFT JOIN
		DT_PCIInfos pci ON pcn.[PCIInfoID] = pci.[ID]
	WHERE
		pcn.[ProjectID] = @ProjectID
		AND
		pcn.[Deleted] = 0
		and
	pcn.PCNStatusID !=4 -- added 2/17/2016
	) pcnVals

GO


