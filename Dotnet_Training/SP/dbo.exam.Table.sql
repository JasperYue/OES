USE [oes]
GO
/****** Object:  Table [dbo].[exam]    Script Date: 12/10/2016 16:34:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[exam](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[num] [varchar](32) NOT NULL,
	[name] [varchar](32) NOT NULL,
	[description] [varchar](512) NULL,
	[single_score] [int] NOT NULL,
	[total_score] [int] NOT NULL,
	[pass_criteria] [int] NOT NULL,
	[need_quantity] [int] NOT NULL,
	[fact_quantity] [int] NOT NULL,
	[effective_time] [datetime] NOT NULL,
	[duration] [int] NOT NULL,
	[creator] [varchar](32) NOT NULL,
	[answer_str] [varchar](256) NOT NULL,
	[status] [int] NOT NULL,
	[create_time] [datetime] NOT NULL,
	[update_time] [datetime] NOT NULL,
 CONSTRAINT [PK_exam] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
