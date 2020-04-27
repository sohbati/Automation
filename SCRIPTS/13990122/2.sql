USE [andicator]
GO

/****** Object:  View [dbo].[VIEW_LETTER]    Script Date: 4/12/2020 6:09:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VIEW_LETTER]
AS
SELECT     TOP (100) PERCENT (CASE WHEN REFFERDATE < GETDATE() - CAST('1900-01-04' AS DATETIME) THEN '*' END) AS STAR, dbo.LETTER.ID, 
                      dbo.LETTER.LETTERNUMBER, dbo.LETTER.LETTERDATE, dbo.fn_shamsi(dbo.LETTER.LETTERDATE) AS LETTERDATES, dbo.LETTER.LETTERSUBJECT, 
                      dbo.LETTER.INPUTREGISTERNUMBER, dbo.LETTER.SUMMARY, dbo.LETTER.INSURANCETYPEID, dbo.LETTER.INSURANCENUMBER, dbo.LETTER.LETTERSTATEID, 
                      dbo.LETTER.COMPANYID, dbo.LETTER.USERREPLYID, dbo.LETTER.LETTERTYPE, dbo.LETTER.CANCEL, 
                      BI1.DESCRIPTION + '(' + dbo.LETTER.INSURANCENUMBER + ')' AS INSURANCETYPEID_DESC, BI2.DESCRIPTION AS LETTERSTATEID_DESC, 
                      BI4.DESCRIPTION AS MANAGEMENTACTIONID_DESC, U.NAME + ' ' + U.FAMILY AS REFERENCEUSERID_DESC, BI3.COMPANYNAME AS COMPANYID_DESC, 
                      dbo.LETTER.INSURANCEDATE, dbo.fn_shamsi(dbo.LETTER.INSURANCEDATE) AS INSURANCEDATES, dbo.LETTER.RECIEVEDLETTERNUMBER, 
                      dbo.LETTER.RECIEVEDLETTERDATE, dbo.fn_shamsi(dbo.LETTER.RECIEVEDLETTERDATE) AS RECIEVEDLETTERDATES, dbo.LETTER.ARCHIVE, dbo.LETTER.COLOR, 
                      dbo.LETTER.FINALCONFIRM, U.ID AS EXPR1, dbo.USERTREE.ID AS EXPR2, dbo.USERTREE.USERID AS REFERENCEUSERID, dbo.LETTER.USERTREEID, 
                      dbo.LETTER.INSURANCECOMPANY, dbo.LETTER.AGENTID, dbo.LETTER.REFFERDATE, dbo.fn_shamsi(dbo.LETTER.REFFERDATE) AS REFFERDATES, 
                      dbo.LETTER.REFFERFROM, U2.NAME + '  ' + U2.FAMILY AS REFFERFROM_DESC, (CASE LETTERTYPE WHEN 2 THEN 'صارده' WHEN 1 THEN 'وارده' ELSE 'ناشناس' END)
                       AS LETTERTYPE_DESC, dbo.LETTER.FASTACTION, dbo.LETTER.PREVIOUSLETTERID, dbo.LETTER.NEXTLETTERID, dbo.LETTER.MANAGEMENTACTIONID, 
                      dbo.LETTER.GROUPID
FROM         dbo.BASICINFO AS BI1 RIGHT OUTER JOIN
                      dbo.USERTREE RIGHT OUTER JOIN
                      dbo.LETTER LEFT OUTER JOIN
                      dbo.USERS AS U2 ON dbo.LETTER.REFFERFROM = U2.ID ON dbo.USERTREE.ID = dbo.LETTER.USERTREEID ON 
                      BI1.ID = dbo.LETTER.INSURANCETYPEID LEFT OUTER JOIN
                      dbo.BASICINFO AS BI2 ON dbo.LETTER.LETTERSTATEID = BI2.ID LEFT OUTER JOIN
                      dbo.COMPANY AS BI3 ON dbo.LETTER.COMPANYID = BI3.ID LEFT OUTER JOIN
                      dbo.BASICINFO AS BI4 ON dbo.LETTER.MANAGEMENTACTIONID = BI4.ID LEFT OUTER JOIN
                      dbo.USERS AS U ON dbo.USERTREE.USERID = U.ID
ORDER BY dbo.LETTER.LETTERNUMBER, dbo.LETTER.LETTERDATE

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "BI1"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 114
               Right = 216
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "USERTREE"
            Begin Extent = 
               Top = 6
               Left = 254
               Bottom = 114
               Right = 405
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "LETTER"
            Begin Extent = 
               Top = 114
               Left = 38
               Bottom = 222
               Right = 244
            End
            DisplayFlags = 280
            TopColumn = 26
         End
         Begin Table = "U2"
            Begin Extent = 
               Top = 114
               Left = 282
               Bottom = 222
               Right = 454
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BI2"
            Begin Extent = 
               Top = 222
               Left = 38
               Bottom = 330
               Right = 216
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BI3"
            Begin Extent = 
               Top = 222
               Left = 254
               Bottom = 330
               Right = 411
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "BI4"
            Begin Extent = 
               Top = 330
               Left = 38
               Bottom = 438
               Right = 216
            End
            DisplayFlags = 280
            TopCo' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_LETTER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'lumn = 0
         End
         Begin Table = "U"
            Begin Extent = 
               Top = 330
               Left = 254
               Bottom = 438
               Right = 426
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 10
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_LETTER'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_LETTER'
GO

