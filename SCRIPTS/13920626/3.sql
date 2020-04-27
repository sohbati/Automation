USE [andicator];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER TABLE [dbo].[LETTER] ADD [MANAGEMENTACTIONID] int NULL
GO
EXEC [dbo].[sp_addextendedproperty] @name = N'MS_Description', @value = N'اقدام مدیریت', @level0type = N'USER', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'LETTER', @level2type = N'COLUMN', @level2name = N'MANAGEMENTACTIONID';
