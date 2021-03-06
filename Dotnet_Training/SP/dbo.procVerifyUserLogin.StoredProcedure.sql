USE [oes]
GO
/****** Object:  StoredProcedure [dbo].[procVerifyUserLogin]    Script Date: 12/10/2016 16:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procVerifyUserLogin] 
	@Username varchar(32)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		[id],
		[name],
		[password],
		[role_name]
	FROM
		[user]
	WHERE
		name = @Username;
	SET NOCOUNT OFF;
END
GO
