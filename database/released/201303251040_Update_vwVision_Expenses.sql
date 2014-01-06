USE [RSManpowerSchDb_test]
GO

/****** Object:  View [dbo].[vwVision_Expenses]    Script Date: 03/25/2013 10:22:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVision_Expenses]'))
DROP VIEW [dbo].[vwVision_Expenses]
GO

USE [RSManpowerSchDb_test]
GO

/****** Object:  View [dbo].[vwVision_Expenses]    Script Date: 03/25/2013 10:22:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




--select * from [Vision].[HGAVISIONDATABASE].dbo.[pr] where [wbs1] like '0.090114%'
CREATE VIEW [dbo].[vwVision_Expenses]
AS


SELECT  
	ex.[wbs1]
	,ex.[CodeStrc]
	,SUM([Amount]) AS [Amount]
	,SUM([BillExt]) AS [BillExt] 
FROM (

	SELECT 
		v.[wbs1]
		, m.NewCode as CodeStrc
		, Amount
		, BillExt
		, TransDate
	FROM [Vision].[HGAVISIONDATABASE].dbo.[LedgerEX] v
	left join CodeMappings m on substring([Account],6,4) = m.OldCode 


	UNION ALL

	SELECT
		[wbs1]
		, m.NewCode as CodeStrc
		,[Amount]
		,[BillExt]
		,[TransDate]
	FROM
		[Vision].[HGAVISIONDATABASE].dbo.[LedgerAP]
		left join CodeMappings m on substring([Account],6,4) = m.OldCode 
	WHERE
		[Desc2] NOT LIKE '%ICBilling%'
		
		
	UNION ALL
		
		
	SELECT
		[wbs1]
		, m.NewCode as CodeStrc
		,[Amount]
		,[BillExt]
		,[TransDate]
	FROM
		[Vision].[HGAVISIONDATABASE].dbo.[LedgerMisc]
		left join CodeMappings m on substring([Account],6,4) = m.OldCode 

) ex

GROUP BY
	ex.[wbs1], ex.[CodeStrc]


GO


