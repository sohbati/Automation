USE [andicator];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER TABLE [dbo].[LETTERNUMBERPATTERN] ADD [CANSET] tinyint NULL
GO
ALTER TABLE [dbo].[LETTERNUMBERPATTERN] ALTER COLUMN [CANSET] tinyint NOT NULL
GO
ALTER TABLE [dbo].[LETTERNUMBERPATTERN] ADD [SYSTEMNAME] varchar(50) COLLATE SQL_Latin1_General_CP1256_CS_AS NULL
GO
