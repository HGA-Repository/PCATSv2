USE [RSManpowerSchDb2014]
GO
/****** Object:  StoredProcedure [dbo].[spLogin_Insert_Test]    Script Date: 4/18/2016 8:49:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[spLogin_Insert]
@ID		int	output,
@UserName	Char(20)
--@Data		int

AS

update DT_UserLoginInfo
set LogOFFTime =Getdate(),
Log_In_Off = 0,
ProjectID = null,
GroupTab = null
where USERNAME = @UserName
INSERT INTO
	DT_UserLoginInfo
(
	[UserName],
	[LogInTime],
	[Log_In_Off]
)
VALUES
(
	@UserName,
	Getdate(),
	1	
)


SELECT @ID = @@IDENTITY




