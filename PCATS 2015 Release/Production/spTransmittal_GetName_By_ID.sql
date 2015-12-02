CREATE PROCEDURE [dbo].[spTransmittal_GetName_By_ID]
@ID		int,
@tranNumber varchar (50) output
AS
	
 
 set @tranNumber  = (select TransmittalNumber from dt_Transmittals  where ID = @ID)


GO


