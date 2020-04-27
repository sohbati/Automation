USE [andicator]
GO

/****** Object:  Table [dbo].[ATTACHMENTCHEQUE]    Script Date: 06/11/2017 22:38:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ATTACHMENTCHEQUE](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CHEQUEID] [int] NOT NULL,
	[CONTENT] [image] NULL,
	[FILENAME] [varchar](250) NULL,
 CONSTRAINT [PK_ATTACHMENTCHEQUE] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[ATTACHMENTCHEQUE]  WITH NOCHECK ADD  CONSTRAINT [FK_ATTACHMENT_CHEQUE] FOREIGN KEY([CHEQUEID])
REFERENCES [dbo].[CHEQUE] ([ID])
GO

ALTER TABLE [dbo].[ATTACHMENTCHEQUE] CHECK CONSTRAINT [FK_ATTACHMENT_CHEQUE]
GO

