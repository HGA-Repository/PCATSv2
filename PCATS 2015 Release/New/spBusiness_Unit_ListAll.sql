USE [RSManpowerSchDbTest]
GO

/****** Object:  StoredProcedure [dbo].[spBusiness_Unit_ListAll ]    Script Date: 5/22/2015 8:55:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[spBusiness_Unit_ListAll ]
AS
SELECT
	[Bus_Unit_ID],
	
	[Bus_Unit_Description]
FROM
	DT_Business_Unit



GO


