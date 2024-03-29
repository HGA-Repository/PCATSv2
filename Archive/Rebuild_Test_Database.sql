
USE [master]
GO


BACKUP DATABASE [RSManpowerSchDb] TO  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\Backup\pcats_temp.bak' WITH NOFORMAT, INIT,  NAME = N'RSManpowerSchDb-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO


/*
if exists(select * from sys.databases where name = 'RSManpowerSchDb_test')
	ALTER DATABASE [RSManpowerSchDb_test] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE

if exists(select * from sys.databases where name = 'RSManpowerSchDb_test')
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'RSManpowerSchDb_test'
GO
if exists(select * from sys.databases where name = 'RSManpowerSchDb_test')
	DROP DATABASE [RSManpowerSchDb_test]
GO

RESTORE DATABASE [RSManpowerSchDb_test] FROM  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\Backup\pcats_temp.bak' WITH  FILE = 1,  MOVE N'RSManpowerSchDB' TO N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\RSManpowerSchDb_test.mdf',  MOVE N'RSManpowerSchDB_log' TO N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\RSManpowerSchDb_test_1.ldf',  NOUNLOAD,  REPLACE,  STATS = 10
GO

UPDATE RSManpowerSchDb_test.dbo.DT_Users SET Password = 'CW4WBZTaeRc='
GO

*/


if exists(select * from sys.databases where name = 'RSManpowerSchDb_dev')
	ALTER DATABASE [RSManpowerSchDb_dev] SET  SINGLE_USER WITH ROLLBACK IMMEDIATE

if exists(select * from sys.databases where name = 'RSManpowerSchDb_dev')
	EXEC msdb.dbo.sp_delete_database_backuphistory @database_name = N'RSManpowerSchDb_dev'
GO
if exists(select * from sys.databases where name = 'RSManpowerSchDb_dev')
	DROP DATABASE [RSManpowerSchDb_dev]
GO


RESTORE DATABASE [RSManpowerSchDb_dev] FROM  DISK = N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\Backup\pcats_temp.bak' WITH  FILE = 1,  MOVE N'RSManpowerSchDB' TO N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\RSManpowerSchDb_dev.mdf',  MOVE N'RSManpowerSchDB_log' TO N'C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\RSManpowerSchDb_dev_1.ldf',  NOUNLOAD,  REPLACE,  STATS = 10
GO


UPDATE RSManpowerSchDb_dev.dbo.DT_Users SET Password = 'CW4WBZTaeRc='
GO