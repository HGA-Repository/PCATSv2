USE [RSManpowerSchDb]
GO

/****** Object:  View [dbo].[vwVision_Budgets]    Script Date: 06/19/2013 08:38:28 ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[vwVision_Budgets]'))
DROP VIEW [dbo].[vwVision_Budgets]
GO

USE [RSManpowerSchDb]
GO

/****** Object:  View [dbo].[vwVision_Budgets]    Script Date: 06/19/2013 08:38:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE VIEW [dbo].[vwVision_Budgets]
AS

/*
SELECT top 1000 * FROM [dbo].[vwVision_Budgets]
SELECT 	COUNT(*) FROM [dbo].[vwVision_Budgets] --33142 
SELECT * FROM vwVision_Budgets where Project like '0.110128.11.0'
SELECT top 1000 * FROM [dbo].[vwVision_Budgets] where ISNUMERIC([Phase]) = 0
*/


	SELECT 
	
		Project
		, Phase
		, BudgetHrs
		, Budget
		, GroupCode = CASE
				WHEN a.GroupCode IS NOT NULL THEN a.GroupCode
				WHEN ISNUMERIC(Phase) = 1 AND Phase > 10000 THEN ( (Phase / 1000) * 1000 )
				ELSE null END	
	 
	FROM (
		SELECT
			bud.[WBS1] AS [Project]
			, Phase = CASE
				WHEN ovr.code is not null then ovr.code
				WHEN ISNUMERIC( LEFT(bud.[WBS3],5) ) = 1 then LEFT(bud.[WBS3],5)
				ELSE null
			end
			,bud.[HrsBud] AS [BudgetHrs]
			,bud.[BillBud] AS [Budget]
			, ovr.AccountGroup as GroupCode
		FROM
			[Vision].[HGAVISIONDATABASE].dbo.[LB] bud
			left join VisionMappingOverrides ovr on ISNUMERIC( bud.[WBS3] ) = 1 AND bud.[WBS1] = ovr.WBS1 and bud.WBS3 = ovr.WBS3
	) a WHERE Phase is not null
	





GO


