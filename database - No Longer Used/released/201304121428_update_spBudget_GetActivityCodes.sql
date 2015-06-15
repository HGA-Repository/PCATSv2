USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spBudget_GetActivityCodes]    Script Date: 04/12/2013 14:26:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudget_GetActivityCodes]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudget_GetActivityCodes]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spBudget_GetActivityCodes]    Script Date: 04/12/2013 14:26:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBudget_GetActivityCodes]
AS
SELECT
	[Activity] AS [Code]
	,[ActDesc] AS [Description]
FROM
	vwAccountCodes
where [Activity] > 1000
ORDER BY
	[Activity] ASC

GO


