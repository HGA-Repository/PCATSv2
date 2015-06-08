/****** Object:  StoredProcedure [dbo].[spBudget_Insert]    Script Date: 4/13/2015 9:29:04 AM ******/
DROP PROCEDURE [dbo].[spBudget_Insert]
GO

/****** Object:  StoredProcedure [dbo].[spBudget_Insert]    Script Date: 4/13/2015 9:29:04 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spBudget_Insert]
@ID		int	output,
@ProjectID		int,
@Revision		int,
@PCNID		int,
@IsDefault		bit,
@IsActive		bit,
@IsLocked		bit,
@Description	varchar(100),
@PreparedBy		varchar(50),
@Contingency	money,
@Clarification11000	varchar(MAX),
@Clarification12000	varchar(MAX),
@Clarification13000	varchar(MAX),
@Clarification14000	varchar(MAX),
@Clarification15000	varchar(MAX),
@Clarification16000	varchar(MAX),
@Clarification17000	varchar(MAX),
@Clarification18000	varchar(MAX),
@Clarification50000	varchar(MAX)

AS
INSERT INTO
	DT_Budgets
(
	[ProjectID],
	[Revision],
	[PCNID],
	[IsDefault],
	[IsActive],
	[IsLocked],
	[Description],
	[PreparedBy],
	[Contingency],
	[Clarification11000],
	[Clarification12000],
	[Clarification13000],
	[Clarification14000],
	[Clarification15000],
	[Clarification16000],
	[Clarification17000],
	[Clarification18000],
	[Clarification50000]
)
VALUES
(
	@ProjectID,
	@Revision,
	@PCNID,
	@IsDefault,
	@IsActive,
	@IsLocked,
	@Description,
	@PreparedBy,
	@Contingency,
	@Clarification11000,
	@Clarification12000,
	@Clarification13000,
	@Clarification14000,
	@Clarification15000,
	@Clarification16000,
	@Clarification17000,
	@Clarification18000,
	@Clarification50000
)


SELECT @ID = @@IDENTITY
GO

