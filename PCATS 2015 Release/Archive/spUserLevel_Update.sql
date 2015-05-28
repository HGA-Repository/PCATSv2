USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_Update]    Script Date: 3/31/2015 12:20:34 PM ******/
DROP PROCEDURE [dbo].[spUserLevel_Update]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_Update]    Script Date: 3/31/2015 12:20:34 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUserLevel_Update]
@ID		int,
@UserID		int,
@DepartmentID		int,
@SecurityLevelID	int,
@SecurityLevelIDJS	int,
@SecurityLevelIDDRW	int
AS
UPDATE
	DT_UserLevels
SET
	[UserID] = @UserID,
	[DepartmentID] = @DepartmentID,
	[SecurityLevelID] = @SecurityLevelID,
	[SecurityLevelIDJS] = @SecurityLevelIDJS,
	[SecurityLevelIDDRW] = @SecurityLevelIDDRW
WHERE
	[ID] = @ID

GO

