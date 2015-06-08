/****** Object:  StoredProcedure [dbo].[spRPRT_CostReport_ByDept]    Script Date: 4/14/2015 9:29:25 AM ******/
DROP PROCEDURE [dbo].[spRPRT_CostReport_ByDept]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_CostReport_ByDept]    Script Date: 4/14/2015 9:29:25 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_CostReport_ByDept]
@ProjXML	text,
@AcctCode	varchar(10)
AS
DECLARE @idocStyles1	int

EXEC sp_xml_preparedocument @idocStyles1 OUTPUT, @ProjXML

SELECT
	projs.[Project]
	,p.[Description]
	,p.[Customer]
	,p.[Location]
	,projs.[BudgetGroup]
	,projs.[AcctGroup]
	--,projs.[Manager]
	,dbo.funcProjMang(projs.[Manager]) AS [Manager]
	,ISNULL(b.[Budget],0) AS [BudgetDlrs]
	,ISNULL(b.[BudgetHrs],0) AS [BudgetHrs]
	,ISNULL(wind2.[BillHours],0) AS [ActualTime]
	,ISNULL(wind2.[BillAmnt],0) AS [ActualAmnt]
	,ISNULL(js.[BudgetHrs],0) AS [JSBudgetHrs]
	,ISNULL(js.[RemainingHrs],0) AS [RemainingHrs]
	,ISNULL(js.[EarnedHrs],0) AS [EarnedHrs]
	,ISNULL(b.[BudgetHrs],0) - ISNULL(js.[RemainingHrs],0) AS [EarnedHrs]
	,ISNULL(mp.[Projected],0) AS [ProjectedHrs]
	,ISNULL(mp.[Forecast],0) AS [ForecastHrs]
	,ISNULL(fc.[ForecastHrs],-9999) AS FTCHrs
	,ISNULL(fc.[ForecastAmnt],-9999) AS FTCAmnt
