USE [RSManpowerSchDb2014]
GO

/****** Object:  StoredProcedure [dbo].[spProjectSummaryInfo_Update_PMReport]    Script Date: 2/6/2016 10:45:02 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spProjectSummaryInfo_Update_PMReport]
@sumID		int,
@projID		int
AS
declare @no int

select @no = (select count(ProjectID) from DT_ProjectSummaryInfos where ProjectID = @projID and ProjSumID = @sumID)
if @no = 0
begin
--select 'zero'
--declare @max_ProjSumID int
--declare @ID_of_max_ProjSumID int
--select  @max_ProjSumID = (select max(ProjSumID) from DT_ProjectSummaryInfos where ProjectID = @projID)
--select @ID_of_max_ProjSumID = (select id from DT_ProjectSummaryInfos where ProjSumID = @max_ProjSumID)
insert into DT_ProjectSummaryInfos (ProjSumID,ProjectID)	values (@SumID,@ProjID)
--insert into DT_ProjectSummarySch (ProjSumID,ProjectID)	values (@SumID,@ProjID)

--select @ID_of_max_ProjSumID
end

else 
begin
select 'not zero'

UPDATE
	DT_ProjectSummaryInfos
SET
	[Deleted] = 0
WHERE
	[ProjSumID] = @sumID and [ProjectID] = @projID

end





GO


