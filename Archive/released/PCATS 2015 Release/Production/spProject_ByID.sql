ALTER PROCEDURE [dbo].[spProject_ByID]
@ID		int
AS
SELECT
	p.[ID],
	p.[Number],
	p.[Description],
	p.[CustomerID],
	p.[CustomerProjNumber],
	p.[LocationID],
	p.[ProjMngrID],
	p.[RelationshipMngrID],
	p.[RateSchedID],
	p.[Multiplier],
	p.[Overlay],
	p.[Notes],
	p.[DateStart],
	p.[DateEnd],
	p.[IsProposal],
	p.[IsBooked],
	p.[IsActive],
	p.[IsGovernment],
	p.[IsMaster],
	p.[MasterID],
	p.[ReportingStatus],
	p.[POAmount],
	bHrs.[Budget],
	p.[LeadProjMngrID],
	p.[IsFixedRate] -- Added
FROM
	DT_Projects p
	LEFT JOIN
	(
	SELECT
		[ProjectID],
		SUM([BudgetHrs]) AS [Budget]
	FROM
		DT_ProjectBudgets
	WHERE
		[ProjectID] = @ID
	GROUP BY
		[ProjectID]
	) bHrs ON p.[ID] = bHrs.[ProjectID]
WHERE
	p.[ID] = @ID

