CREATE PROCEDURE [dbo].[spTransmittalRename]
@ID		int,
@tranNumber varchar (50)
AS
	
 update DT_Transmittals
 set TransmittalNumber = @tranNumber
 where ID = @ID


GO


