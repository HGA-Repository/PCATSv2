USE [RSManpowerSchDbBeta2]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_PMReport1]    Script Date: 8/5/2015 3:49:44 PM ******/
DROP PROCEDURE [dbo].[spRPRT_PMReport1]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_PMReport1]    Script Date: 8/5/2015 3:49:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [dbo].[spRPRT_PMReport1]
@EmployeeID		int
AS
SELECT
	ps.[ID] AS [ProjSumID]
	,psi.[ProjectID]
	,ps.[ClientFeedback]
	,ps.[QualityImp]
	,ps.[NewWorkProp]
	,ps.[DistributionList]
	,psi.[Schedule]
	,psi.[ActHigh]
	,psi.[StaffNeeds]
	,psi.[CFeedBack]
	,psi.[POAmt]
	,psi.[BilledToDate]
	,psi.[Paidtodate]
	,psi.[Outstanding]
	,psi.[DateLastModified]
	,p.[Number]
--	,p.[Number] + ' ' + p.[Description] AS [Project]
	,p.[Number] + ' ' + p.[Description] + ' (' + c.[Name] + ' - ' + l.[City] + ', ' + s.[Abbrev] + ')' AS [Project]
	,c.[Name] + ' - ' + l.[City] + ', ' + s.[Abbrev] AS [ProjectCustLoc]
FROM
	DT_ProjectSummarys ps
	LEFT JOIN
	DT_ProjectSummaryInfos psi ON ps.[ID] = psi.[ProjSumID]
	LEFT JOIN
	DT_Projects p ON psi.[ProjectID] = p.[ID]
	LEFT JOIN
	DT_Customers c ON p.[CustomerID] = c.[ID]
	LEFT JOIN
	DT_Locations l ON p.[LocationID] = l.[ID]
	LEFT JOIN
	SY_States s ON l.[StateID] = s.[ID]
WHERE
	ps.[EmployeeID] = @EmployeeID
	AND
	ps.[ID] = 
		(
		SELECT
			MAX([ID])
		FROM
			DT_ProjectSummarys
		WHERE
			[EmployeeID] = @EmployeeID
		)
	AND
	ps.[Deleted] = 0
	AND
	psi.[Deleted] = 0
	AND
	p.Deleted = 0 AND p.IsActive = 1 --Added 8/5/2015
	--AND psi.[ProjectID] Not IN (219)
ORDER BY
	p.[Number] ASC

GO

