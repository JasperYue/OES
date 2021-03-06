USE [oes]
GO
/****** Object:  StoredProcedure [dbo].[procCommonPagination]    Script Date: 12/10/2016 16:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procCommonPagination]
	@Tab varchar(max),
	@StrField varchar(max),
	@StrWhere varchar(max),
	@PageNo int,
	@PageSize int,
	@Sort varchar(255),
	@TotalItem int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @MaxPage int,
			@StrSql nvarchar(max);
    
    SET @StrSql = 'SELECT 
				       @Count = COUNT(1) 
				   FROM '
					    + @Tab + ' 
				   WHERE '
					    + @StrWhere;
				   
    EXEC sp_executesql @StrSql, N'@Count int out', @TotalItem OUT
    
    IF (@TotalItem % @PageSize = 0)
    BEGIN
		SET @MaxPage = @TotalItem / @PageSize;
    END
    ELSE
    BEGIN
		SET @MaxPage = @TotalItem / @PageSize + 1;
    END
    
    IF (@PageNo < 1)
    BEGIN
		SET @PageNo = 1;
	end
	ELSE IF (@PageNo > @MaxPage)
	BEGIN
		SET @PageNo = @MaxPage;
	END
    
    SET @StrSql = 'SELECT * 
				   FROM
				      (SELECT 
					       ROW_NUMBER() 
					   OVER
						   (ORDER BY ' + @Sort + ') AS rownum,
						   ' + @StrField + ' 
				       FROM '
						   + @Tab + ' 
				       WHERE ' 
				           + @StrWhere + ') AS Dwhere
				   WHERE 
					   rownum BETWEEN ' + CAST(((@PageNo-1)*@PageSize + 1) AS nvarchar(20)) + ' AND ' + CAST((@PageNo*@PageSize) AS nvarchar(20));
    EXEC(@StrSql)

	SET NOCOUNT OFF;
END
GO