FROM
	(
	SELECT
		proj.[project] AS [Project]
		,ag.[AcctNumber] AS [BudgetGroup]
		,ag.[AcctGroup]
		,proj.[EmpName] AS [Manager]
	FROM
		vwVision_Projects proj
		CROSS JOIN
		(
		SELECT DISTINCT
			[AcctNumber]
			,[AcctGroup]
		FROM
			SY_AccountGroups
		WHERE
			[StartNew] <> 0
		) ag
	) projs
	LEFT JOIN
	(
	SELECT
		p.[Number] AS [Project]
		,p.[Description]
		,c.[Name] AS [Customer]
		,l.[City] + ', ' + s.[Abbrev] AS [Location]
	FROM
		DT_Projects p
		LEFT JOIN
		DT_Customers c ON p.[CustomerID] = c.[ID]
		LEFT JOIN
		DT_Locations l ON p.[LocationID] = l.[ID]
		LEFT JOIN
		SY_States s ON l.[StateID] = s.[ID]
	WHERE
		p.[Deleted] = 0
		AND
		c.[Deleted] = 0
	) p ON projs.[Project] = p.[Project]
	LEFT JOIN
	(
	SELECT
		b.[Project]
		,ag.[AcctNumber]
		,SUM(b.[Budget]) AS [Budget]
		,SUM(b.[BudgetHrs]) AS [BudgetHrs]
	FROM
		vwVision_Budgets b
		LEFT JOIN
		SY_AccountGroups ag ON b.[phase] BETWEEN ag.[StartNew] AND ag.[EndNew]
	WHERE
		ISNUMERIC(b.[phase]) = 1
--		AND
--		LEN(b.[Phase]) < 8
	GROUP BY
		b.[Project], ag.[AcctNumber]
	) b ON projs.[Project] = b.[Project] AND projs.[BudgetGroup] = b.[AcctNumber]
	LEFT JOIN
	(
	-- wind2 time information
	SELECT
		proj.[project] AS [Project]
		,ag.[AcctNumber]
		,SUM(ISNULL(ept.[RegHrs],0) + ISNULL(ept.[OvtHrs],0)) AS [BillHours]
		,SUM(ISNULL(ept.[Billed],0)) AS [BillAmnt]
	FROM
		vwVision_Projects proj
		LEFT JOIN
		(
		SELECT
			*
		FROM
			vwVision_Emp_Proj_Time
		WHERE
			ISNUMERIC([AcctCode]) = 1
		) ept ON proj.[PROJECT] = ept.[wbs1]
		LEFT JOIN
		SY_AccountGroups ag ON ept.[AcctCode] BETWEEN ag.[StartNew] AND ag.[EndNew]
	WHERE
		ept.[AcctCode] Is Not Null
		AND
		ept.[TransDate] <= GETDATE()
	GROUP BY
		proj.[PROJECT], ag.[AcctNumber]
	) wind2 ON projs.[Project] = wind2.[Project] AND projs.[BudgetGroup] = wind2.[AcctNumber]
	LEFT JOIN
	(
	-- Jobstat information
	SELECT
		p.[Number] AS Project
		,ag.[AcctNumber]
		,SUM(dl.[BudgetHrs]) AS BudgetHrs
		,SUM(dl.[RemainingHrs]) AS RemainingHrs
		,SUM(dl.[BudgetHrs] - dl.[RemainingHrs]) AS EarnedHrs
		--,SUM(dl.[EarnedHrs]) AS EarnedHrs
	FROM
		DT_DrawingLogs dl
		LEFT JOIN
		DT_ActivityCodes ac ON dl.[ActCodeID] = ac.[ID]
		LEFT JOIN
		SY_AccountGroups ag ON ac.[Code] BETWEEN ag.[StartNew] AND ag.[EndNew]
		LEFT JOIN
		DT_Projects p ON dl.[ProjectID] = p.[ID]
	WHERE
		dl.[Deleted] = 0
	GROUP BY
		p.[Number], ag.[AcctNumber]
	) js ON projs.[Project] = js.[Project] AND projs.[BudgetGroup] = js.[AcctNumber]
	LEFT JOIN
	(
	-- manpower data
	SELECT
		p.[Number] AS [Project]
		,d.[AcctGroup]
		,SUM(sh.[PHrs]) AS Projected
		,SUM(sh.[FHrs]) AS Forecast
	FROM	
		DT_ScheduleHours sh
		LEFT JOIN
		DT_Projects p ON sh.[ProjectID] = p.[ID]
		LEFT JOIN
		DT_Departments d ON sh.[DepartmentID] = d.[ID]
		LEFT JOIN
		SY_WeekLists w ON sh.[WeekID] = w.[ID]
	WHERE
		p.[Deleted] = 0
		AND
		w.[EndOfWeek]>= GETDATE()
		AND
		sh.[Deleted] = 0
	GROUP BY
		p.[Number], d.[AcctGroup]
	) mp ON projs.[Project] = mp.[Project] AND projs.[BudgetGroup] = mp.[AcctGroup]
	LEFT JOIN
	(
	SELECT
		fu.[Project]
		,ftc.[AccountGroup]
		,ftc.[ForecastHrs]
		,ftc.[ForecastAmnt]
	FROM
		(
		SELECT
			[Project]
			,MAX([DateCreated]) AS MaxDate
		FROM
			DT_ForecastUpdates
		GROUP BY
			[Project]
		) fu
		LEFT JOIN
		DT_ForecastUpdates fdt ON fu.[Project] = fdt.[Project] AND fu.[MaxDate] = fdt.[DateCreated]
		LEFT JOIN
		DT_ForecastToCompletes ftc ON fdt.[ID] = ftc.[ForecastID]
	) fc ON projs.[Project] = fc.[Project] AND projs.[BudgetGroup] = fc.[AccountGroup]
WHERE
	projs.[BudgetGroup] = @AcctCode
	AND
	projs.[Project] Not LIKE 'P%'
	AND
	projs.[Project] Not LIKE 'D%'
	AND
	(
	projs.[Project] >= '06079'
	OR
	projs.[Project] = '06031F-OG'
	OR
	projs.[Project] = '06069A-PW'
	OR
	projs.[Project] = '06069B-PW'
	OR
	projs.[Project] = '0.050036.01.0'
	OR
	projs.[Project] = '0.010139.02.0'
	)
