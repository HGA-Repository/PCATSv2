USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwProjectWithDeptsForPipeline]    Script Date: 04/05/2013 09:41:31 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwProjectWithDeptsForPipeline]'))
DROP VIEW [dbo].[vwProjectWithDeptsForPipeline]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwProjectWithDeptsForPipeline]    Script Date: 04/05/2013 09:41:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[vwProjectWithDeptsForPipeline]
AS


/*
SELECT * FROM [dbo].[vwProjectWithDeptsForPipeline] where projID = 2050
*/


	SELECT 
	p.ID AS projID
	,p.Number AS Project
	, groups.code as AcctGroup
	FROM DT_Projects p
	join DT_ProjectsCodeDisciplines groups on groups.project_id = p.ID
	


GO


