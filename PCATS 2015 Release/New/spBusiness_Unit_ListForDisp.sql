USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spBusiness_Unit_ListAllForDisp]    Script Date: 5/22/2015 8:56:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spBusiness_Unit_ListAllForDisp]
AS
SELECT
	[Bus_Unit_ID],
	
	[Bus_Unit_Description]
FROM
	DT_Business_Unit



GO


