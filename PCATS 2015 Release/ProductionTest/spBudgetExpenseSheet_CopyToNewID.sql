/****** Object:  StoredProcedure [dbo].[spBudgetExpenseWorksheet_CopyToNewID]    Script Date: 3/31/2015 11:32:38 AM ******/
DROP PROCEDURE [dbo].[spBudgetExpenseWorksheet_CopyToNewID]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseWorksheet_CopyToNewID]    Script Date: 3/31/2015 11:32:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spBudgetExpenseWorksheet_CopyToNewID]
@OriginalID	int,
@NewBudgetID	int
AS
INSERT INTO
	DT_BudgetExpenseSheets
(
	[BudgetID],
	[DeptGroup],
	[WorkGuid],
	[Description],
	[Quantity],
	[RoundTrips],
	[People],
	[NumDays],
	[NumNights],
	[HoursPerDay],
	[TravelHours],
	[E110],
	[E120],
	[E130],
	[E140],
	[E150],
	[E160],
	[E170],
	[E180],
	[E190],
	[E281],
	[E282],
	[E283],
	[E284],	
	[E290],
	[E310],
	[E320],
	[E330],
	[E340],
	[E350],
	[E541],
	[E542],
	[E543],
	[E561],
	[E562],
	[E580],
	[E591],
	[E592],
	[E593],
	[E594],
	[E595]
)
SELECT
	@NewBudgetID,
	[DeptGroup],
	[WorkGuid],
	[Description],
	[Quantity],
	[RoundTrips],
	[People],
	[NumDays],
	[NumNights],
	[HoursPerDay],
	[TravelHours],
	[E110],
	[E120],
	[E130],
	[E140],
	[E150],
	[E160],
	[E170],
	[E180],
	[E190],
	[E281],
	[E282],
	[E283],
	[E284],
	[E290],
	[E310],
	[E320],
	[E330],
	[E340],
	[E350],
	[E541],
	[E542],
	[E543],
	[E561],
	[E562],
	[E580],
	[E591],
	[E592],
	[E593],
	[E594],
	[E595]
FROM
	DT_BudgetExpenseSheets
WHERE
	[BudgetID] = @OriginalID
	AND
	[Deleted] = 0


GO


