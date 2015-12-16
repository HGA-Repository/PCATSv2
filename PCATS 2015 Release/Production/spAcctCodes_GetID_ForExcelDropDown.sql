CREATE PROCEDURE [dbo].[spAcctCodes_GetID_ForExcelDropDown]
@Code		int,
@ID int output
AS
set @ID = (SELECT	[ID] FROM	DT_ActivityCodes WHERE	[Code] = @Code)

GO


