USE [oes]
GO
/****** Object:  StoredProcedure [dbo].[procFindExamResult]    Script Date: 12/10/2016 16:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procFindExamResult]
	@ExamId int,
	@UserId int
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		s.[answer_str],
		s.[score]
	FROM 
		exam e
		LEFT JOIN result s ON e.id = s.exam_id 
	WHERE
		s.user_id = @UserId
		AND
		s.exam_id = @ExamId;
	SET NOCOUNT OFF;
END
GO
