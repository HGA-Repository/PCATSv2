USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_Update]    Script Date: 3/31/2015 11:32:08 AM ******/
DROP PROCEDURE [dbo].[spBudgetExpenseSheet_Update]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_Update]    Script Date: 3/31/2015 11:32:08 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spBudgetExpenseSheet_Update]
@ID		int,
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
UPDATE
	DT_BudgetExpenseSheets
SET
	[BudgetID] = @BudgetID,
	[DeptGroup] = @DeptGroup,
	[WorkGuid] = @WorkGuid,
	[Description] = @Description,
	[Quantity] = @Quantity,
	[RoundTrips] = @RoundTrips,
	[People] = @People,
	[NumDays] = @NumDays,
	[NumNights] = @NumNights,
	[HoursPerDay] = @HoursPerDay,
	[TravelHours] = @TravelHours,
	[E110] = @E110,
	[E120] = @E120,
	[E130] = @E130,
	[E140] = @E140,
	[E150] = @E150,
	[E160] = @E160,
	[E170] = @E170,
	[E180] = @E180,
	[E190] = @E190,
	[Remarks] = @Remarks,
	[E281] = @E281,
	[E282] = @E282,
	[E283] = @E283,
	[E284] = @E284,
	[E290] = @E290,
	[E310] = @E310,
	[E320] = @E320,
	[E330] = @E330,
	[E340] = @E340,
	[E350] = @E350,
	[E541] = @E541,
	[E542] = @E542,
	[E543] = @E543,
	[E561] = @E561,
	[E562] = @E562,
	[E580] = @E580,
	[E591] = @E591,
	[E592] = @E592,
	[E593] = @E593,
	[E594] = @E594,
	[E595] = @E595
WHERE
	[ID] = @ID


GO


