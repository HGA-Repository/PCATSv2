create PROCEDURE [dbo].[spLogin_Insert]
@ID		int	output,
@UserName	Char(20)
--@Data		int

AS
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



GO


