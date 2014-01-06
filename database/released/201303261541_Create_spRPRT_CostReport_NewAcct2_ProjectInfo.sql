USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_CostReport_NewAcct2_Vision]    Script Date: 03/25/2013 14:49:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_CostReport_NewAcct2_ProjectInfo]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_CostReport_NewAcct2_ProjectInfo]
GO

USE [RSManpowerSchDb_dev]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_CostReport_NewAcct2_ProjectInfo]
	@Project	varchar(50)
AS

/*
EXEC [dbo].[spRPRT_CostReport_NewAcct2_ProjectInfo] @Project='8.110021.99.0'
*/


SELECT 
	project.Project
	, project_full.id as Project_ID
	 ,project_full.Description
	, customer.Name as [Customer]
	, location.[City] + ', ' + state.[Abbrev] AS [Location]
	, dbo.funcProjMang2(manger.Name) AS [Manager]
	, project.[billtype] + ' ' + project_full.[POAmount] AS BillType	
FROM DT_Projects project_full
LEFT JOIN vwVision_Projects project on project.Project like project_full.Number 
LEFT JOIN DT_Customers customer ON project_full.[CustomerID] = customer.[ID]
LEFT JOIN DT_Locations location ON project_full.[LocationID] = location.[ID]
LEFT JOIN SY_States state ON location.[StateID] = state.[ID]
LEFT JOIN DT_Employees employee ON project_full.[ProjMngrID] = employee.[ID]
LEFT JOIN DT_Employees manger ON manger.ID = project_full.ProjMngrID
where project_full.Number = @Project

GO


