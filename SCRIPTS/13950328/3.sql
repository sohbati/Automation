﻿USE [andicator]
GO

/****** Object:  View [dbo].[VIEW_REFERENCECYCLE]    Script Date: 06/17/2016 16:16:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE VIEW [dbo].[VIEW_REFERENCECYCLE]
AS
SELECT     ID, FIRSTREFERDATE, FIRSTFROMUSERID, FIRSTTOUSERID, SECONDFROMUSERID, SECONDTOUSERID, LETTERID,
                          (SELECT     NAME + ' ' + FAMILY + '(' + USERNAME + ')' AS EXPR1
                             FROM         dbo.USERS AS u
                             WHERE     (ID = ref.FIRSTFROMUSERID)) AS FIRSTFROMUSERID_DESC,
                          (SELECT     NAME + ' ' + FAMILY + '(' + USERNAME + ')' AS EXPR1
                             FROM         dbo.USERS AS u
                             WHERE     (ID = ref.FIRSTTOUSERID)) AS FIRSTTOUSERID_DESC,
                          (SELECT     NAME + ' ' + FAMILY + '(' + USERNAME + ')' AS EXPR1
                             FROM         dbo.USERS AS u
                             WHERE     (ID = ref.SECONDFROMUSERID)) AS SECONDFROMUSERID_DESC,
                          (SELECT     NAME + ' ' + FAMILY + '(' + USERNAME + ')' AS EXPR1
                             FROM         dbo.USERS AS u
                             WHERE     (ID = ref.SECONDTOUSERID)) AS SECONDTOUSERID_DESC,
                          (SELECT     LETTERNUMBER
                             FROM         dbo.LETTER AS L
                             WHERE     (ID = ref.LETTERID)) AS LETTERID_DESC,
                          (SELECT     DESCRIPTION
                             FROM         dbo.BASICINFO AS B
                             WHERE     (ID = ref.ACTION)) AS ACTION_DESC, SECONDREFERDATE, ACTIONDESCRIPTION, ARCHIVE, ACTION
FROM         dbo.REFERENCECYCLE AS ref

GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[23] 4[15] 2[35] 3) )"
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
         Begin Table = "ref"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 7
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 18
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 2100
         Width = 1500
         Width = 1500
         Width = 1500
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_REFERENCECYCLE'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'VIEW_REFERENCECYCLE'
GO

