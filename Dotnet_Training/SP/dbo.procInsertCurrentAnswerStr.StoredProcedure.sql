USE [oes]
GO
/****** Object:  StoredProcedure [dbo].[procInsertCurrentAnswerStr]    Script Date: 12/10/2016 16:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procInsertCurrentAnswerStr]
	@ExamId int,
	@UserId int,
	@AnswerStr varchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	UPDATE
		[result]
	SET
		[answer_str] = @AnswerStr
	WHERE
		[user_id] = @UserId
		AND
		[exam_id] = @ExamId;
	SET NOCOUNT OFF;
END
GO
