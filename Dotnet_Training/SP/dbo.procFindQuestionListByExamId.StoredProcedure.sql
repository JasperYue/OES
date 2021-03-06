USE [oes]
GO
/****** Object:  StoredProcedure [dbo].[procFindQuestionListByExamId]    Script Date: 12/10/2016 16:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procFindQuestionListByExamId]
	@ExamId int,
	@UserId int,
	@AnswerStr nvarchar(max) OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @Count int
	-- Load question list
    SELECT
		q.[id],
		[num],
		[title],
		[item_A],
		[item_B],
		[item_C],
		[item_D],
		[answer]
	FROM
		[paper] p,
		[question] q
	WHERE
		p.[question_id] = q.[id]
		AND
		p.[exam_id] = @ExamId;
	
	SELECT
		@Count = COUNT(1)
	FROM
		[result]
	WHERE
		[exam_id] = @ExamId
		AND
		[user_id] = @UserId;
	
	IF (@Count = 0)
	BEGIN
		INSERT INTO
			[result](user_id, exam_id, score)
		VALUES
			(@UserId, @ExamId, 0);
	END

	-- Load answerStr used to judge continue
	SELECT
		@AnswerStr = [answer_str]
	FROM
		[result]
	WHERE
		[exam_id] = @ExamId
		AND
		[user_id] = @UserId;

END
GO
