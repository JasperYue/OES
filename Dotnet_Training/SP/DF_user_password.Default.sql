USE [oes]
GO
/****** Object:  Default [DF_user_password]    Script Date: 12/10/2016 16:34:09 ******/
ALTER TABLE [dbo].[user] ADD  CONSTRAINT [DF_user_password]  DEFAULT ('e10adc3949ba59abbe56e057f20f883e') FOR [password]
GO
