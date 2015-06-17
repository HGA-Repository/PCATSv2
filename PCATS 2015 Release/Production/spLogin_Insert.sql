/****** Object:  StoredProcedure [dbo].[spLogin_Insert]    Script Date: 6/17/2015 8:16:20 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE PROCEDURE [dbo].[spLogin_Insert]
@ID		int	output,
@UserName	Char(20)
--@Data		int

AS
INSERT INTO
	DT_UserLoginInfo
(
	[UserName],
	[DateTime],
	[Log_In_Off]
)
VALUES
(
	@UserName,
	Getdate(),
	1	
)


SELECT @ID = @@IDENTITY


GO


