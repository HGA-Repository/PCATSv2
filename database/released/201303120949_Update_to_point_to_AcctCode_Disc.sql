USE [RSManpowerSchDb]
GO

/****** Object:  StoredProcedure [dbo].[spAcctCodeDisc_ListAll]    Script Date: 03/12/2013 09:48:37 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spAcctCodeDisc_ListAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spAcctCodeDisc_ListAll]
GO

USE [RSManpowerSchDb]
GO

/****** Object:  StoredProcedure [dbo].[spAcctCodeDisc_ListAll]    Script Date: 03/12/2013 09:48:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spAcctCodeDisc_ListAll]
AS
SELECT DISTINCT
	[Code],
	[Description]
FROM
	SY_AccountCodeDisciplines
where Deleted = 0 and Code >= 1000
ORDER BY
	[Code] ASC

GO


