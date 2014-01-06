USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwVision_Expenses]    Script Date: 04/17/2013 13:07:24 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVision_Expenses]'))
DROP VIEW [dbo].[vwVision_Expenses]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwVision_Expenses]    Script Date: 04/17/2013 13:07:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





--select * from [Vision].[HGAVISIONDATABASE].dbo.[pr] where [wbs1] like '0.090114%'

--SELECT * FROM [dbo].[vwVision_Expenses]
CREATE VIEW [dbo].[vwVision_Expenses]
AS


SELECT
	ex.[wbs1]
	,ex.code_v2 as [CodeStrc]
	,SUM([Amount]) AS [Amount]
	,SUM([BillExt]) AS [BillExt]
FROM
(
	SELECT 
	v1.*
	, code_v2 = CASE
		WHEN m.NewCode > 10000 then 0
		WHEN m.NewCode is not null then m.NewCode
		ELSE 0 END 
	FROM (
		SELECT 
		act.*,
		isnull(m.NewCode,act.account) as code_v1
		FROM 
		(
			SELECT [wbs1], substring([Account],6,4) as account, Amount , BillExt , TransDate FROM [Vision].[HGAVISIONDATABASE].dbo.[LedgerMisc]
			UNION ALL
			SELECT [wbs1], substring([Account],6,4) as account, Amount , BillExt , TransDate FROM [Vision].[HGAVISIONDATABASE].dbo.[LedgerAP]
			UNION ALL 
			SELECT [wbs1], substring([Account],6,4) as account, Amount , BillExt , TransDate FROM [Vision].[HGAVISIONDATABASE].dbo.[LedgerMisc]
		) act
		left join CodeMappings m on act.account = m.OldCode and m.OldVersion = 0
	) v1 
	LEFT JOIN CodeMappings m on v1.code_v1 = m.OldCode and m.OldVersion = 1
	
) ex
GROUP BY ex.[wbs1], ex.code_v2




GO


