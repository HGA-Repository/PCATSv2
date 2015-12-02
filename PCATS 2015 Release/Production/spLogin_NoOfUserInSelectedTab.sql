CREATE PROCEDURE [dbo].[spLogin_NoOfUserInSelectedTab]
@GroupTab		int,
@ProjectID int,
@NoOfUser int output

AS

set @NoOfUser = (select count(ID) from DT_UserLoginInfo where [ProjectID] = @ProjectID and [GroupTab] = @GroupTab)


--SELECT @ID = @@IDENTITY

GO


