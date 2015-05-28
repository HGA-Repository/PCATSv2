USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_ByUserDept]    Script Date: 3/31/2015 12:18:52 PM ******/
DROP PROCEDURE [dbo].[spUserLevel_ByUserDept]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_ByUserDept]    Script Date: 3/31/2015 12:18:52 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUserLevel_ByUserDept]
@UserID		int,
@DepartmentID	int
AS
SELECT
	[SecurityLevelID],
	ISNULL([PassLevel],0) AS [PassLevel],
	[SecurityLevelIDJS],
	ISNULL([PassLevel],0) AS [PassLevelJS],
	[SecurityLevelIDDRW],
	ISNULL([PassLevel],0) AS [PassLevelDRW]
FROM
	DT_UserLevels  ul
	LEFT JOIN
	SY_SecurityLevels sl ON ul.[SecurityLevelID] = sl.[ID]
WHERE
	ul.[UserID] = @UserID
	AND
	ul.[DepartmentID] = @DepartmentID

GO

