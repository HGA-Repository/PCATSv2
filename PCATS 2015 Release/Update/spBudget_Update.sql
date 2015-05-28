USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spBudget_Update]    Script Date: 4/13/2015 9:32:05 AM ******/
DROP PROCEDURE [dbo].[spBudget_Update]
GO

/****** Object:  StoredProcedure [dbo].[spBudget_Update]    Script Date: 4/13/2015 9:32:05 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spBudget_Update]
@ID		int,
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
UPDATE
	DT_Budgets
SET
	[ProjectID] = @ProjectID,
	[Revision] = @Revision,
	[PCNID] = @PCNID,
	[IsDefault] = @IsDefault,
	[IsActive] = @IsActive,
	[IsLocked] = @IsLocked,
	[Description] = @Description,
	[PreparedBy] = @PreparedBy,
	[Contingency] = @Contingency,
	[DateLastModified] = GETDATE(),
	[Clarification11000] = @Clarification11000,
	[Clarification12000] = @Clarification12000,
	[Clarification13000] = @Clarification13000,
	[Clarification14000] = @Clarification14000,
	[Clarification15000] = @Clarification15000,
	[Clarification16000] = @Clarification16000,
	[Clarification17000] = @Clarification17000,
	[Clarification18000] = @Clarification18000,
	[Clarification50000] = @Clarification50000
WHERE
	[ID] = @ID
GO

