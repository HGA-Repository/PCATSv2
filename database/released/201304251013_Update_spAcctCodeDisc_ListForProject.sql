USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spAcctCodeDisc_ListForProject]    Script Date: 04/25/2013 10:07:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAcctCodeDisc_ListForProject]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAcctCodeDisc_ListForProject]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spAcctCodeDisc_ListForProject]    Script Date: 04/25/2013 10:07:26 ******/
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




SELECT DISTINCT * FROM (

	SELECT DISTINCT
		c.[Code],
		[Description]
	FROM
		SY_AccountCodeDisciplines c
	join DT_ProjectsCodeDisciplines j on c.Code = j.Code AND j.Project_ID = @ID
	where c.Code > 1000

	UNION

	SELECT DISTINCT disc.Code, disc.Description FROM DT_BudgetLines l
	join DT_Budgets b on l.BudgetID = b.ID and b.ProjectID = @ID
	join SY_AccountCodeDisciplines disc on disc.Code = l.DeptGroup
	WHERE Quantity > 0 OR TotalDollars > 0 OR TotalHours > 0

) codes
ORDER BY Code





GO


