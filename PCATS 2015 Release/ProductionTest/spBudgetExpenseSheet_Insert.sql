/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_Insert]    Script Date: 3/31/2015 11:29:49 AM ******/
DROP PROCEDURE [dbo].[spBudgetExpenseSheet_Insert]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_Insert]    Script Date: 3/31/2015 11:29:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spBudgetExpenseSheet_Insert]
@ID		int	output,
@BudgetID		int,
@DeptGroup		int,
@WorkGuid		varchar(50),
@Description		varchar(100),
@Quantity		int,
@RoundTrips		int,
@People		int,
@NumDays		int,
@NumNights		int,
@HoursPerDay		int,
@TravelHours		int,
@E110	int,
@E120	int,
@E130	int,
@E140	int,
@E150	int,
@E160	int,
@E170	int,
@E180	int,
@E190	int,
@Remarks		varchar(500),
@E281	int,
@E282	int,
@E283	int,
@E284	int,
@E290	int,
@E310	int,
@E320	int,
@E330	int,
@E340	int,
@E350	int,
@E541	int,
@E542	int,
@E543	int,
@E561	int,
@E562	int,
@E580	int,
@E591	int,
@E592	int,
@E593	int,
@E594	int,
@E595	int
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
	[Remarks],
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
VALUES
(
	@BudgetID,
	@DeptGroup,
	@WorkGuid,
	@Description,
	@Quantity,
	@RoundTrips,
	@People,
	@NumDays,
	@NumNights,
	@HoursPerDay,
	@TravelHours,
	@E110,
	@E120,
	@E130,
	@E140,
	@E150,
	@E160,
	@E170,
	@E180,
	@E190,
	@Remarks,
	@E281,
	@E282,
	@E283,
	@E284,
	@E290,
	@E310,
	@E320,
	@E330,
	@E340,
	@E350,
	@E541,
	@E542,
	@E543,
	@E561,
	@E562,
	@E580,
	@E591,
	@E592,
	@E593,
	@E594,
	@E595
)


SELECT @ID = @@IDENTITY


GO


