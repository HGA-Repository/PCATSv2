USE [RSManpowerSchDb_dev]
GO

/****** Object:  StoredProcedure [dbo].[spRPRT_BudgetAccountEntrys]    Script Date: 04/11/2013 14:39:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spRPRT_BudgetAccountEntrys]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spRPRT_BudgetAccountEntrys]
GO

USE [RSManpowerSchDb_dev]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spRPRT_BudgetAccountEntrys]
@BudgetID	int,
@WBS	varchar(5)
AS

/*
exec spRPRT_BudgetAccountEntrys @BudgetID=5128,@WBS=''
*/

DECLARE @TOTHRS int
DECLARE @TOTBUDDLRS money
DECLARE @TOTEXPDLRS money

--DECLARE @IsGovern bit
--SELECT @IsGovern = p.[IsGovernment] FROM DT_Projects p LEFT JOIN dt_Budgets b ON p.[ID] = b.[ProjectID] WHERE b.[ID] = @BudgetID

SELECT
	@TOTHRS = SUM([TotalHours])
	,@TOTBUDDLRS = SUM([TotalDollars])
FROM
	DT_BudgetLines
WHERE
	[BudgetID] = @BudgetID
	AND [Quantity] <> 0
	AND [WBS] LIKE @WBS + '%'
	AND [Deleted] = 0


SELECT
	@TOTEXPDLRS = SUM([TotalDollars])
FROM
	DT_BudgetExpenseLines
WHERE
	[BudgetID] = @BudgetID
	AND [Quantity] <> 0
	AND [Deleted] = 0





SELECT 
	sums.[Activity]
	,sums.[TotalHours]
	,sums.[TotalDollars]
	,sums.[WBS]
	,[Discipline] = CASE
		WHEN codes_3.description = codes_4.description THEN codes_1.description + ' -- ' + codes_4.description
		ELSE codes_1.description + ' -- ' + codes_3.description + ' -- ' + codes_4.description
	END
	,@TOTHRS AS [GrandTotalHours]
	,ISNULL(@TOTBUDDLRS, 0) + ISNULL(@TOTEXPDLRS, 0) AS [GrandTotalDlrs]
 from (
	SELECT
		bl.[Activity]
		,sum(bl.[TotalHours]) AS [TotalHours]
		,sum(bl.[TotalDollars]) AS [TotalDollars]
		,bl.[WBS]
	FROM
		DT_BudgetLines bl
	WHERE
		[BudgetID] = @BudgetID
		AND [Quantity] <> 0
		AND [WBS] LIKE @WBS + '%'
		AND [Deleted] = 0
	GROUP BY
		[Activity], [DeptGroup], [WBS]
		) sums
left join vwAllAccountCodes codes_4 on codes_4.code = sums.Activity

left join vwCodeGroups groups on sums.Activity = groups.code
	left join vwAllAccountCodes codes_1 on codes_1.code = groups.CodeGroup

left join vwCodeCategorys cats on sums.Activity = cats.code
	left join vwAllAccountCodes codes_3 on codes_3.code = cats.CategoryCode

ORDER BY sums.[Activity] ASC



SELECT
	[Code]
	,[Description]
	,SUM([TotalDollars]) AS [ExpDollars]
FROM
	DT_BudgetExpenseLines
WHERE
	[BudgetID] = @BudgetID
	AND
	[Quantity] <> 0
	AND
	[Deleted] = 0
GROUP BY
	[Code], [Description]
ORDER BY
	[Code] ASC

GO


