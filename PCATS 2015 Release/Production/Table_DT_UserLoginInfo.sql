CREATE TABLE [dbo].[DT_UserLoginInfo](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[LogInTime] [datetime] NOT NULL,
	[LogOFFTime] [datetime] NULL,
	[Log_In_Off] [bit] NOT NULL,
	[ProjectID] [int] NULL,
	[GroupTab] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


