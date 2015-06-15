USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwVision_Expenses]    Script Date: 05/28/2013 10:52:53 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVision_Expenses]'))
DROP VIEW [dbo].[vwVision_Expenses]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwVision_Expenses]    Script Date: 05/28/2013 10:52:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[vwVision_Expenses]
AS


SELECT
	ex.[wbs1]
	,CodeStrc = case 
		WHEN ex.code = 0 then 310
		WHEN ex.code < 1000 then ex.code
		else 310 end
	,SUM([Amount]) AS [Amount]
	,SUM([BillExt]) AS [BillExt]
FROM
	(

		SELECT [wbs1] ,convert(int,substring([Account],6,4)) as code ,[Amount] ,[BillExt] ,[TransDate] FROM [Vision].[HGAVISIONDATABASE].dbo.[LedgerEX] 
		UNION ALL
		SELECT [wbs1] ,convert(int,substring([Account],6,4)) as code ,[Amount] ,[BillExt] ,[TransDate] FROM [Vision].[HGAVISIONDATABASE].dbo.[LedgerAP] WHERE ([Desc2] NOT LIKE '%ICBilling%' OR [Desc2] Is NULL)
		UNION ALL
		SELECT [wbs1] ,convert(int,substring([Account],6,4)) as code ,[Amount] ,[BillExt] ,[TransDate] FROM [Vision].[HGAVISIONDATABASE].dbo.[LedgerMisc]

	) ex
GROUP BY
	ex.[wbs1], ex.code






GO


