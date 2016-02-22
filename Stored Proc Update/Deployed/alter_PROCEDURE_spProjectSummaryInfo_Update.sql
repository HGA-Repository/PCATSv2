/****** Object:  StoredProcedure [dbo].[spProjectSummaryInfo_Update]    Script Date: 2/17/2016 3:57:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


alter PROCEDURE [dbo].[spProjectSummaryInfo_Update]
@ID		int,
@ProjSumID		int,
@ProjectID		int,
@Schedule		text,
@ActHigh		text,
@StaffNeeds		text,
@CFeedBack		text,
@POAmt			money,
@BilledToDate	money,
@PaidToDate		money,
@Outstanding	money,--,
@DateLastModified varchar (20)
AS

declare @DLM as datetime
set @DLM = cast(@DateLastModified as smalldatetime)
UPDATE
	DT_ProjectSummaryInfos
SET
	[ProjSumID] = @ProjSumID,
	[ProjectID] = @ProjectID,
	[Schedule] = @Schedule,
	[ActHigh] = @ActHigh,
	[StaffNeeds] = @StaffNeeds,
	[CFeedBack] = @CFeedBack,
	[POAmt] = @POAmt,
	[BilledToDate] = @BilledToDate,
	[PaidToDate] = @PaidToDate,
	[Outstanding] = @Outstanding,--,
	[DateLastModified]= @DLM -- Added 2/17/2016

WHERE
	[ID] = @ID


GO


