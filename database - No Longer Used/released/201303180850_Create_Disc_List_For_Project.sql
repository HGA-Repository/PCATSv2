USE [RSManpowerSchDb]
GO


IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAcctCodeDisc_ListForProject]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAcctCodeDisc_ListForProject]
GO

USE [RSManpowerSchDb]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/*

EXEC  [dbo].[spAcctCodeDisc_ListForProject] 2411
EXEC  [dbo].[spAcctCodeDisc_ListForProject] 1951 /* should work with no codes */

*/

CREATE PROCEDURE [dbo].[spAcctCodeDisc_ListForProject]
@ID	int

AS

SELECT DISTINCT
	c.[Code],
	[Description]
FROM
	SY_AccountCodeDisciplines c
join DT_ProjectsCodeDisciplines j on c.Code = j.Code AND j.Project_ID = @ID
where c.Code > 1000
ORDER BY
	[Code] ASC

GO



