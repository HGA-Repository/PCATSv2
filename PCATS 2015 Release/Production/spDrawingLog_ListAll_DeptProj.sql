CREATE PROCEDURE [dbo].[spDrawingLog_ListAll_DeptProj]
@DepartmentID	int,
@ProjectID		int
AS
SELECT
	[ID],
	[DepartmentID],
	[ProjectID],
	[ProjectLeadID],
	[WBS],
	[HGANumber],
	[ClientNumber],
	[CADNumber],
	[ActCodeID],
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
	DT_DrawingLogs
WHERE
[DepartmentID] = @DepartmentID and
[ProjectID] = @ProjectID and
	[Deleted] = 0
ORDER BY
	[HGANumber] ASC


GO


