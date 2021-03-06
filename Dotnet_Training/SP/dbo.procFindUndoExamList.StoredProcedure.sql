USE [oes]
GO
/****** Object:  StoredProcedure [dbo].[procFindUndoExamList]    Script Date: 12/10/2016 16:34:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[procFindUndoExamList]
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
		e.*
	FROM
		[exam] e
		LEFT JOIN [result] s ON e.[id] = s.[exam_id]
	WHERE
		s.[id] IS NULL
		AND 
		e.[effective_time] > GETDATE();
	SET NOCOUNT OFF;
END
GO
