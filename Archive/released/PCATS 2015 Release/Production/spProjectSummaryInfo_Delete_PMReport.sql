USE [RSManpowerSchDbBeta2]
GO

/****** Object:  StoredProcedure [dbo].[spProjectSummaryInfo_Delete_PMReport]    Script Date: 8/5/2015 7:20:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create PROCEDURE [dbo].[spProjectSummaryInfo_Delete_PMReport]
@sumID		int,
@projID		int
AS
UPDATE
	DT_ProjectSummaryInfos
SET
	[Deleted] = 1
WHERE
	[ProjSumID] = @sumID and [ProjectID] = @projID

GO