-- IF (@Project = '06069B-PW' OR @Project = '06031F-OG' OR @Project = '06069A-PW' OR @Project = '05036A-PW' OR @Project = '05139B-PW'
	AND
	projs.[Project] IN
		(
		SELECT
			[Project]
		FROM
			OPENXML(@idocStyles1, '/NewDataSet/Proj', 2)
			WITH ([Project]	varchar(10))
		)

UNION

SELECT
	projs.[Project]
	,p.[Description]
	,p.[Customer]
	,p.[Location]
	,projs.[BudgetGroup]
	,projs.[AcctGroup]
	--,projs.[Manager]
	,dbo.funcProjMang(projs.[Manager]) AS [Manager]
	,ISNULL(b.[Budget],0) AS [BudgetDlrs]
	,ISNULL(b.[BudgetHrs],0) AS [BudgetHrs]
	,ISNULL(wind2.[BillHours],0) AS [ActualTime]
	,ISNULL(wind2.[BillAmnt],0) AS [ActualAmnt]
	,ISNULL(js.[BudgetHrs],0) AS [JSBudgetHrs]
	,ISNULL(js.[RemainingHrs],0) AS [RemainingHrs]
	,ISNULL(js.[EarnedHrs],0) AS [EarnedHrs]
	,ISNULL(b.[BudgetHrs],0) - ISNULL(js.[RemainingHrs],0) AS [EarnedHrs]
	,ISNULL(mp.[Projected],0) AS [ProjectedHrs]
	,ISNULL(mp.[Forecast],0) AS [ForecastHrs]
	,ISNULL(fc.[ForecastHrs],-9999) AS FTCHrs
	,ISNULL(fc.[ForecastAmnt],-9999) AS FTCAmnt
FROM
	(
	SELECT
		proj.[project] AS [Project]
		,ag.[AcctNumber] AS [BudgetGroup]
		,ag.[AcctGroup]
		,proj.[empname] AS [Manager]
	FROM
		vwVision_Projects proj
		CROSS JOIN
		(
		SELECT DISTINCT
			[AcctNumber]
			,[AcctGroup]
		FROM
			SY_AccountGroups
		WHERE
			[StartNew] <> 0
		) ag
	) projs
	LEFT JOIN
	(
	SELECT
		p.[Number] AS [Project]
		,p.[Description]
		,c.[Name] AS [Customer]
		,l.[City] + ', ' + s.[Abbrev] AS [Location]
	FROM
		DT_Projects p
		LEFT JOIN
		DT_Customers c ON p.[CustomerID] = c.[ID]
		LEFT JOIN
		DT_Locations l ON p.[LocationID] = l.[ID]
		LEFT JOIN
		SY_States s ON l.[StateID] = s.[ID]
	WHERE
		p.[Deleted] = 0
		AND
		c.[Deleted] = 0
		AND
		p.[IsActive] = 1
	) p ON projs.[Project] = p.[Project]
	LEFT JOIN
	(
	SELECT
		b.[Project]
		,ag.[AcctNumber]
		,SUM(b.[Budget]) AS [Budget]
		,SUM(b.[BudgetHrs]) AS [BudgetHrs]
	FROM
		vwVision_Budgets b
		LEFT JOIN
		SY_AccountGroups ag ON b.[phase] BETWEEN ag.[StartOld] AND ag.[EndOld]
	WHERE
		ISNUMERIC(b.[phase]) = 1
		AND
		LEN(b.[Phase]) < 8
	GROUP BY
		b.[Project], ag.[AcctNumber]
	) b ON projs.[Project] = b.[Project] AND projs.[BudgetGroup] = b.[AcctNumber]
	LEFT JOIN
	(
	-- wind2 time information
	SELECT
		proj.[project] AS [Project]
		,ag.[AcctNumber]
		,SUM(ISNULL(ept.[RegHrs],0) + ISNULL(ept.[OvtHrs],0)) AS [BillHours]
		,SUM(ISNULL(ept.[Billed],0)) AS [BillAmnt]
	FROM
		vwVision_Projects proj
		LEFT JOIN
		(
		SELECT
			*
		FROM
			vwVision_Emp_Proj_Time
		WHERE
			ISNUMERIC([AcctCode]) = 1
		) ept ON proj.[PROJECT] = ept.[wbs1]
		LEFT JOIN
		SY_AccountGroups ag ON ept.[AcctCode] BETWEEN ag.[StartOld] AND ag.[EndOld]
	WHERE
		ept.[AcctCode] Is Not Null
		AND
		ept.[TransDate] <= GETDATE()
	GROUP BY
		proj.[PROJECT], ag.[AcctNumber]
	) wind2 ON projs.[Project] = wind2.[Project] AND projs.[BudgetGroup] = wind2.[AcctNumber]
	LEFT JOIN
	(
	-- Jobstat information
	SELECT
		p.[Number] AS Project
		,ag.[AcctNumber]
		,SUM(dl.[BudgetHrs]) AS BudgetHrs
		,SUM(dl.[RemainingHrs]) AS RemainingHrs
		,SUM(dl.[BudgetHrs] - dl.[RemainingHrs]) AS EarnedHrs
		--,SUM(dl.[EarnedHrs]) AS EarnedHrs
	FROM
		DT_DrawingLogs dl
		LEFT JOIN
		DT_ActivityCodes ac ON dl.[ActCodeID] = ac.[ID]
		LEFT JOIN
		SY_AccountGroups ag ON ac.[Code] BETWEEN ag.[StartOld] AND ag.[EndOld]
		LEFT JOIN
		DT_Projects p ON dl.[ProjectID] = p.[ID]
	WHERE
		dl.[Deleted] = 0
	GROUP BY
		p.[Number], ag.[AcctNumber]
	) js ON projs.[Project] = js.[Project] AND projs.[BudgetGroup] = js.[AcctNumber]
	LEFT JOIN
	(
	-- manpower data
	SELECT
		p.[Number] AS [Project]
		,d.[AcctGroup]
		,SUM(sh.[PHrs]) AS Projected
		,SUM(sh.[FHrs]) AS Forecast
	FROM	
		DT_ScheduleHours sh
		LEFT JOIN
		DT_Projects p ON sh.[ProjectID] = p.[ID]
		LEFT JOIN
		DT_Departments d ON sh.[DepartmentID] = d.[ID]
		LEFT JOIN
		SY_WeekLists w ON sh.[WeekID] = w.[ID]
	WHERE
		p.[Deleted] = 0
		AND
		w.[EndOfWeek] >= GETDATE()
		AND
		sh.[Deleted] = 0
	GROUP BY
		p.[Number], d.[AcctGroup]
	) mp ON projs.[Project] = mp.[Project] AND projs.[BudgetGroup] = mp.[AcctGroup]
	LEFT JOIN
	(
	SELECT
		fu.[Project]
		,ftc.[AccountGroup]
		,ftc.[ForecastHrs]
		,ftc.[ForecastAmnt]
	FROM
		(
		SELECT
			[Project]
			,MAX([DateCreated]) AS MaxDate
		FROM
			DT_ForecastUpdates
		GROUP BY
			[Project]
		) fu
		LEFT JOIN
		DT_ForecastUpdates fdt ON fu.[Project] = fdt.[Project] AND fu.[MaxDate] = fdt.[DateCreated]
		LEFT JOIN
		DT_ForecastToCompletes ftc ON fdt.[ID] = ftc.[ForecastID]
	) fc ON projs.[Project] = fc.[Project] AND projs.[BudgetGroup] = fc.[AccountGroup]
WHERE
	projs.[BudgetGroup] = @AcctCode
	AND
	projs.[Project] Not LIKE 'P%'
	AND
	projs.[Project] Not LIKE 'D%'
	AND
	projs.[Project] < '06079'
	AND
	projs.[Project] <> '05129-O'
	AND
	projs.[Project] <> '06031F-OG'
	AND
	projs.[Project] <> '06057-O'
	AND
	projs.[Project] <> '0.050139.02.0'
	AND
	projs.[Project] <> '0.050036.01.0'
	AND
	projs.[Project] IN
		(
		SELECT
			[Project]
		FROM
			OPENXML(@idocStyles1, '/NewDataSet/Proj', 2)
			WITH ([Project]	varchar(10))
		)

UNION

SELECT
	projs.[Project]
	,p.[Description]
	,p.[Customer]
	,p.[Location]
	,projs.[BudgetGroup]
	,projs.[AcctGroup]
	--,projs.[Manager]
	,dbo.funcProjMang(projs.[Manager]) AS [Manager]
	,ISNULL(b.[Budget],0) AS [BudgetDlrs]
	,ISNULL(b.[BudgetHrs],0) AS [BudgetHrs]
	,ISNULL(wind2.[BillHours],0) AS [ActualTime]
	,ISNULL(wind2.[BillAmnt],0) AS [ActualAmnt]
	,ISNULL(js.[BudgetHrs],0) AS [JSBudgetHrs]
	,ISNULL(js.[RemainingHrs],0) AS [RemainingHrs]
	,ISNULL(js.[EarnedHrs],0) AS [EarnedHrs]
	,ISNULL(b.[BudgetHrs],0) - ISNULL(js.[RemainingHrs],0) AS [EarnedHrs]
	,ISNULL(mp.[Projected],0) AS [ProjectedHrs]
	,ISNULL(mp.[Forecast],0) AS [ForecastHrs]
	,ISNULL(fc.[ForecastHrs],-9999) AS FTCHrs
	,ISNULL(fc.[ForecastAmnt],-9999) AS FTCAmnt
FROM
	(
	SELECT
		proj.[project] AS [Project]
		,ag.[AcctNumber] AS [BudgetGroup]
		,ag.[AcctGroup]
		,proj.[empname] AS [Manager]
	FROM
		vwVision_Projects proj
		CROSS JOIN
		(
		SELECT DISTINCT
			[AcctNumber]
			,[AcctGroup]
		FROM
			SY_AccountGroups
		WHERE
			[StartNew] <> 0
		) ag
	) projs
	LEFT JOIN
	(
	SELECT
		p.[Number] AS [Project]
		,p.[Description]
		,c.[Name] AS [Customer]
		,l.[City] + ', ' + s.[Abbrev] AS [Location]
	FROM
		DT_Projects p
		LEFT JOIN
		DT_Customers c ON p.[CustomerID] = c.[ID]
		LEFT JOIN
		DT_Locations l ON p.[LocationID] = l.[ID]
		LEFT JOIN
		SY_States s ON l.[StateID] = s.[ID]
	WHERE
		p.[Deleted] = 0
		AND
		c.[Deleted] = 0
		AND
		p.[IsActive] = 1
	) p ON projs.[Project] = p.[Project]
	LEFT JOIN
	(
	SELECT
		b.[Project]
		,ag.[AcctNumber]
		,SUM(b.[Budget]) AS [Budget]
		,SUM(b.[BudgetHrs]) AS [BudgetHrs]
	FROM
		vwVision_Budgets b
		LEFT JOIN
		SY_AccountGroups ag ON b.[phase] BETWEEN ag.[StartOld] AND ag.[EndOld]
	WHERE
		ISNUMERIC(b.[phase]) = 1
		AND
		LEN(b.[Phase]) < 8
	GROUP BY
		b.[Project], ag.[AcctNumber]
	) b ON projs.[Project] = b.[Project] AND projs.[BudgetGroup] = b.[AcctNumber]
	LEFT JOIN
	(
	-- wind2 time information
	SELECT
		proj.[project] AS [Project]
		,ag.[AcctNumber]
		,SUM(ISNULL(ept.[RegHrs],0) + ISNULL(ept.[OvtHrs],0)) AS [BillHours]
		,SUM(ISNULL(ept.[Billed],0)) AS [BillAmnt]
	FROM
		vwVision_Projects proj
		LEFT JOIN
		(
		SELECT
			*
		FROM
			vwVision_Emp_Proj_Time
		WHERE
			ISNUMERIC([AcctCode]) = 1
		) ept ON proj.[PROJECT] = ept.[wbs1]
		LEFT JOIN
		SY_AccountGroups ag ON ept.[AcctCode] BETWEEN ag.[StartOld] AND ag.[EndOld]
	WHERE
		ept.[AcctCode] Is Not Null
		AND
		ept.[TransDate] <= GETDATE()
	GROUP BY
		proj.[PROJECT], ag.[AcctNumber]
	) wind2 ON projs.[Project] = wind2.[Project] AND projs.[BudgetGroup] = wind2.[AcctNumber]
	LEFT JOIN
	(
	-- Jobstat information
	SELECT
		p.[Number] AS Project
		,ag.[AcctNumber]
		,SUM(dl.[BudgetHrs]) AS BudgetHrs
		,SUM(dl.[RemainingHrs]) AS RemainingHrs
		,SUM(dl.[BudgetHrs] - dl.[RemainingHrs]) AS EarnedHrs
		--,SUM(dl.[EarnedHrs]) AS EarnedHrs
	FROM
		DT_DrawingLogs dl
		LEFT JOIN
		DT_ActivityCodes ac ON dl.[ActCodeID] = ac.[ID]
		LEFT JOIN
		SY_AccountGroups ag ON ac.[Code] BETWEEN ag.[StartNew] AND ag.[EndNew]
		LEFT JOIN
		DT_Projects p ON dl.[ProjectID] = p.[ID]
	WHERE
		dl.[Deleted] = 0
	GROUP BY
		p.[Number], ag.[AcctNumber]
	) js ON projs.[Project] = js.[Project] AND projs.[BudgetGroup] = js.[AcctNumber]
	LEFT JOIN
	(
	-- manpower data
	SELECT
		p.[Number] AS [Project]
		,d.[AcctGroup]
		,SUM(sh.[PHrs]) AS Projected
		,SUM(sh.[FHrs]) AS Forecast
	FROM	
		DT_ScheduleHours sh
		LEFT JOIN
		DT_Projects p ON sh.[ProjectID] = p.[ID]
		LEFT JOIN
		DT_Departments d ON sh.[DepartmentID] = d.[ID]
		LEFT JOIN
		SY_WeekLists w ON sh.[WeekID] = w.[ID]
	WHERE
		p.[Deleted] = 0
		AND
		w.[EndOfWeek] >= GETDATE()
		AND
		sh.[Deleted] = 0
	GROUP BY
		p.[Number], d.[AcctGroup]
	) mp ON projs.[Project] = mp.[Project] AND projs.[BudgetGroup] = mp.[AcctGroup]
	LEFT JOIN
	(
	SELECT
		fu.[Project]
		,ftc.[AccountGroup]
		,ftc.[ForecastHrs]
		,ftc.[ForecastAmnt]
	FROM
		(
		SELECT
			[Project]
			,MAX([DateCreated]) AS MaxDate
		FROM
			DT_ForecastUpdates
		GROUP BY
			[Project]
		) fu
		LEFT JOIN
		DT_ForecastUpdates fdt ON fu.[Project] = fdt.[Project] AND fu.[MaxDate] = fdt.[DateCreated]
		LEFT JOIN
		DT_ForecastToCompletes ftc ON fdt.[ID] = ftc.[ForecastID]
	) fc ON projs.[Project] = fc.[Project] AND projs.[BudgetGroup] = fc.[AccountGroup]
WHERE
	projs.[BudgetGroup] = @AcctCode
	AND
	projs.[Project] Not LIKE 'P%'
	AND
	projs.[Project] Not LIKE 'D%'
	AND
	(
	projs.[Project] = '05129-O'
	OR
	projs.[Project] = '06057-O'
	)
	AND
	projs.[Project] IN
		(
		SELECT
			[Project]
		FROM
			OPENXML(@idocStyles1, '/NewDataSet/Proj', 2)
			WITH ([Project]	varchar(10))
		)


ORDER BY
	[Project] ASC

EXEC sp_xml_removedocument @idocStyles1

GO

