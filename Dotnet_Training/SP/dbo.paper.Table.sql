USE [oes]
GO
/****** Object:  Table [dbo].[paper]    Script Date: 12/10/2016 16:34:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[paper](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[exam_id] [int] NOT NULL,
	[question_id] [int] NOT NULL,
 CONSTRAINT [PK_paper1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[paper]  WITH CHECK ADD  CONSTRAINT [FK_paper1_exam] FOREIGN KEY([exam_id])
REFERENCES [dbo].[exam] ([id])
GO
ALTER TABLE [dbo].[paper] CHECK CONSTRAINT [FK_paper1_exam]
GO
ALTER TABLE [dbo].[paper]  WITH CHECK ADD  CONSTRAINT [FK_paper1_question] FOREIGN KEY([question_id])
REFERENCES [dbo].[question] ([id])
GO
ALTER TABLE [dbo].[paper] CHECK CONSTRAINT [FK_paper1_question]
GO
