/****** Object:  StoredProcedure [dbo].[spLogOff]    Script Date: 6/17/2015 8:17:00 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE PROCEDURE [dbo].[spLogOff]
@ID		int	output,
@UserName		Char(20)
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
	0	
)


SELECT @ID = @@IDENTITY



GO


