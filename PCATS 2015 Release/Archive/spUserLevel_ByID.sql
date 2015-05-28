USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_ByID]    Script Date: 3/31/2015 12:18:32 PM ******/
DROP PROCEDURE [dbo].[spUserLevel_ByID]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_ByID]    Script Date: 3/31/2015 12:18:32 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUserLevel_ByID]
@ID		int
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
	[ID] = @ID

GO

