
alter PROCEDURE [dbo].[spProjectSummaryInfos_ByPMID_SumID]
@PMID		int,
@ProjSumID		int
AS
--declare @records int
--set @records =(select count(projectid) from DT_ProjectSummaryInfos where ProjSumID = @ProjSumID)
--if (@records = 0)
if (@ProjSumID = 0)
begin
SELECT
	p.[ID],
	p.[Number],
	p.[Description],
	--p.[CustomerID],
	--p.[CustomerProjNumber],
	--p.[LocationID],
	--p.[ProjMngrID],
	--p.[RelationshipMngrID],
	--p.[RateSchedID],
	--p.[Multiplier],
	--p.[Overlay],
	--p.[Notes],
	--p.[DateStart],
	--p.[DateEnd],
	--p.[IsProposal],
	--p.[IsBooked],
	--p.[IsActive],
	--p.[IsGovernment],
	--p.[IsMaster],
	--p.[MasterID],
	--p.[ReportingStatus],
	c.[Name] AS Customer,
	l.[City] + ', ' + s.[Abbrev] AS Location,
	p.[POAmount],
	p.[LeadProjMngrID]
FROM
	DT_Projects p 
	LEFT JOIN
	DT_Customers c ON p.[CustomerID] = c.[ID]
	LEFT JOIN
	DT_Locations l on p.[LocationID] = l.[ID]
	LEFT JOIN
	SY_States s ON l.[StateID] = s.[ID]
	
WHERE
	p.ProjMngrID = @PMID
	and	p.deleted = 0 	and	p.isactive = 1 
	
ORDER BY
	p.[Number] asc
end
else
begin
SELECT
	p.[ID],
	p.[Number],
	p.[Description],
	--p.[CustomerID],
	--p.[CustomerProjNumber],
	--p.[LocationID],
	--p.[ProjMngrID],
	--p.[RelationshipMngrID],
	--p.[RateSchedID],
	--p.[Multiplier],
	--p.[Overlay],
	--p.[Notes],
	--p.[DateStart],
	--p.[DateEnd],
	--p.[IsProposal],
	--p.[IsBooked],
	--p.[IsActive],
	--p.[IsGovernment],
	--p.[IsMaster],
	--p.[MasterID],
	--p.[ReportingStatus],
	c.[Name] AS Customer,
	l.[City] + ', ' + s.[Abbrev] AS Location,
	p.[POAmount],
	p.[LeadProjMngrID]
FROM
	DT_Projects p 
	LEFT JOIN
	DT_ProjectSummaryInfos su on su.ProjectID = p.ID -- added 2/1/16
	left join
	DT_Customers c ON p.[CustomerID] = c.[ID]
	LEFT JOIN
	DT_Locations l on p.[LocationID] = l.[ID]
	LEFT JOIN
	SY_States s ON l.[StateID] = s.[ID]
	
	
WHERE
	p.ProjMngrID = @PMID
	and	p.deleted = 0 	and	p.isactive = 1 and 
	--p.ID not in (select projectid from DT_ProjectSummaryInfos where ProjSumID = @ProjSumID) -- commented 2/1/16
	su.Deleted = 1
ORDER BY
	p.[Number] asc
	end



GO


