CREATE PROCEDURE [dbo].[spLogin_Update]
@ID		int,
@ProjectID	int

AS
update DT_UserLoginInfo
set 
[ProjectID] = @ProjectID,
[GroupTab] = 11000
where [ID] = @ID

SELECT @ID = @@IDENTITY

GO


