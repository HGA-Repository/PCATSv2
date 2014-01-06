USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwProjectWithDeptsForPipeline]    Script Date: 04/18/2013 09:42:45 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwProjectWithDeptsForPipeline]'))
DROP VIEW [dbo].[vwProjectWithDeptsForPipeline]
GO

USE [RSManpowerSchDb_dev]
GO

/*
SELECT * FROM [dbo].[vwProjectWithDeptsForPipeline]
**/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[vwProjectWithDeptsForPipeline]
AS
SELECT
	p.ID AS projID
	,p.Number AS Project
	,d.ID AS deptID
	,d.AcctGroup
FROM
	(
	SELECT
		[ID]
		,[Number]
	FROM
		DT_Projects
	WHERE
		[IsActive] = 1
		AND [Deleted] = 0
		AND LEFT([Number],2) = '8.'
	) p
	CROSS JOIN
	(
	SELECT [ID] ,[AcctNumber] AS [AcctGroup] FROM sy_AccountGroups2 where AcctNumber in (11000,18000,19000,20000,21000,22000,50000)
	) d

GO


