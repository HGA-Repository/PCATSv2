USE [RSManpowerSchDb]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAcctCodeDisc_UpdateForProject]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAcctCodeDisc_UpdateForProject]
GO

USE [RSManpowerSchDb]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


/*

EXEC [dbo].[spAcctCodeDisc_UpdateForProject] 4000,2412,1
EXEC  [dbo].[spAcctCodeDisc_ListForProject] 2412

EXEC [dbo].[spAcctCodeDisc_UpdateForProject] 4000,2412,0
EXEC  [dbo].[spAcctCodeDisc_ListForProject] 2412


*/

CREATE PROCEDURE [dbo].[spAcctCodeDisc_UpdateForProject]
@CODE int,
@PROJECT_ID int,
@enabled int

AS



IF @enabled = 1
	BEGIN
		INSERT INTO DT_ProjectsCodeDisciplines
		SELECT @PROJECT_ID, @CODE	
	END
else
	BEGIN
		DELETE FROM DT_ProjectsCodeDisciplines where Code = @CODE AND Project_ID = @PROJECT_ID
	END


GO


