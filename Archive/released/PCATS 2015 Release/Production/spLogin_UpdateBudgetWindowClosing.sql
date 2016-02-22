CREATE PROCEDURE [dbo].[spLogin_UpdateBudgetWindowClosing]
@ID		int

AS
update DT_UserLoginInfo
set 
[ProjectID] = null,
[GroupTab] = null
where [ID] = @ID


GO


