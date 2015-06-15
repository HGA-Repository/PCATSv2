USE [master]
GO
ALTER DATABASE [RSManpowerSchDb] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE
GO


USE [master]
GO

/****** Object:  Database [RSManpowerSchDb]    Script Date: 07/08/2013 10:47:59 ******/
IF  EXISTS (SELECT name FROM sys.databases WHERE name = N'RSManpowerSchDb')
DROP DATABASE [RSManpowerSchDb]
GO


RESTORE DATABASE [RSManpowerSchDb] FROM  DISK = N'C:\databases\PCATSDb.bak' WITH  FILE = 1,  MOVE N'RSManpowerSchDB' TO N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\RSManpowerSchDb.mdf',  MOVE N'RSManpowerSchDB_log' TO N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\RSManpowerSchDb_1.ldf',  NOUNLOAD,  REPLACE,  STATS = 10
GO


USE [RSManpowerSchDb]
GO
/****** Object:  User [RSMPUser]    Script Date: 07/08/2013 10:55:51 ******/
DROP USER [RSMPUser]
GO


USE [RSManpowerSchDb]
GO
CREATE USER [RSMPUser] FOR LOGIN [RSMPUser]
GO
USE [RSManpowerSchDb]
GO
EXEC sp_addrolemember N'db_owner', N'RSMPUser'
GO
