USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_Insert]    Script Date: 3/31/2015 12:19:25 PM ******/
DROP PROCEDURE [dbo].[spUserLevel_Insert]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_Insert]    Script Date: 3/31/2015 12:19:25 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUserLevel_Insert]
@ID		int	output,
@UserID		int,
@DepartmentID		int,
@SecurityLevelID		int,
@SecurityLevelIDJS	int,
@SecurityLevelIDDRW	int

AS
INSERT INTO
	DT_UserLevels
(
	[UserID],
	[DepartmentID],
	[SecurityLevelID],
	[SecurityLevelIDJS],
	[SecurityLevelIDDRW]
)
VALUES
(
	@UserID,
	@DepartmentID,
	@SecurityLevelID,
	@SecurityLevelIDJS,
	@SecurityLevelIDDRW
)


SELECT @ID = @@IDENTITY

GO

