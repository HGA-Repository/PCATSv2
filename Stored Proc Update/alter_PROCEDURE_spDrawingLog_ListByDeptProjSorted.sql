USE [RSManpowerSchDb2014]
GO

/****** Object:  StoredProcedure [dbo].[spDrawingLog_ListByDeptProjSorted]    Script Date: 2/16/2016 4:43:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter PROCEDURE [dbo].[spDrawingLog_ListByDeptProjSorted]
@DepartmentID	int,
@ProjectID		int,
@WBS		varchar(5),
@SortColumn		int,
@SortAsc		bit
AS
-- sort first column ascending
IF @SortColumn = 1 AND @SortAsc = 1
BEGIN
SELECT
	[ID],
	[ProjectLeadID],
	[WBS],
	[HGANumber],
	[ClientNumber],
	[CADNumber]
FROM	
	DT_DrawingLogs
WHERE
	[DepartmentID] = @DepartmentID
	AND
	[ProjectID] = @ProjectID
	AND
	[WBS] LIKE @WBS + '%'
	AND
	[Deleted] = 0
ORDER BY
	dbo.funcSortPrefix([HGANumber]) ASC, ID asc --2/17
END


-- sort first column descending
IF @SortColumn = 1 AND @SortAsc = 0
BEGIN
SELECT
	[ID],
	[ProjectLeadID],
	[WBS],
	[HGANumber],
	[ClientNumber],
	[CADNumber]
FROM	
	DT_DrawingLogs
WHERE
	[DepartmentID] = @DepartmentID
	AND
	[ProjectID] = @ProjectID
	AND
	[WBS] LIKE @WBS + '%'
	AND
	[Deleted] = 0
ORDER BY
	[HGANumber] DESC
END


-- sort second column ascending
IF @SortColumn = 2 AND @SortAsc = 1
BEGIN
SELECT
	[ID],
	[ProjectLeadID],
	[WBS],
	[HGANumber],
	[ClientNumber],
	[CADNumber]
FROM	
	DT_DrawingLogs
WHERE
	[DepartmentID] = @DepartmentID
	AND
	[ProjectID] = @ProjectID
	AND
	[WBS] LIKE @WBS + '%'
	AND
	[Deleted] = 0
ORDER BY
	[CADNumber] ASC
END


-- sort second column descending
IF @SortColumn = 2 AND @SortAsc = 0
BEGIN
SELECT
	[ID],
	[ProjectLeadID],
	[WBS],
	[HGANumber],
	[ClientNumber],
	[CADNumber]
FROM	
	DT_DrawingLogs
WHERE
	[DepartmentID] = @DepartmentID
	AND
	[ProjectID] = @ProjectID
	AND
	[WBS] LIKE @WBS + '%'
	AND
	[Deleted] = 0
ORDER BY
	[CADNumber] DESC
END


-- sort first column ascending
IF @SortColumn = 0
BEGIN
SELECT
	[ID],
	[ProjectLeadID],
	[WBS],
	[HGANumber],
	[ClientNumber],
	[CADNumber]
FROM	
	DT_DrawingLogs
WHERE
	[DepartmentID] = @DepartmentID
	AND
	[ProjectID] = @ProjectID
	AND
	[WBS] LIKE @WBS + '%'
	AND
	[Deleted] = 0
ORDER BY
	dbo.funcSortPrefix([HGANumber]) ASC
END

GO


