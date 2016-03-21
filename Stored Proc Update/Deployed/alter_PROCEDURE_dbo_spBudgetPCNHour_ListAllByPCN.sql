--USE [RSManpowerSchDb2014]
--GO

/****** Object:  StoredProcedure [dbo].[spBudgetPCNHour_ListAllByPCN]    Script Date: 3/11/2016 9:23:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

alter PROCEDURE [dbo].[spBudgetPCNHour_ListAllByPCN]
@PCNID	int
AS
SELECT
	[ID],
	[PCNID],
	[Code],
	[WBS],
	[Description],
	[Quantity],
	[HoursPerItem],
	[Rate],
	[SubtotalHrs],
	[SubtotalDlrs]
FROM
	DT_BudgetPCNHours
WHERE
	[Deleted] = 0
	AND
	[PCNID] = @PCNID
	order by Code -- Added 3/11/2016---MZ

GO


