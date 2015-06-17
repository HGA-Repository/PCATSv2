/****** Object:  Table [dbo].[DT_UserLoginInfo]    Script Date: 6/17/2015 7:59:09 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[DT_UserLoginInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[DateTime] [datetime] NOT NULL,
	[Log_In_Off] [bit] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


