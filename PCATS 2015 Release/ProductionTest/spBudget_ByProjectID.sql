/****** Object:  StoredProcedure [dbo].[spBudget_ByProjectID]    Script Date: 4/13/2015 9:06:48 AM ******/
DROP PROCEDURE [dbo].[spBudget_ByProjectID]
GO

/****** Object:  StoredProcedure [dbo].[spBudget_ByProjectID]    Script Date: 4/13/2015 9:06:48 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spBudget_ByProjectID]
@ProjectID		int
AS
SELECT
	[ID],
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
FROM
	DT_Budgets
WHERE
	[ProjectID] = @ProjectID
	AND
	[Deleted] = 0
ORDER BY
	[Revision] ASC

GO

