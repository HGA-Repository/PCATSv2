USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_MaxForUser]    Script Date: 3/31/2015 12:20:18 PM ******/
DROP PROCEDURE [dbo].[spUserLevel_MaxForUser]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_MaxForUser]    Script Date: 3/31/2015 12:20:18 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUserLevel_MaxForUser]
@UserID		int
AS
SELECT
	ISNULL(MIN([PassLevel]),999) AS MaxLvl
FROM
	DT_UserLevels  ul
	LEFT JOIN
	SY_SecurityLevels sl ON ul.[SecurityLevelID] = sl.[ID]
WHERE
	ul.[UserID] = @UserID

GO

