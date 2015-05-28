USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_DrawingLogByDeptList]    Script Date: 5/27/2015 11:35:54 AM ******/
DROP PROCEDURE [dbo].[spRPRT_DrawingLogByDeptList]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_DrawingLogByDeptList]    Script Date: 5/27/2015 11:35:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_DrawingLogByDeptList]
@DeptXML	text,
@SortCode	int
AS
DECLARE @idocStyles	int

EXEC sp_xml_preparedocument @idocStyles OUTPUT, @DeptXML

IF @SortCode = 1
BEGIN
SELECT
	d.[Name] AS Dept
	,p.[Number] AS Project
	,p.[Description] as [Description]
	,c.[Name] AS Customer
	,(l.[City] + ', ' + s.[Abbrev]) AS Location
	,e.[Name] AS Lead
	,dl.[HGANumber]
	,dl.[CadNumber]
	,ac.[Code] AS ActivityCode
	,dl.[IsTask]
	,ds.[Size] As DwgSize
	,dl.[BudgetHrs]
	,dl.[PercentComplete]
	,dl.[RemainingHrs]
	,dl.[EarnedHrs]
	,ISNULL(t.[Title],'') + '/' + ISNULL(t.[Desc],'') AS [Title]
FROM
	DT_DrawingLogs dl
	LEFT JOIN
	DT_Departments d ON dl.[DepartmentID] = d.[ID]
	LEFT JOIN
	DT_Projects p ON dl.[ProjectID] = p.[ID]
	LEFT JOIN
	DT_Employees e ON dl.[ProjectLeadID] = e.[ID]
	LEFT JOIN
	DT_ActivityCodes ac ON dl.[ActCodeID] = ac.[ID]
	LEFT JOIN
	SY_DrawingSizes ds ON dl.[DrawingSizeID] = ds.[ID]
	LEFT JOIN
	(
	SELECT
		d.[ID]
		,[Title] = CASE
					WHEN d.[Title6IsTitle] = 1 THEN d.[Title6]
					WHEN d.[Title5IsTitle] = 1 THEN d.[Title5]
					WHEN d.[Title4IsTitle] = 1 THEN d.[Title4]
					WHEN d.[Title3IsTitle] = 1 THEN d.[Title3]
					WHEN d.[Title2IsTitle] = 1 THEN d.[Title2]
					ELSE d.[Title1]
		END
		,[Desc] = CASE
					WHEN d.[Title6IsDesc] = 1 THEN d.[Title6]
					WHEN d.[Title5IsDesc] = 1 THEN d.[Title5]
					WHEN d.[Title4IsDesc] = 1 THEN d.[Title4]
					WHEN d.[Title3IsDesc] = 1 THEN d.[Title3]
					WHEN d.[Title2IsDesc] = 1 THEN d.[Title2]
					ELSE d.[Title1]
		END
	FROM
		DT_DrawingLogs d
	WHERE
		d.[Deleted] = 0
	) t ON dl.[ID] = t.[ID]
	LEFT JOIN
	DT_Customers c ON p.[CustomerID] = c.[ID]
	LEFT JOIN
	DT_Locations l ON p.[LocationID] = l.[ID]
	LEFT JOIN
	SY_States s ON l.[StateID] = s.[ID]
WHERE
	dl.[Deleted] = 0
--	AND
--	dl.[IsTask] = 0
	AND
	dl.[DepartmentID] IN
		(
		SELECT
			[DeptID]
		FROM
			OPENXML(@idocStyles, '/NewDataSet/Dept', 2)
			WITH ([DeptID]	int)
		)
ORDER BY
	d.[AcctGroup] ASC, p.[Number] ASC, [dbo].funcGetHGADrwgSort(dl.[HGANumber]) ASC
END
ELSE
BEGIN
SELECT
	d.[Name] AS Dept
	,p.[Number] AS Project
	,c.[Name] AS Customer
	,p.[Description] as [Description]
	,(l.[City] + ', ' + s.[Abbrev]) AS Location
	,e.[Name] AS Lead
	,dl.[HGANumber]
	,dl.[CadNumber]
	,ac.[Code] AS ActivityCode
	,dl.[IsTask]
	,ds.[Size] As DwgSize
	,dl.[BudgetHrs]
	,dl.[PercentComplete]
	,dl.[RemainingHrs]
	,dl.[EarnedHrs]
	,ISNULL(t.[Title],'') + '/' + ISNULL(t.[Desc],'') AS [Title]
FROM
	DT_DrawingLogs dl
	LEFT JOIN
	DT_Departments d ON dl.[DepartmentID] = d.[ID]
	LEFT JOIN
	DT_Projects p ON dl.[ProjectID] = p.[ID]
	LEFT JOIN
	DT_Employees e ON dl.[ProjectLeadID] = e.[ID]
	LEFT JOIN
	DT_ActivityCodes ac ON dl.[ActCodeID] = ac.[ID]
	LEFT JOIN
	SY_DrawingSizes ds ON dl.[DrawingSizeID] = ds.[ID]
	LEFT JOIN
	(
	SELECT
		d.[ID]
		,[Title] = CASE
					WHEN d.[Title6IsTitle] = 1 THEN d.[Title6]
					WHEN d.[Title5IsTitle] = 1 THEN d.[Title5]
					WHEN d.[Title4IsTitle] = 1 THEN d.[Title4]
					WHEN d.[Title3IsTitle] = 1 THEN d.[Title3]
					WHEN d.[Title2IsTitle] = 1 THEN d.[Title2]
					ELSE d.[Title1]
		END
		,[Desc] = CASE
					WHEN d.[Title6IsDesc] = 1 THEN d.[Title6]
					WHEN d.[Title5IsDesc] = 1 THEN d.[Title5]
					WHEN d.[Title4IsDesc] = 1 THEN d.[Title4]
					WHEN d.[Title3IsDesc] = 1 THEN d.[Title3]
					WHEN d.[Title2IsDesc] = 1 THEN d.[Title2]
					ELSE d.[Title1]
		END
	FROM
		DT_DrawingLogs d
	WHERE
		d.[Deleted] = 0
	) t ON dl.[ID] = t.[ID]
	LEFT JOIN
	DT_Customers c ON p.[CustomerID] = c.[ID]
	LEFT JOIN
	DT_Locations l ON p.[LocationID] = l.[ID]
	LEFT JOIN
	SY_States s ON l.[StateID] = s.[ID]
WHERE
	dl.[Deleted] = 0
--	AND
--	dl.[IsTask] = 0
	AND
	dl.[DepartmentID] IN
		(
		SELECT
			[DeptID]
		FROM
			OPENXML(@idocStyles, '/NewDataSet/Dept', 2)
			WITH ([DeptID]	int)
		)
ORDER BY
	d.[AcctGroup] ASC, p.[Number] ASC, dl.[CADNumber] ASC, [dbo].funcGetHGADrwgSort(dl.[HGANumber]) ASC
END


EXEC sp_xml_removedocument @idocStyles

GO

