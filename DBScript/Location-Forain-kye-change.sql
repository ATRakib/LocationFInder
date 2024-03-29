/*
   Wednesday, January 24, 20241:56:09 PM
   User: sa
   Server: ATL11-PC\SQLEXPRESS01
   Database: LocationTracker
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Location
	DROP CONSTRAINT FK_Location_User
GO
ALTER TABLE dbo.[User] SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Location ADD CONSTRAINT
	FK_Location_User FOREIGN KEY
	(
	UserId
	) REFERENCES dbo.[User]
	(
	Id
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Location SET (LOCK_ESCALATION = TABLE)
GO
COMMIT






ahima, 7:32 PM
shohel.rana@amanknittings.com

kalam.azad@amanknittings.com
