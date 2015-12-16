/****** Object:  StoredProcedure [dbo].[spProjectSummary_SummaryInfo_NewProject_Insert]    Script Date: 8/5/2015 7:19:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spProjectSummary_SummaryInfo_NewProject_Insert]
@ID		int	output,

@EmployeeID		int,
@ProjectID		int

AS
declare @records int
declare @SummaryID		int


set @records = (select count(ID) from DT_ProjectSummarys where EmployeeID = @EmployeeID)

if (@records = 0)
begin
	insert into DT_ProjectSummarys (EmployeeID)	values (@EmployeeID)
	select @SummaryID= (select Max(ID) from DT_ProjectSummarys where EmployeeID = @EmployeeID)
end

else
begin
	select @SummaryID= (select Max(ID) from DT_ProjectSummarys where EmployeeID = @EmployeeID)
end


insert into DT_ProjectSummaryInfos (ProjSumID,ProjectID)	values (@SummaryID,@ProjectID)
insert into DT_ProjectSummarySch (ProjSumID,ProjectID)	values (@SummaryID,@ProjectID)

SELECT @ID = @@IDENTITY


GO

