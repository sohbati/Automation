USE [andicator]
GO

/****** Object:  View [dbo].[VIEW_LETTERNUMBERPATTERN]    Script Date: 06/17/2013 23:25:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
drop view [dbo].[VIEW_LETTERNUMBERPATTERN];
GO
CREATE VIEW [dbo].[VIEW_LETTERNUMBERPATTERN]
AS
SELECT     REGISTERDATE, RECIEVEPATTERN, SENDPATTERN, ID, RESETBY, LASTNUMBERRECIEVE, LASTNUMBERSEND, PATTERNNAME, CANSET, SYSTEMNAME
FROM         dbo.LETTERNUMBERPATTERN

GO 