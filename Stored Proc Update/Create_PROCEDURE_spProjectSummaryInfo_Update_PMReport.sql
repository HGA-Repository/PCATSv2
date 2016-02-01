
Create PROCEDURE [dbo].[spProjectSummaryInfo_Update_PMReport]
@sumID		int,
@projID		int
AS
UPDATE
	DT_ProjectSummaryInfos
SET
	[Deleted] = 0
WHERE
	[ProjSumID] = @sumID and [ProjectID] = @projID



GO


