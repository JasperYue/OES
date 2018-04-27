USE [oes]
GO
/****** Object:  StoredProcedure [dbo].[procUploadFilePath]    Script Date: 12/10/2016 16:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procUploadFilePath]
	@Path varchar(1024),
	@UserId int
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE
		[user]
	SET
		img_src = @Path
	WHERE
		id = @UserId;
	SET NOCOUNT OFF;
END
GO
