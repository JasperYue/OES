using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Common;
using Model;

namespace Dao
{
    public interface IExamDao
    {
        /// <summary>
        /// Query exam list in student main page
        /// </summary>
        /// <param name="request">Page parameters</param>
        /// <param name="response">TotalItem  on specfic conditions & ExamList</param>
        /// <returns>ExamList list</returns>
        List<ExamList> FindExamListByConditions(PassPageParams request, ReturnParams<ExamList> response);
        /// <summary>
        /// Query paper list in teacher main page 
        /// </summary>
        /// <param name="request">Page parameters</param>
        /// <param name="response">TotalItem on specfic conditions & ExamResult list</param>
        /// <returns>ExamResult list</returns>
        List<ExamResult> FindPaperListByCount(PassPageParams request, ReturnParams<ExamResult> response);
        /// <summary>
        /// Query attendence list in detail page
        /// </summary>
        /// <param name="request">Page parameters</param>
        /// <param name="response">TotalItem on specfic conditions & Attendance list</param>
        /// <returns>Attendance list</returns>
        List<Attendance> FindAttendanceByExamId(PassPageParams request, ReturnParams<Attendance> response);
        /// <summary>
        /// Get exam by examId
        /// </summary>
        /// <param name="id">ExamId</param>
        /// <returns>Exam with current id</returns>
        Exam GetExamById(int id);
        /// <summary>
        /// Find question library of specific exam with required id
        /// </summary>
        /// <param name="examId">Required examId</param>
        /// <param name="userId">UserId</param>
        /// <param name="answerStr">Users current answer str</param>
        /// <returns>Question library of current exam</returns>
        List<Question> FindQuestionListByExamId(int examId, int userId, out string answerStr);
        /// <summary>
        /// Insert current question answer str into DB
        /// </summary>
        /// <param name="examId">Required examId</param>
        /// <param name="userId">UserId</param>
        /// <param name="answerStr">Users current answer str</param>
        /// <returns>Successful or not</returns>
        bool InsertCurrentAnswerStr(int examId, int userId, string answerStr);
        /// <summary>
        /// Insert all question answer str and user score into DB
        /// </summary>
        /// <param name="examId">Required examId</param>
        /// <param name="userId">UserId</param>
        /// <param name="answerStr">Users current answer str</param>
        /// <param name="score">User score</param>
        /// <returns>Successful or not</returns>
        bool InsertExamScore(int examId, int userId, string userAnswer, int score);
        /// <summary>
        /// Load exam result of user, show the detail message of this exam answered by this user
        /// </summary>
        /// <param name="examId">Required examId</param>
        /// <param name="userId">UserId</param>
        /// <returns>Result</returns>
        Result GetUserExamResult(int examId, int userId);
        /// <summary>
        /// Load Notice of recent exam
        /// </summary>
        /// <returns>Notice list</returns>
        List<Exam> FindUndoExamList();
    }
}
