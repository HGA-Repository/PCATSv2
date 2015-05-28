USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_ListAll]    Script Date: 3/31/2015 12:19:42 PM ******/
DROP PROCEDURE [dbo].[spUserLevel_ListAll]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_ListAll]    Script Date: 3/31/2015 12:19:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUserLevel_ListAll]
AS
SELECT
	[ID],
	[UserID],
	[DepartmentID],
	[SecurityLevelID],
	[SecurityLevelIDJS],
	[SecurityLevelIDDRW]
FROM
	DT_UserLevels
WHERE
	[Deleted] = 0

GO

