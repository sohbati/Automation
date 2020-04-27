USE [andicator];
GO
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
ALTER VIEW [dbo].[VIEW_REFERLETTER]
AS
SELECT     dbo.REFERLETTER.ID, dbo.REFERLETTER.LETTERID, dbo.REFERLETTER.REFERDATE, dbo.REFERLETTER.REFERFROMUSER, 
                      dbo.REFERLETTER.REFERTOUSER, dbo.LETTER.LETTERDATE, dbo.LETTER.LETTERNUMBER, 
                      USERSFROM.NAME + ' ' + USERSFROM.FAMILY + '(' + USERSFROM.USERNAME + ')' AS USERSFROM, 
                      USERSTO.NAME + ' ' + USERSTO.FAMILY + '(' + USERSTO.USERNAME + ')' AS USERSTO
FROM          dbo.REFERLETTER LEFT OUTER JOIN
                      dbo.LETTER ON dbo.REFERLETTER.LETTERID = dbo.LETTER.ID LEFT OUTER JOIN
                      dbo.USERS AS USERSFROM ON dbo.REFERLETTER.REFERFROMUSER = USERSFROM.ID LEFT OUTER JOIN
                      dbo.USERS AS USERSTO ON dbo.REFERLETTER.REFERTOUSER = USERSTO.ID
GO