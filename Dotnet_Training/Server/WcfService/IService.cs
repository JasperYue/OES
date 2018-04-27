using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Model;
using System.Drawing;
using System.IO;
using DI;

namespace WcfService
{
    [ServiceContract]
    public interface IExamService
    {
        /// <summary>
        /// Query exam list in student main page
        /// </summary>
        /// <param name="request">Page parameters</param>
        /// <returns>TotalItem on specfic conditions & Result list</returns>
        [OperationContract]
        ReturnParams<ExamList> FindExamListByConditions(PassPageParams request);
        /// <summary>
        /// Query paper list in teacher main page
        /// </summary>
        /// <param name="request">Page parameters</param>
        /// <returns>TotalItem on specfic conditions & Result list</returns>
        [OperationContract]
        ReturnParams<ExamResult> FindPaperListByCount(PassPageParams request);
        /// <summary>
        /// Query attendence list in detail page
        /// </summary>
        /// <param name="request">Page parameters</param>
        /// <returns>TotalItem on specfic conditions & Result list</returns>
        [OperationContract]
        ReturnParams<Attendance> FindAttendenceByExamId(PassPageParams request);
        /// <summary>
        /// Get exam by examId
        /// </summary>
        /// <param name="id">ExamId</param>
        /// <returns>Exam with current id</returns>
        [OperationContract]
        Exam GetExamById(int id);
        /// <summary>
        /// Find question library of specific exam with required id
        /// </summary>
        /// <param name="examId">Required examId</param>
        /// <param name="userId">UserId</param>
        /// <param name="answerStr">Users current answer str</param>
        /// <returns>Question library of current exam</returns>
        [OperationContract]
        List<Question> FindQuestionListByExamId(int examId, int userId, out string answerStr);
        /// <summary>
        /// Insert current question answer str into DB
        /// </summary>
        /// <param name="examId">Required examId</param>
        /// <param name="userId">UserId</param>
        /// <param name="answerStr">Users current answer str</param>
        [OperationContract]
        void InsertCurrentAnswerStr(int examId, int userId, string answerStr);
        /// <summary>
        /// Insert all question answer str and user score into DB
        /// </summary>
        /// <param name="examId">Required examId</param>
        /// <param name="userId">UserId</param>
        /// <param name="answerStr">Users current answer str</param>
        /// <param name="score">User score</param>
        [OperationContract]
        void InsertExamScore(int examId, int userId, string userAnswer, int score);
        /// <summary>
        /// Load exam result of user, show the detail message of this exam answered by this user
        /// </summary>
        /// <param name="examId">Required examId</param>
        /// <param name="userId">UserId</param>
        /// <returns>Result</returns>
        [OperationContract]
        Result GetUserExamResult(int examId, int userId);
        /// <summary>
        /// Load Notice of recent exam
        /// </summary>
        /// <returns>Notice list</returns>
        [OperationContract]
        List<Exam> FindUndoExamList();
    }

    [ServiceContract]
    public interface IUserService
    {
        /// <summary>
        /// User logon system
        /// </summary>
        [OperationContract]
        User VerifyUserLogOn(string userName, string password);
    }

    [ServiceContract]
    public interface IFileService
    {
        /// <summary>
        /// Upload file
        /// </summary>
        [OperationContract(IsOneWay = true)]
        void UploadFile(FileUploadData data);
        /// <summary>
        /// Get current upload progress
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        int GetUploadFileInfo(string id);
        /// <summary>
        /// Get current user icon
        /// </summary>
        /// <param name="userId">UserId</param>
        /// <returns>Image bitmap</returns>
        [OperationContract]
        Bitmap GetUserIcon(int userId);
    }

}
