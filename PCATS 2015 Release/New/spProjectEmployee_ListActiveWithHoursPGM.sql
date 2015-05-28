USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spProjectEmployee_ListActiveWithHoursPGM]    Script Date: 5/22/2015 8:09:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spProjectEmployee_ListActiveWithHoursPGM]
@DepartmentID	int,
@StartDate	smalldatetime,
@EndDate	smalldatetime
AS
SELECT
	pe.[Deleted] AS pedel,
	pg.[ID] AS ProjectID,
	pg.[Number] AS ProjectNumber,
	pg.[Description] AS ProjectDescription,
	emp.[ID] AS EmployeeID,
	emp.[Name] AS EmployeeName,
	ISNULL(wkHrs.[WeekID],0) AS WeekID,
	ISNULL(wkHrs.[PHrs],0) AS PHrs,
	[PWarn] = CASE
				WHEN ISNULL(sumWkHrs.[TotWeekPHrs],0) > emp.[MaxAllHrs] THEN 2
				WHEN ISNULL(sumWkHrs.[TotWeekPHrs],0) > emp.[MaxRegHrs] THEN 1
				WHEN ISNULL(sumWkHrs.[TotWeekPHrs],0) > emp.[MinHrs] THEN 0
				ELSE -1
			END,
	ISNULL(wkHrs.[FHrs],0) AS FHrs,
	[FWarn] = CASE
				WHEN ISNULL(sumWkHrs.[TotWeekFHrs],0) > emp.[MaxAllHrs] THEN 2
				WHEN ISNULL(sumWkHrs.[TotWeekFHrs],0) > emp.[MaxRegHrs] THEN 1
				WHEN ISNULL(sumWkHrs.[TotWeekFHrs],0) > emp.[MinHrs] THEN 0
				ELSE -1
			END,
	ISNULL(wkHrs.[AHrs],0) AS AHrs
FROM
	DT_ProjectEmployees pe
	LEFT JOIN
	DT_Projects pg ON pe.[ProjectID] = pg.[ID]
	LEFT JOIN
	DT_Employees emp ON pe.[EmployeeID] = emp.[ID]
	LEFT JOIN
	(
	SELECT
		sh.[ProjectID],
		sh.[EmployeeID],
		sh.[DepartmentID],
		sh.[WeekID],
		sh.[PHrs],
		sh.[FHrs],
		sh.[AHrs]
	FROM
		DT_ScheduleHours sh
		LEFT JOIN
		SY_WeekLists wl ON sh.[WeekID] = wl.[ID]
	WHERE
		wl.[EndOfWeek] >= @StartDate
		AND
		wl.[StartOfWeek] <= @EndDate
		AND
		sh.[DepartmentID] = @DepartmentID	
		AND
		sh.[Deleted] = 0
	)  wkHrs ON pe.[ProjectID] = wkHrs.[ProjectID] AND pe.[EmployeeID] = wkHrs.[EmployeeID] AND pe.[DepartmentID] = wkHrs.[DepartmentID]
	
	LEFT JOIN
	(
	SELECT
		sh.[EmployeeID],
		sh.[WeekID],
		SUM(sh.[PHrs]) AS [TotWeekPHrs],
		SUM(sh.[FHrs]) AS [TotWeekFHrs]
	FROM
		DT_ScheduleHours sh
		LEFT JOIN
		SY_WeekLists wl ON sh.[WeekID] = wl.[ID]
		LEFT JOIN
		dt_ProjectEmployees pe ON sh.[DepartmentID] = pe.[DepartmentID]
									AND sh.[ProjectID] = pe.[ProjectID]
									AND sh.[EmployeeID] = pe.[EmployeeID]
		LEFT JOIN
		dt_Projects p ON sh.[ProjectID] = p.[ID]
	WHERE
		wl.[EndOfWeek] >= @StartDate
		AND
		wl.[StartOfWeek] <= @EndDate
		AND
		sh.[Deleted] = 0
		AND
		pe.[Deleted] = 0
		AND
		p.[Deleted] = 0
		AND
		p.[IsActive] = 1
	GROUP BY
		sh.[EmployeeID], sh.[WeekID]
	) sumWkHrs ON pe.[EmployeeID] = sumWkHrs.[EmployeeID] AND wkHrs.[WeekID] = sumWkHrs.[WeekID]
WHERE
	pg.[IsActive] = 1
	AND
	(Left(pg.Number,2) = '3.' or Left(pg.Number,2) = '6.')
	AND
	pg.[Deleted] = 0
	AND
	emp.[Deleted] = 0
	AND
	pe.[Deleted] = 0
	AND
	pe.[DepartmentID] = @DepartmentID
ORDER BY
	pg.[Number] ASC, emp.[Name] ASC


GO


