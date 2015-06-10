USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spAcctGroup_ListAll2]    Script Date: 04/12/2013 15:08:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAcctGroup_ListAll2]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAcctGroup_ListAll2]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spAcctGroup_ListAll2]    Script Date: 04/12/2013 15:08:06 ******/
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


	SELECT 
	'E' + RIGHT('000'+ CONVERT(VARCHAR,code),3) as code
	 ,code as n
	 FROM SY_AccountCodeTasks where code < 1000 and code > 0
	 
	 UNION
	 
	 SELECT 
		convert( varchar,code) as code
		, code as n
	 FROM SY_AccountCodeDisciplines where Code > 9999
	 

) s
ORDER BY n



GO


