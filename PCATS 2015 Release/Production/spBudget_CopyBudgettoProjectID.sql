/****** Object:  StoredProcedure [dbo].[spBudget_CopyBudgetToProject]    Script Date: 4/13/2015 9:27:40 AM ******/
DROP PROCEDURE [dbo].[spBudget_CopyBudgetToProject]
GO

/****** Object:  StoredProcedure [dbo].[spBudget_CopyBudgetToProject]    Script Date: 4/13/2015 9:27:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spBudget_CopyBudgetToProject]
@BudgetID int,
@ProjectToID int,
@Revision int
AS
DECLARE @NewBudgetID int

-- copy hte budget over
INSERT INTO [dbo].[DT_Budgets]
           ([ProjectID]
           ,[Revision]
           ,[PCNID]
           ,[IsDefault]
           ,[IsActive]
           ,[IsLocked]
           ,[Description]
           ,[PreparedBy]
           ,[Contingency]
		   ,[Clarification11000]
		   ,[Clarification12000]
		   ,[Clarification13000]
		   ,[Clarification14000]
		   ,[Clarification15000]
		   ,[Clarification16000]
		   ,[Clarification17000]
		   ,[Clarification18000]
		   ,[Clarification50000]
           ,[BudgetGUID]
           ,[Deleted]
           ,[DateLastModified]
           ,[DateCreated])
SELECT @ProjectToID
      ,@Revision
      ,0
      ,0
      ,0
      ,0
      ,[Description]
      ,[PreparedBy]
      ,[Contingency]
	  ,[Clarification11000]
	  ,[Clarification12000]
	  ,[Clarification13000]
	  ,[Clarification14000]
	  ,[Clarification15000]
	  ,[Clarification16000]
	  ,[Clarification17000]
	  ,[Clarification18000]
	  ,[Clarification50000]
      ,newid()
      ,[Deleted]
      ,getdate()
      ,getdate()
  FROM [dbo].[DT_Budgets] WHERE [ID] = @BudgetID

SET @NewBudgetID = scope_identity()

-- copy the budget lines
INSERT INTO [dbo].[DT_BudgetLines]
           ([BudgetID]
           ,[DeptGroup]
           ,[EntryLevel]
           ,[Task]
           ,[Category]
           ,[Activity]
           ,[WBS]
           ,[Description]
           ,[Quantity]
           ,[HoursEach]
           ,[TotalHours]
           ,[LoadedRate]
           ,[TotalDollars]
           ,[BareRate]
           ,[BareDollars]
           ,[LineGUID]
           ,[Deleted]
           ,[DateLastModified]
           ,[DateCreated])
SELECT @NewBudgetID
      ,[DeptGroup]
      ,[EntryLevel]
      ,[Task]
      ,[Category]
      ,[Activity]
      ,[WBS]
      ,[Description]
      ,[Quantity]
      ,[HoursEach]
      ,[TotalHours]
      ,[LoadedRate]
      ,[TotalDollars]
      ,[BareRate]
      ,[BareDollars]
      ,newid()
      ,[Deleted]
      ,getdate()
      ,getdate()
  FROM [dbo].[DT_BudgetLines] where [budgetid] = @Budgetid


-- copy the worksheet
INSERT INTO [dbo].[DT_BudgetWorksheets]
           ([BudgetID]
           ,[DeptGroup]
           ,[WorkGuid]
           ,[WBS]
           ,[ItemDescription]
           ,[Quantity]
           ,[Spec211]
           ,[Spec212]
           ,[Spec213]
           ,[Spec214]
           ,[Spec215]
           ,[Proc221]
           ,[Proc222]
           ,[Proc223]
           ,[Proc224]
           ,[Proc225]
           ,[Proc226]
           ,[Proc227]
           ,[Proc229]
           ,[Deleted]
           ,[DateLastModified]
           ,[DateCreated])
SELECT @NewBudgetID
      ,[DeptGroup]
      ,[WorkGuid]
      ,[WBS]
      ,[ItemDescription]
      ,[Quantity]
      ,[Spec211]
      ,[Spec212]
      ,[Spec213]
      ,[Spec214]
      ,[Spec215]
      ,[Proc221]
      ,[Proc222]
      ,[Proc223]
      ,[Proc224]
      ,[Proc225]
      ,[Proc226]
      ,[Proc227]
      ,[Proc229]
      ,[Deleted]
      ,getdate()
      ,getdate()
  FROM [dbo].[DT_BudgetWorksheets] where [budgetid] = @budgetid


-- copy the expenses
INSERT INTO [dbo].[DT_BudgetExpenseLines]
           ([BudgetID]
           ,[DeptGroup]
           ,[EntryLevel]
           ,[Code]
           ,[Description]
           ,[MarkUp]
           ,[UOMID]
           ,[DollarsEach]
           ,[Quantity]
           ,[MarkupDollars]
           ,[TotalDollars]
           ,[Deleted]
           ,[DateLastModified]
           ,[DateCreated])
SELECT @NewBudgetID
	  ,[DeptGroup]
      ,[EntryLevel]
      ,[Code]
      ,[Description]
      ,[MarkUp]
      ,[UOMID]
      ,[DollarsEach]
      ,[Quantity]
      ,[MarkupDollars]
      ,[TotalDollars]
      ,[Deleted]
      ,getdate()
      ,getdate()
  FROM [dbo].[DT_BudgetExpenseLines] WHERE [bUDGETID] = @BUDGETID


-- copy the expense worksheet
INSERT INTO [dbo].[DT_BudgetExpenseSheets]
           ([BudgetID]
           ,[DeptGroup]
           ,[WorkGuid]
           ,[Description]
           ,[Quantity]
           ,[RoundTrips]
           ,[People]
           ,[NumDays]
           ,[NumNights]
           ,[HoursPerDay]
           ,[TravelHours]
		  ,[E110]
		  ,[E120]
		  ,[E130]
		  ,[E140]
		  ,[E150]
		  ,[E160]
		  ,[E170]
		  ,[E180]
		  ,[E190]
          ,[Remarks]
		  ,[E281]
	      ,[E282]
		  ,[E283]
		  ,[E284]
		  ,[E290]
		  ,[E310]
		  ,[E320]
		  ,[E330] 
   		  ,[E340]
		  ,[E350]
		  ,[E541]
		  ,[E542]
          ,[E543]
		  ,[E561]
		  ,[E562]
		  ,[E580]
          ,[E591]
		  ,[E592]
		  ,[E593]
		  ,[E594]
		  ,[E595]
           ,[Deleted]
           ,[DateLastModified]
           ,[DateCreated])
SELECT @NewBudgetID
	 ,[DeptGroup]
      ,[WorkGuid]
      ,[Description]
      ,[Quantity]
      ,[RoundTrips]
      ,[People]
      ,[NumDays]
      ,[NumNights]
      ,[HoursPerDay]
      ,[TravelHours]
      ,[E110]
      ,[E120]
      ,[E130]
      ,[E140]
      ,[E150]
      ,[E160]
      ,[E170]
      ,[E180]
      ,[E190]
      ,[Remarks]
	    ,[E281]
	      ,[E282]
		  ,[E283]
		  ,[E284]
		  ,[E290]
		  ,[E310]
		  ,[E320]
		  ,[E330] 
   		  ,[E340]
		  ,[E350]
		  ,[E541]
		  ,[E542]
          ,[E543]
		  ,[E561]
		  ,[E562]
		  ,[E580]
          ,[E591]
		  ,[E592]
		  ,[E593]
		  ,[E594]
		  ,[E595]
      ,[Deleted]
      ,getdate()
      ,getdate()
  FROM [dbo].[DT_BudgetExpenseSheets] where [budgetid] = @Budgetid


GO

