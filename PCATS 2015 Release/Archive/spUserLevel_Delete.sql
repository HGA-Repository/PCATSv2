USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_Delete]    Script Date: 3/31/2015 12:19:09 PM ******/
DROP PROCEDURE [dbo].[spUserLevel_Delete]
GO

/****** Object:  StoredProcedure [dbo].[spUserLevel_Delete]    Script Date: 3/31/2015 12:19:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spUserLevel_Delete]
@ID		int
AS
UPDATE
	DT_UserLevels
SET
	[Deleted] = 1
WHERE
	[ID] = @ID

GO

