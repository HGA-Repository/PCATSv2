CREATE PROCEDURE [dbo].[spRPRT_TravelExpense]
@BudgetID	int

AS

SELECT   
tblPivot.ID, tblPivot.Deptgroup, tblPivot.Description as WSDescription, tblPivot.Code,E.Description as CodeDescription ,
E.Description + ' ( '+tblPivot.Description + ')'as DetailDescription,
Quantity, tblPivot.Value as "No_On_ExpenseSheet", DollarsEach,MarkUp, 
--((tblPivot.Value*DollarsEach)+ (tblPivot.Value*DollarsEach*MarkUP/100)) as Total
MarkupDollars,(Quantity*tblPivot.Value*DollarsEach+MarkUPDollars) as Total
FROM   
  (SELECT
     CONVERT(sql_variant,ID) AS ID,
	 CONVERT(sql_variant,DeptGroup) AS DeptGroup,
	 --CONVERT(sql_variant,Description) AS Description,
	 Description,
	 --CONVERT(sql_variant,Quantity) AS Quantity,
	 Quantity AS Quantity,
	E110	AS	E110	,E120	AS	E120	,E130	AS	E130	,E140	AS	E140	,E150	AS	E150	,E160	AS	E160	,E170	AS	E170	,E180	AS	E180	,E190	AS	E190,
	--E220 as E220,
	E281	AS	E281	,E282	AS	E282	,E283	AS	E283	,E284	AS	E284	,E290	AS	E290	,
	E310	AS	E310	,E320	AS	E320	,E330	AS	E330	,E340	AS	E340	,E350	AS	E350	,
	
	E541	AS	E541	,E542	AS	E542	,E543	AS	E543,	E561	AS	E561	--E552 as E552, 
   from DT_BudgetExpenseSheets where BudgetID =@BudgetID and deleted = 0 ) Person
  UNPIVOT (Value For Code In (E110, E120, E130, E140, E150, E160, E170, E180, E190,
							--E220, E552,
							E281, E282, E283, E284, E290, 
							E310, E320, E330, E340, E350, 
							E541, E542, E543,  E561 
					
)) as tblPivot

  --left join SY_ExpenseAccounts E on tblPivot.Code= E.Code

  left join    (select Code, DollarsEach, Description, DeptGroup, MarkUp, MarkUPDollars from DT_BudgetExpenseLines where BudgetID =@BudgetID) E
   on (tblPivot.Code = E.Code and tblPivot.DeptGroup = E.DeptGroup)

  where tblPivot.Value !=0
  --order by tblPivot.ID
  --order by tblPivot.DeptGroup, tblPivot.Description, tblPivot.Code
   order by tblPivot.DeptGroup, tblPivot.Code
  -------------------------------------------------------------------
  -- There are some more Expense Code, may have to be added in Future

GO


