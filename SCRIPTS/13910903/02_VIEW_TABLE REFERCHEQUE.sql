USE [andicator]
GO

/****** Object:  View [dbo].[VIEW_REFERCHEQUE]    Script Date: 11/24/2012 23:53:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VIEW_REFERCHEQUE]
AS
SELECT     dbo.REFERCHEQUE.ID, dbo.REFERCHEQUE.CHEQUEID, dbo.REFERCHEQUE.REFERDATE, dbo.REFERCHEQUE.REFERFROMUSER, 
                      dbo.REFERCHEQUE.REFERTOUSER, dbo.CHEQUE.MATURITYDATE, dbo.CHEQUE.CHEQUENUMBER, 
                      (CASE WHEN dbo.CHEQUE.PAYTYPE = 0 THEN 'چک' WHEN dbo.CHEQUE.PAYTYPE = 1 THEN 'نقد' END) AS PAYTYPE, 
                      USERSFROM.NAME + ' ' + USERSFROM.FAMILY + '(' + USERSFROM.USERNAME + ')' AS USERSFROM, 
                      USERSTO.NAME + ' ' + USERSTO.FAMILY + '(' + USERSTO.USERNAME + ')' AS USERSTO
FROM         dbo.REFERCHEQUE INNER JOIN
                      dbo.CHEQUE ON dbo.REFERCHEQUE.CHEQUEID = dbo.CHEQUE.ID INNER JOIN
                      dbo.USERS AS USERSFROM ON dbo.REFERCHEQUE.REFERFROMUSER = USERSFROM.ID INNER JOIN
                      dbo.USERS AS USERSTO ON dbo.REFERCHEQUE.REFERTOUSER = USERSTO.ID

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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "REFERCHEQUE"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 214
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CHEQUE"
            Begin Extent = 
               Top = 6
               Left = 252
               Bottom = 125
               Right = 458
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "USERSFROM"
            Begin Extent = 
               Top = 6
               Left = 496
               Bottom = 125
               Right = 677
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "USERSTO"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 219
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_REFERCHEQUE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_REFERCHEQUE'
GO


