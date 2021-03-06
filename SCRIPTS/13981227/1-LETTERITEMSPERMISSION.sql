/*
   Tuesday, March 17, 20206:26:55 PM
   User: sa
   Server: WINSEVENVM-PC
   Database: andicator
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
ALTER TABLE dbo.LETTERITEMSPERMISSION ADD
	INSURANCE_COMPANY tinyint NULL
GO
ALTER TABLE dbo.LETTERITEMSPERMISSION SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
