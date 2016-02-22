/****** Object:  StoredProcedure [dbo].[spRPRT_DrawingLogMainByDeptListProjList]    Script Date: 5/27/2015 11:41:19 AM ******/
DROP PROCEDURE [dbo].[spRPRT_DrawingLogMainByDeptListProjList]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_DrawingLogMainByDeptListProjList]    Script Date: 5/27/2015 11:41:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_DrawingLogMainByDeptListProjList]
@DeptXml	text,
@ProjXml	text,
@SortCode	int
AS
DECLARE @idocStyles1	int
DECLARE @idocStyles2	int

EXEC sp_xml_preparedocument @idocStyles1 OUTPUT, @DeptXml
EXEC sp_xml_preparedocument @idocStyles2 OUTPUT, @ProjXml

IF @SortCode = 1
BEGIN
SELECT
	d.[Description] AS [Department]
	,p.[Description] AS [Project]
	,p.[Number] AS [ProjectNumber]
	,c.[Name] AS [Company]
	,'' AS [Address1]
	,'' AS [Address2]
	,l.[City] + ', ' + s.[Abbrev] AS [CityStateZip]
	,dl.[HGANumber]
	,dl.[CADNumber]
	,ac.[Code] AS [AcctCode]
--	,dl.[Title1]
--	,dl.[Title2]
--	,dl.[Title3]
--	,dl.[Title4]
--	,dl.[Title5]
--	,dl.[Title6]
	,ds.[Code] AS [DrawingSize]
	,dl.[BudgetHrs]
	,dl.[PercentComplete] AS PercComp
	,ISNULL(dl.[Revision],'') + ' ' + ISNULL(rd.[Name],'') AS [Revision]
	,ISNULL(dl.[Revision],'') AS [RevisionNumber]
	,ISNULL(rd.[Name],'') AS [IssuedFor]
	,dl.[DateRevised]
	,dl.[DateDue]
	,dl.[DateLate]
	,dbo.funcTitleAsLine(dl.[Title1],dl.[Title2],dl.[Title3],dl.[Title4],dl.[Title5],dl.[Title6]) AS [Title1]
FROM
	DT_DrawingLogs dl
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
	LEFT JOIN
	DT_ActivityCodes ac ON dl.[ActCodeID] = ac.[ID]
	LEFT JOIN
	SY_DrawingSizes ds ON dl.[DrawingSizeID] = ds.[ID]
	LEFT JOIN
	SY_ReleasedDrawings rd ON dl.[ReleasedDrawingID] = rd.[ID]
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
	dl.[ProjectID] IN
		(
		SELECT
			[ProjID]
		FROM
			OPENXML(@idocStyles2, '/NewDataSet/Proj', 2)
			WITH ([ProjID]	int)
		)
	AND
	dl.[IsTask] = 0
	AND
	dl.[Deleted] = 0
ORDER BY
	d.[Name] ASC, p.[Number] ASC, dl.[HGANumber] ASC
END
ELSE
BEGIN
SELECT
	d.[Description] AS [Department]
	,p.[Description] AS [Project]
	,p.[Number] AS [ProjectNumber]
	,c.[Name] AS [Company]
	,'' AS [Address1]
	,'' AS [Address2]
	,l.[City] + ', ' + s.[Abbrev] AS [CityStateZip]
	,dl.[HGANumber]
	,dl.[CADNumber]
	,ac.[Code] AS [AcctCode]
--	,dl.[Title1]
--	,dl.[Title2]
--	,dl.[Title3]
--	,dl.[Title4]
--	,dl.[Title5]
--	,dl.[Title6]
	,ds.[Code] AS [DrawingSize]
	,dl.[BudgetHrs]
	,dl.[PercentComplete] AS PercComp
	,ISNULL(dl.[Revision],'') + ' ' + ISNULL(rd.[Name],'') AS [Revision]
	,ISNULL(dl.[Revision],'') AS [RevisionNumber]
	,ISNULL(rd.[Name],'') AS [IssuedFor]
	,dl.[DateRevised]
	,dl.[DateDue]
	,dl.[DateLate]
	,dbo.funcTitleAsLine(dl.[Title1],dl.[Title2],dl.[Title3],dl.[Title4],dl.[Title5],dl.[Title6]) AS [Title1]
FROM
	DT_DrawingLogs dl
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
	LEFT JOIN
	DT_ActivityCodes ac ON dl.[ActCodeID] = ac.[ID]
	LEFT JOIN
	SY_DrawingSizes ds ON dl.[DrawingSizeID] = ds.[ID]
	LEFT JOIN
	SY_ReleasedDrawings rd ON dl.[ReleasedDrawingID] = rd.[ID]
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
	dl.[ProjectID] IN
		(
		SELECT
			[ProjID]
		FROM
			OPENXML(@idocStyles2, '/NewDataSet/Proj', 2)
			WITH ([ProjID]	int)
		)
	AND
	dl.[IsTask] = 0
	AND
	dl.[Deleted] = 0
ORDER BY
	d.[Name] ASC, p.[Number] ASC, [dbo].[funcSortExists](dl.[CADNumber]) ASC
END


EXEC sp_xml_removedocument @idocStyles1
EXEC sp_xml_removedocument @idocStyles2

GO

