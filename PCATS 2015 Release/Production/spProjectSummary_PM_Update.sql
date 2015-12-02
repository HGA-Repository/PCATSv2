
/****** Object:  StoredProcedure [dbo].[spProjectSummary_PM_Update]    Script Date: 8/5/2015 7:18:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spProjectSummary_PM_Update]

@PrevPMID int,
@NewPMID	int,
@ProjectID int

AS
declare @PrevPMSumID int
declare @NewPMSumID int
declare @records int

select @PrevPMSumID = Max(ID) from DT_ProjectSummarys where EmployeeID = @PrevPMID
set @records = (select count(ID) from DT_ProjectSummarys where EmployeeID = @NewPMID)


if (@records = 0)
begin
	insert DT_ProjectSummarys (EmployeeID) values (@NewPMID)
		select @NewPMSumID = Max(ID) from DT_ProjectSummarys where EmployeeID = @NewPMID
		
end

else
begin
	select @NewPMSumID = Max(ID) from DT_ProjectSummarys where EmployeeID = @NewPMID
end
	UPDATE	DT_ProjectSummaryInfos	SET	[ProjSumID] = @NewPMSumID
		WHERE	 ProjSumID = @PrevPMSumID and ProjectID = @ProjectID
	UPDATE	DT_ProjectSummarySch	SET	[ProjSumID] = @NewPMSumID
		WHERE	 ProjSumID = @PrevPMSumID and ProjectID = @ProjectID
		




GO

