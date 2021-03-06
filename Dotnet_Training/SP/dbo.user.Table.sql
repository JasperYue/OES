USE [oes]
GO
/****** Object:  Table [dbo].[user]    Script Date: 12/10/2016 16:34:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](32) NOT NULL,
	[password] [varchar](32) NOT NULL,
	[gender] [varchar](2) NULL,
	[email] [varchar](32) NULL,
	[tel] [varchar](11) NULL,
	[img_src] [varchar](1024) NULL,
	[role_name] [varchar](32) NOT NULL,
	[del_mark] [int] NOT NULL,
	[create_time] [datetime] NOT NULL,
	[update_time] [datetime] NOT NULL,
 CONSTRAINT [PK_user1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [CK_user] CHECK  (([gender]='男' OR [gender]='女'))
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [CK_user]
GO
