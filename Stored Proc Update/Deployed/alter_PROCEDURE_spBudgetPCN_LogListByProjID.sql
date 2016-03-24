USE [RSManpowerSchDb2014]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetPCN_LogListByProjID]    Script Date: 2/17/2016 1:19:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter PROCEDURE [dbo].[spBudgetPCN_LogListByProjID]
@ProjectID	int
AS
SELECT
	pcn.[ID]
	,pcn.[PCNNumber]
	,ISNULL(pci.[PCINumber],'') AS [PCINumber]
	,pcn.[PCNTitle]
	,[DateSubmittedToClient] = CASE
								WHEN ISNULL(pcn.[DateSubmittedToClient],'1/1/1900') < '1/1/2008' THEN ''
								ELSE CAST(pcn.[DateSubmittedToClient] AS varchar(20))
								END
	,[DateReceivedFromClient] = CASE
								WHEN ISNULL(pcn.[DateReceivedFromClient],'1/1/1900') < '1/1/2008' THEN ''
								ELSE CAST(pcn.[DateReceivedFromClient] AS varchar(20))
								END
	,pcn.[EstimatedEngrHrs]
	,pcn.[EstimatedEngrDlrs]
	,[BudgetMHAdd] = CASE
						WHEN pcn.[PCNStatusID] = 3 THEN pcn.[EstimatedEngrHrs]
						ELSE 0
						END
	,[BudgetDollarAdd] = CASE
						WHEN pcn.[PCNStatusID] = 3 THEN pcn.[EstimatedEngrDlrs]
						ELSE 0
						END
	,[TrendValue] = CASE
						WHEN pcn.[PCNStatusID] = 5 THEN pcn.[EstimatedEngrDlrs]
						ELSE 0
						END
	,ISNULL(pcn.[Comments],'') AS [Comments]
	,stat.[Abbreviation] AS [Status]
FROM
	DT_BudgetPCNs pcn
	LEFT JOIN
	DT_PCIInfos pci ON pcn.[PCIInfoID] = pci.[ID]
	LEFT JOIN
	SY_PCNStatuss stat ON pcn.[PCNStatusID] = stat.[ID]
WHERE
	pcn.[ProjectID] = @ProjectID
	AND
	pcn.[Deleted] = 0
	and
	pcn.PCNStatusID !=4 -- added 2/17/2016
ORDER BY
	pcn.[PCNNumber] ASC

GO


