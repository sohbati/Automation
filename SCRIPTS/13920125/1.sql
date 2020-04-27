USE [andicator]
GO
/****** Object:  View [dbo].[VIEW_WORKINGSTATISTIC]    Script Date: 04/15/2013 17:27:24 ******/
 DROP VIEW [dbo].[VIEW_WORKINGSTATISTIC]
GO

/****** Object:  View [dbo].[VIEW_WORKINGSTATISTIC]    Script Date: 04/15/2013 17:26:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VIEW_WORKINGSTATISTIC]
AS
SELECT     dbo.USERS.NAME + ' ' + dbo.USERS.FAMILY + ' ( ' + dbo.USERS.USERNAME + ')' AS USERNAME,
                          (SELECT     COUNT(0) AS EXPR1
                             FROM         dbo.LETTER
                             WHERE     (ARCHIVE IS NULL OR
                                                   ARCHIVE = 0) AND (REFFERDATE < GETDATE()) AND (USERTREEID = dbo.USERTREE.ID)) AS CUR_LETTER_ALL,
                          (SELECT     COUNT(0) AS EXPR1
                             FROM         dbo.LETTER AS LETTER_5
                             WHERE     (ARCHIVE IS NULL OR
                                                   ARCHIVE = 0) AND (REFFERDATE < GETDATE() - CAST('1900-01-04' AS DATETIME)) AND (USERTREEID = dbo.USERTREE.ID)) 
                      AS CUR_LETTER_MARKED,
                          (SELECT     COUNT(0) AS EXPR1
                             FROM         dbo.LETTER AS LETTER_4
                             WHERE     (ARCHIVE IS NULL OR
                                                   ARCHIVE = 0) AND (REFFERDATE < GETDATE()) AND (USERTREEID = dbo.USERTREE.ID) AND (LETTERSTATEID = 6)) AS RATE_DEC_ALL,
                          (SELECT     COUNT(0) AS EXPR1
                             FROM         dbo.LETTER AS LETTER_3
                             WHERE     (ARCHIVE IS NULL OR
                                                   ARCHIVE = 0) AND (REFFERDATE < GETDATE() - CAST('1900-01-04' AS DATETIME)) AND (USERTREEID = dbo.USERTREE.ID) AND 
                                                   (LETTERSTATEID = 6)) AS RATE_DEC_MARKED,
                          (SELECT     COUNT(0) AS EXPR1
                             FROM         dbo.LETTER AS LETTER_2
                             WHERE     (ARCHIVE IS NULL OR
                                                   ARCHIVE = 0) AND (REFFERDATE < GETDATE()) AND (USERTREEID = dbo.USERTREE.ID) AND (LETTERSTATEID = 24)) 
                      AS RATE_DEC_ORAL_ALL,
                          (SELECT     COUNT(0) AS EXPR1
                             FROM         dbo.LETTER AS LETTER_1
                             WHERE     (ARCHIVE IS NULL OR
                                                   ARCHIVE = 0) AND (REFFERDATE < GETDATE() - CAST('1900-01-04' AS DATETIME)) AND (USERTREEID = dbo.USERTREE.ID) AND 
                                                   (LETTERSTATEID = 24)) AS RATE_DEC_ORAL_MARKED, dbo.USERTREE.ID,
                          (SELECT     COUNT(0) AS EXPR1
                             FROM         (SELECT     USERTREEID, PRICE, ID AS CHEQUEID,
                                                                               (SELECT     dbo.CHEQUE.PRICE - SUM(PRICE) AS EXPR1
                                                                                  FROM         dbo.CHEQUEREPLY
                                                                                  WHERE     (CHEQUEID = dbo.CHEQUE.ID)) AS REMAINED
                                                     FROM         dbo.CHEQUE) AS R_1
                             WHERE     (PRICE <> REMAINED) AND (USERTREEID = dbo.USERTREE.ID) AND EXISTS
                                                       (SELECT     ID, CHEQUEID, RECIEPTBILLNUMBER, ISSUEDATE, PRICE, DESCRIPTION, REGISTERDATE, REGISTRANTUSER
                                                          FROM         dbo.CHEQUEREPLY AS CHEQUEREPLY_2
                                                          WHERE     (CHEQUEID = R_1.CHEQUEID))) AS CHEQUE_HAS_REMAINDER,
                          (SELECT     COUNT(0) AS EXPR1
                             FROM         dbo.CHEQUE AS R
                             WHERE     (USERTREEID = dbo.USERTREE.ID) AND (NOT EXISTS
                                                       (SELECT     ID, CHEQUEID, RECIEPTBILLNUMBER, ISSUEDATE, PRICE, DESCRIPTION, REGISTERDATE, REGISTRANTUSER
                                                          FROM         dbo.CHEQUEREPLY AS CHEQUEREPLY_1
                                                          WHERE     (CHEQUEID = R.ID)))) AS CHEQUE_WHITHOUT_ANS, dbo.USERTREE.USERID
FROM         dbo.USERTREE LEFT OUTER JOIN
                      dbo.USERS ON dbo.USERTREE.USERID = dbo.USERS.ID
 