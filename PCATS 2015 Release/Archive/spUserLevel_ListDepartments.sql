USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_ListDepartments]    Script Date: 3/31/2015 12:20:00 PM ******/
DROP PROCEDURE [dbo].[spUserLevel_ListDepartments]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_ListDepartments]    Script Date: 3/31/2015 12:20:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUserLevel_ListDepartments]
@UserID		int
AS
SELECT
	ISNULL(pl.[UserLevelID],0) AS [UserLevelID],
	d.[ID] AS [DeptID],
	d.[Name] AS [Department],
	CAST(CASE WHEN pl.[PassLevel] = 1 Then 1 Else 0	END AS bit) AS [IsAdministrator],
	CAST(CASE WHEN pl.[PassLevel] = 2 Then 1 Else 0	END AS bit) AS [IsModerator],
	CAST(CASE WHEN pl.[PassLevel] = 3 OR pl.[PassLevel] Is NULL	Then 1 Else 0 END AS bit) AS [IsViewOnly],
	CAST(CASE WHEN pl.[PassLevel] = 4 Then 1 Else 0	END AS bit) AS [ModeratorJS],
	CAST(CASE WHEN pl.[PassLevel] = 5 OR pl.[PassLevel] Is NULL	Then 1 Else 0 END AS bit) AS [ViewOnlyJS],
	CAST(CASE WHEN pl.[PassLevel] = 6 Then 1 Else 0	END AS bit) AS [ModeratorDRW],
	CAST(CASE WHEN pl.[PassLevel] = 7 OR pl.[PassLevel] Is NULL	Then 1 Else 0 END AS bit) AS [ViewOnlyDRW]
FROM
	DT_Departments d
	LEFT JOIN
	(
	SELECT
		ul.[ID] AS [UserLevelID],
		ul.[DepartmentID],
		sl.[PassLevel]
	FROM
		DT_UserLevels ul
		LEFT JOIN
		SY_SecurityLevels sl ON ul.[SecurityLevelID] = sl.[ID]
	WHERE
		ul.[UserID] = @UserID
		--ul.[UserID] = 1
		AND
		ul.[Deleted] = 0
	) pl ON d.[ID] = pl.[DepartmentID]
WHERE
	d.[Deleted] = 0
ORDER BY
	d.[Name] ASC

GO

