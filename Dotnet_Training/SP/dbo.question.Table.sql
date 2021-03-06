USE [oes]
GO
/****** Object:  Table [dbo].[question]    Script Date: 12/10/2016 16:34:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[question](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[num] [varchar](32) NOT NULL,
	[title] [varchar](256) NOT NULL,
	[item_A] [varchar](256) NOT NULL,
	[item_B] [varchar](256) NOT NULL,
	[item_C] [varchar](256) NOT NULL,
	[item_D] [varchar](256) NOT NULL,
	[refer_mark] [int] NOT NULL,
	[answer] [int] NOT NULL,
	[del_mark] [int] NOT NULL,
 CONSTRAINT [PK_question] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
