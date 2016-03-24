

/****** Object:  StoredProcedure [dbo].[spAcctGroup_ListAll2]    Script Date: 04/02/2013 12:10:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAcctGroup_ListAll2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAcctGroup_ListAll2]
GO



/****** Object:  StoredProcedure [dbo].[spAcctGroup_ListAll2]    Script Date: 04/02/2013 12:10:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAcctGroup_ListAll2]
@SpecialGroup	int
AS




SELECT 
code as AcctNumber 
FROM(

	SELECT code FROM SY_AccountCodeDisciplines where Code > 9999
	union 
	SELECT code FROM SY_AccountCodeTasks where code < 1000 and code > 0

) s
ORDER BY AcctNumber


GO


