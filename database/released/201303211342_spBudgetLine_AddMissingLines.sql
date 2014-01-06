USE [RSManpowerSchDb]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudgetLine_AddMissingLines]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudgetLine_AddMissingLines]
GO

USE [RSManpowerSchDb]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBudgetLine_AddMissingLines]
@BudgetID	int,
@GroupID	int,
@WBS	varchar(5)
AS

DECLARE @now DateTime
set @now = GETDATE()


INSERT INTO DT_BudgetLines
SELECT 
 @BudgetID, @GroupID, 1 , a.Task, a.Category, a.Activity, @WBS, a.ActDesc, 0,0,0,100,0,0,0,	NEWID(),0,	@now, @now
FROM vwAccountCodes a
Left JOIN DT_BudgetLines l on l.Activity = a.Activity and l.BudgetID = @BudgetID and (WBS like @WBS + '')
where a.Discipline = @GroupID and l.ID is null
ORDER BY a.Activity

GO
