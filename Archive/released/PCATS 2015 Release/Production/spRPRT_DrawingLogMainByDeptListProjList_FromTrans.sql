/****** Object:  StoredProcedure [dbo].[spRPRT_DrawingLogMainByDeptListProj_FromTrans]    Script Date: 5/27/2015 11:38:28 AM ******/
DROP PROCEDURE [dbo].[spRPRT_DrawingLogMainByDeptListProj_FromTrans]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_DrawingLogMainByDeptListProj_FromTrans]    Script Date: 5/27/2015 11:38:28 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_DrawingLogMainByDeptListProj_FromTrans]
@DeptXml	text,
@SortCode	int,
@DrwgSpecVal	int
AS
DECLARE @idocStyles1	int

EXEC sp_xml_preparedocument @idocStyles1 OUTPUT, @DeptXml

IF @SortCode = 1
BEGIN
SELECT
	dl.[ID] AS [DrawingID]
	,d.[Description] AS [Department]
	,p.[Description] AS [Project]
	,p.[Number] AS [ProjectNumber]
	,c.[Name] AS [Company]
	,'' AS [Address1]
	,'' AS [Address2]
	,l.[City] + ', ' + s.[Abbrev] AS [CityStateZip]
	,dl.[CADNumber]
	,dbo.funcTitleAsLine(dl.[Title1],dl.[Title2],dl.[Title3],dl.[Title4],dl.[Title5],dl.[Title6]) AS [Title1]
	,ISNULL(trans.[Revision],'') AS [RevisionNumber]
	,ISNULL(trans.[DateTransmittal],'') AS [IssueDate]
	,ISNULL(trans.[Issued],'') AS [IssuedFor]
	,ISNULL(RIGHT(trans.[TransmittalNumber],3),'') AS [TransNo]
FROM
	DT_DrawingLogs dl
	LEFT JOIN
	(
	SELECT
		tr.[DrawingID]
		,d.[Revision]
		,t.[DateTransmittal]
		,t.[TransmittalNumber]
		,[Issued] = CASE
						WHEN t.[ForPreliminary] = 1 THEN 'Preliminary'
						WHEN t.[ForApproval] = 1 THEN 'Approval'
						WHEN t.[ForBidding] = 1 THEN 'Bidding'
						WHEN t.[ForConstruction] = 1 THEN 'Constr'
						WHEN t.[ForNoted] = 1 THEN t.[ForNotedOther]
					END
	FROM
		dt_Transmittals t
		LEFT JOIN
		dt_TransmittalDocs d ON t.[ID] = d.[TransmittalID]
		LEFT JOIN
		dt_TransmittalReleaseDrwgs tr ON d.[ReleaseDocID] = tr.[ID]
	WHERE
		t.[Deleted] = 0
	) trans ON dl.[ID] = trans.[DrawingID]
	LEFT JOIN
	DT_Departments d ON dl.[DepartmentID] = d.[ID]
	LEFT JOIN
	DT_Projects p ON dl.[ProjectID] = p.[ID]
	LEFT JOIN
	DT_Customers c ON p.[CustomerID] = c.[ID]
	LEFT JOIN
	DT_Locations l ON p.[LocationID] = l.[ID]
	LEFT JOIN
	SY_States s ON l.[StateID] = s.[ID]
WHERE
	dl.[DepartmentID] IN
		(
		SELECT
			[DeptID]
		FROM
			OPENXML(@idocStyles1, '/NewDataSet/Dept', 2)
			WITH ([DeptID]	int)
		)
	AND
	dl.[IsTask] = @DrwgSpecVal
	AND
	dl.[Deleted] = 0
ORDER BY
	d.[AcctGroup] ASC, p.[Number] ASC, dl.[CADNumber] ASC, [dbo].funcGetHGADrwgSort(dl.[HGANumber]) ASC, trans.[DateTransmittal] DESC
END
ELSE
BEGIN
SELECT
	dl.[ID] AS [DrawingID]
	,d.[Description] AS [Department]
	,p.[Description] AS [Project]
	,p.[Number] AS [ProjectNumber]
	,c.[Name] AS [Company]
	,'' AS [Address1]
	,'' AS [Address2]
	,l.[City] + ', ' + s.[Abbrev] AS [CityStateZip]
	,dl.[CADNumber]
	,dbo.funcTitleAsLine(dl.[Title1],dl.[Title2],dl.[Title3],dl.[Title4],dl.[Title5],dl.[Title6]) AS [Title1]
	,ISNULL(trans.[Revision],'') AS [RevisionNumber]
	,ISNULL(trans.[DateTransmittal],'') AS [IssueDate]
	,ISNULL(trans.[Issued],'') AS [IssuedFor]
	,ISNULL(RIGHT(trans.[TransmittalNumber],3),'') AS [TransNo]
FROM
	DT_DrawingLogs dl
	LEFT JOIN
	(
	SELECT
		tr.[DrawingID]
		,d.[Revision]
		,t.[DateTransmittal]
		,t.[TransmittalNumber]
		,[Issued] = CASE
						WHEN t.[ForPreliminary] = 1 THEN 'Preliminary'
						WHEN t.[ForApproval] = 1 THEN 'Approval'
						WHEN t.[ForBidding] = 1 THEN 'Bidding'
						WHEN t.[ForConstruction] = 1 THEN 'Constr'
						WHEN t.[ForNoted] = 1 THEN t.[ForNotedOther]
					END
	FROM
		dt_Transmittals t
		LEFT JOIN
		dt_TransmittalDocs d ON t.[ID] = d.[TransmittalID]
		LEFT JOIN
		dt_TransmittalReleaseDrwgs tr ON d.[ReleaseDocID] = tr.[ID]
	WHERE
		t.[Deleted] = 0
	) trans ON dl.[ID] = trans.[DrawingID]
	LEFT JOIN
	DT_Departments d ON dl.[DepartmentID] = d.[ID]
	LEFT JOIN
	DT_Projects p ON dl.[ProjectID] = p.[ID]
	LEFT JOIN
	DT_Customers c ON p.[CustomerID] = c.[ID]
	LEFT JOIN
	DT_Locations l ON p.[LocationID] = l.[ID]
	LEFT JOIN
	SY_States s ON l.[StateID] = s.[ID]
WHERE
	dl.[DepartmentID] IN
		(
		SELECT
			[DeptID]
		FROM
			OPENXML(@idocStyles1, '/NewDataSet/Dept', 2)
			WITH ([DeptID]	int)
		)
	AND
	dl.[IsTask] = @DrwgSpecVal
	AND
	dl.[Deleted] = 0
ORDER BY
	d.[AcctGroup] ASC, p.[Number] ASC, dl.[CADNumber] ASC, [dbo].funcGetHGADrwgSort(dl.[HGANumber]) ASC, trans.[DateTransmittal] DESC
END


EXEC sp_xml_removedocument @idocStyles1

GO

