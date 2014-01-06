USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwVision_Expenses]    Script Date: 04/25/2013 11:07:00 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVision_Expenses]'))
DROP VIEW [dbo].[vwVision_Expenses]
GO

USE [RSManpowerSchDb_dev]
GO

/****** Object:  View [dbo].[vwVision_Expenses]    Script Date: 04/25/2013 11:07:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--select * from [Vision].[HGAVISIONDATABASE].dbo.[pr] where [wbs1] like '0.090114%'
CREATE VIEW [dbo].[vwVision_Expenses]
AS
SELECT
	ex.[wbs1]
	,ex.code as [CodeStrc]
	,SUM([Amount]) AS [Amount]
	,SUM([BillExt]) AS [BillExt]
FROM
	(

		SELECT 
		 [wbs1], [Amount] ,[BillExt] ,[TransDate], ISNULL(map_v1.NewCode, v1.code ) as code
		FROM (	
		
				
		
			SELECT 
				code = case 
					WHEN map_v1.NewCode is null THEN ag2.AcctNumber
					ELSE v1_wo.code END
				,[wbs1], [Amount] ,[BillExt] ,[TransDate]
			FROM (
			
			
				SELECT   
					code = case 
						WHEN map_v0.NewCode is not null then map_v0.NewCode
						WHEN substring([Account],6,4) = '0000' THEN '9031'
						ELSE substring([Account],6,4)
					END
					,[wbs1] , [Amount] ,[BillExt] ,[TransDate] 
				FROM (
					SELECT [wbs1] ,[Account] ,[Amount] ,[BillExt] ,[TransDate] FROM [Vision].[HGAVISIONDATABASE].dbo.[LedgerEX] --WHERE (Amount != 0 AND BillExt != 0)
					UNION ALL
					SELECT [wbs1] ,[Account] ,[Amount] ,[BillExt] ,[TransDate] FROM [Vision].[HGAVISIONDATABASE].dbo.[LedgerAP] WHERE ([Desc2] NOT LIKE '%ICBilling%' OR [Desc2] Is NULL) --AND (Amount != 0 AND BillExt != 0)
					UNION ALL
					SELECT [wbs1] ,[Account] ,[Amount] ,[BillExt] ,[TransDate] FROM [Vision].[HGAVISIONDATABASE].dbo.[LedgerMisc] --WHERE (Amount != 0 AND BillExt != 0)
				) vision
				left join CodeMappings map_v0 on map_v0.OldCode = FLOOR([Account]) and map_v0.OldVersion = 0
				
				
			) v1_wo
			
			LEFT JOIN codes_v1.SY_AccountGroups2 ag2 ON ag2.[StartNew] <= v1_wo.code AND ag2.[EndNew] >= v1_wo.code and ag2.ReportGroup = 1 AND ag2.[DepartmentID] < 0 and SpecialGroup = 0
			LEFT JOIN CodeMappings map_v1 on v1_wo.code = map_v1.OldCode and map_v1.OldVersion = 1
			
			
		) v1
		
		LEFT JOIN CodeMappings map_v1 on v1.code = map_v1.OldCode and map_v1.OldVersion = 1

	) ex
GROUP BY
	ex.[wbs1], ex.code

GO

