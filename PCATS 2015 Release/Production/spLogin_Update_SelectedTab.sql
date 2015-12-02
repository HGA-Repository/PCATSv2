Create PROCEDURE [dbo].[spLogin_Update_SelectedTab]
@ID		int,
@SelectedTab	int

AS
update DT_UserLoginInfo
set 
[GroupTab] = @SelectedTab

where [ID] = @ID


SELECT @ID = @@IDENTITY

GO


