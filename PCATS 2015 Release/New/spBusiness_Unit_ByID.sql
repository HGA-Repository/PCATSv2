USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spBusiness_Unit_ByID]    Script Date: 5/22/2015 8:54:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spBusiness_Unit_ByID]
@ID		int
AS
SELECT
	[Bus_Unit_ID],
	
	[Bus_Unit_Description]
	
FROM
	DT_Business_Unit
WHERE
	[Bus_Unit_ID] = @ID


GO


