USE [oes]
GO
/****** Object:  StoredProcedure [dbo].[procGetSingleObject]    Script Date: 12/10/2016 16:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procGetSingleObject]
	@Tab varchar(max),
	@StrField varchar(max),
	@StrWhere varchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Sql nvarchar(max);
	
	SET @Sql = 'SELECT ' 
					+ @StrField + ' 
			    FROM ' 
					+ @Tab + ' 
			    WHERE '
					+ @StrWhere;
					
	EXEC(@Sql);
	SET NOCOUNT OFF;
END
GO
