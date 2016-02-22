USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spDrawingLog_ListForUpdate]    Script Date: 04/26/2013 14:30:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spDrawingLog_ListForUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spDrawingLog_ListForUpdate]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spDrawingLog_ListForUpdate]    Script Date: 04/26/2013 14:30:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spDrawingLog_ListForUpdate]
@DepartmentID	int,
@ProjectID		int,
@WBS	varchar(5)
AS
SELECT 
	dl.[ID]
	,p.[Number] AS Project
	,dl.[WBS]
	,dl.[HGANumber]
	,dl.[ClientNumber]
	,dl.[CADNumber]
	,ac.[Code] AS [AcctCode]
	,dl.[IsTask]
	,dl.[BudgetHrs]
	,dl.[PercentComplete]
	,dl.[RemainingHrs]
	,dl.[EarnedHrs]
	,ISNULL(t.[Title],'') + '/' + ISNULL(t.[Desc],'') AS [Title]
	--,ISNULL(actTime.[Hrs],0) AS ActualHrs
	,0 as ActualHrs
FROM
	DT_DrawingLogs dl
	LEFT JOIN
	DT_ActivityCodes ac ON dl.[ActCodeID] = ac.[ID]
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
	DT_Projects p ON dl.[ProjectID] = p.[ID]
	LEFT JOIN
	DT_Departments d ON dl.[DepartmentID] = d.[ID]
	LEFT JOIN
	(
	SELECT
		[cdeptid], 
		[cproject], 
		[cphaseid], 
		SUM([nbillhours]) AS Hrs
	FROM
		--vwFMS_Emp_Proj_Time
		DT_FMSTimeData
	GROUP BY
		[cdeptid], [cproject], [cphaseid]
	) actTime ON d.[Number] = actTime.[cdeptid] AND p.[Number] = actTime.[cproject] AND ac.[Code] = actTime.[cphaseid]
WHERE
	dl.[DepartmentID] = @DepartmentID
	AND
	dl.[ProjectID] = @ProjectID
	AND
	dl.[WBS] LIKE @WBS + '%'
	AND
	dl.[Deleted] = 0
ORDER BY
	p.[Number] ASC
--	,dbo.funcSortPrefix([HGANumber]) ASC
	,dl.[HGANumber] ASC
--	,dbo.funcSortSuffixAsNum([HGANumber]) ASC

GO


