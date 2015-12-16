
/****** Object:  StoredProcedure [dbo].[spProject_ByID_Description]    Script Date: 7/8/2015 12:30:06 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spProject_ByID_Description]
@ID		int
AS
SELECT
	p.[ID],
	p.[Number],
	p.[Description],
	p.[CustomerID],
	c.[Name] as [CustomerName],
	p.[LocationID]
	,l.[City]
	,l.[StateID],
	s.[Name] as [State]
FROM
	DT_Projects p left join dt_Customers c on p.[customerID] = c.ID
	left join dt_Locations l on p.[LocationID]= l.[ID]
	left join sy_states s on l.[StateID] = s.[ID]
WHERE
	p.[ID] = @ID

GO

