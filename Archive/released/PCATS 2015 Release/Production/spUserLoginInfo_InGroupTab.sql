Create PROCEDURE [dbo].[spUserLoginInfo_InGroupTab]
@ProjectID		int,
@GroupTab		int
AS
--select distinct USERNAME from DT_UserLoginInfo where  Log_In_Off = 1 and projectID =@ProjectID and datepart(minute,(getdate()-[LogInTime]))<50 

select  USERNAME from DT_UserLoginInfo where  Log_In_Off = 1 and projectID =@ProjectID and GroupTab = @GroupTab


GO


