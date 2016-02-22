USE [RSManpowerSchDb2014]
GO

/****** Object:  StoredProcedure [dbo].[spDrawingLog_ListAll_DeptProj_ForJobStatExcel]    Script Date: 2/16/2016 4:44:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


Alter PROCEDURE [dbo].[spDrawingLog_ListAll_DeptProj_ForJobStatExcel]
@DepartmentID	int,
@ProjectID		int
AS
SELECT
	--[ID],
	DT_DrawingLogs.[ID],
	[DepartmentID],
	[ProjectID],
	[ProjectLeadID],
	[WBS],
	[HGANumber],
	[ClientNumber],
	[CADNumber],
	[ActCodeID],
	DT_ActivityCodes.[Code] as [Code], -- Added 10/27
	[IsTask],
	[DrawingSizeID],
	[BudgetHrs],
	[PercentComplete],
	[RemainingHrs],
	[EarnedHrs],
	[Title1],
	[Title1IsTitle],
	[Title1IsDesc],
	[Title2],
	[Title2IsTitle],
	[Title2IsDesc],
	[Title3],
	[Title3IsTitle],
	[Title3IsDesc],
	[Title4],
	[Title4IsTitle],
	[Title4IsDesc],
	[Title5],
	[Title5IsTitle],
	[Title5IsDesc],
	[Title6],
	[Title6IsTitle],
	[Title6IsDesc],
	[Revision],
	[ReleasedDrawingID],
	[DateRevised],
	[DateDue],
	[DateLate]
FROM
	DT_DrawingLogs left join DT_ActivityCodes on DT_DrawingLogs.ActCodeID = DT_ActivityCodes.ID
WHERE
[DepartmentID] = @DepartmentID and
[ProjectID] = @ProjectID and
	DT_DrawingLogs.[Deleted] = 0
ORDER BY
	--[HGANumber] ASC
	dbo.funcSortPrefix([HGANumber]) ASC, ID asc -- edited 2/17/2016


GO


