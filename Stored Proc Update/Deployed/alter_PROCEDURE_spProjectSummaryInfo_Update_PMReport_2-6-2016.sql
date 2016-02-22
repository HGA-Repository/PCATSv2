/****** Object:  StoredProcedure [dbo].[spProjectSummaryInfo_Update_PMReport]    Script Date: 2/6/2016 7:58:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



alter PROCEDURE [dbo].[spProjectSummaryInfo_Update_PMReport]
@sumID		int,
@projID		int
AS
declare @no int

select @no = (select count(ProjectID) from DT_ProjectSummaryInfos where ProjectID = @projID and ProjSumID = @sumID)
if @no > 0
begin

UPDATE	DT_ProjectSummaryInfos
SET	[Deleted] = 0 WHERE
	[ProjSumID] = @sumID and [ProjectID] = @projID
end

else
begin
insert into DT_ProjectSummaryInfos (ProjSumID,ProjectID)	values (@SumID,@ProjID)
insert into DT_ProjectSummarySch   (ProjSumID,ProjectID)	values (@SumID,@ProjID)
end










