USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_Update]    Script Date: 03/22/2013 14:55:47 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudgetExpenseSheet_Update]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudgetExpenseSheet_Update]
GO

USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_Update]    Script Date: 03/22/2013 14:55:47 ******/
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
@Remarks		varchar(500)
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
	[Remarks] = @Remarks
WHERE
	[ID] = @ID

GO













USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseWorksheet_CopyToNewID]    Script Date: 03/22/2013 15:11:06 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudgetExpenseWorksheet_CopyToNewID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudgetExpenseWorksheet_CopyToNewID]
GO

USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseWorksheet_CopyToNewID]    Script Date: 03/22/2013 15:11:06 ******/
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
	[E190]
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
	[E190]
FROM
	DT_BudgetExpenseSheets
WHERE
	[BudgetID] = @OriginalID
	AND
	[Deleted] = 0

GO







USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_ListAllByBudgetGroup]    Script Date: 03/22/2013 15:12:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudgetExpenseSheet_ListAllByBudgetGroup]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudgetExpenseSheet_ListAllByBudgetGroup]
GO

USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_ListAllByBudgetGroup]    Script Date: 03/22/2013 15:12:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBudgetExpenseSheet_ListAllByBudgetGroup]
@BudgetID	int,
@Group		int
AS
SELECT
	[ID],
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
	[E190]

FROM
	DT_BudgetExpenseSheets
WHERE
	[BudgetID] = @BudgetID
	AND
	[DeptGroup] = @Group
	AND
	[Deleted] = 0

GO






USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_ListAll]    Script Date: 03/22/2013 15:13:10 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudgetExpenseSheet_ListAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudgetExpenseSheet_ListAll]
GO

USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_ListAll]    Script Date: 03/22/2013 15:13:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBudgetExpenseSheet_ListAll]
AS
SELECT
	[ID],
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
	[E190]
FROM
	DT_BudgetExpenseSheets
WHERE
	[Deleted] = 0

GO






USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_Insert]    Script Date: 03/22/2013 15:14:45 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudgetExpenseSheet_Insert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudgetExpenseSheet_Insert]
GO

USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_Insert]    Script Date: 03/22/2013 15:14:45 ******/
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
@Remarks		varchar(500)
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
	[Remarks]
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
	@Remarks
)


SELECT @ID = @@IDENTITY

GO








USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_ByID]    Script Date: 03/22/2013 15:15:57 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[spBudgetExpenseSheet_ByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[spBudgetExpenseSheet_ByID]
GO

USE [RSManpowerSchDb_test]
GO

/****** Object:  StoredProcedure [dbo].[spBudgetExpenseSheet_ByID]    Script Date: 03/22/2013 15:15:57 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBudgetExpenseSheet_ByID]
@ID		int
AS
SELECT
	[ID],
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
	[Remarks]
FROM
	DT_BudgetExpenseSheets
WHERE
	[ID] = @ID

GO



