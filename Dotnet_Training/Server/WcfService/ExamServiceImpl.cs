using System.Collections.Generic;
using System.Data;
using Common;
using Dao;
using Model;
using CustomException;

namespace WcfService
{

    public class ExamServiceImpl : IExamService
    {
        private IExamDao examDao = new ExamDaoImpl();

        public ExamServiceImpl()
        {

        }

        public ExamServiceImpl(IExamDao examDao)
        {
            this.examDao = examDao;
        }

        ReturnParams<ExamList> IExamService.FindExamListByConditions(PassPageParams request)
        {
            ReturnParams<ExamList> response = new ReturnParams<ExamList>();
            List<ExamList> examList = examDao.FindExamListByConditions(request, response);

            if (examList.Count == 0)
            {
                throw new ServiceException(Constants.NO_RECORD);
            }

            response.Result = examList;

            return response;
        }

        ReturnParams<ExamResult> IExamService.FindPaperListByCount(PassPageParams request)
        {
            ReturnParams<ExamResult> response = new ReturnParams<ExamResult>();
            List<ExamResult> examList = examDao.FindPaperListByCount(request, response);

            if (examList.Count == 0)
            {
                throw new ServiceException(Constants.NO_RECORD);
            }

            response.Result = examList;

            return response;
        }

        ReturnParams<Attendance> IExamService.FindAttendenceByExamId(PassPageParams request)
        {
            ReturnParams<Attendance> response = new ReturnParams<Attendance>();
            List<Attendance> attendanceList = examDao.FindAttendanceByExamId(request, response);

            if (attendanceList.Count == 0)
            {
                throw new ServiceException(string.Format(Constants.NO_RECORD));
            }

            response.Result = attendanceList;

            return response;
        }

        Exam IExamService.GetExamById(int id)
        {
            Exam exam = examDao.GetExamById(id);

            if (exam == null)
            {
                throw new ServiceException(string.Format(Constants.ENTITY_NOT_FOUND, Constants.ENTITY_EXAM));
            }

            return exam;
        }

        List<Question> IExamService.FindQuestionListByExamId(int examId, int userId, out string answerStr)
        {
            List<Question> questionList = examDao.FindQuestionListByExamId(examId, userId, out answerStr);

            if (questionList.Count == 0)
            {
                throw new ServiceException("Query question list fail");
            }

            return questionList;
        }

        void IExamService.InsertCurrentAnswerStr(int examId, int userId, string answerStr)
        {
            bool flag = examDao.InsertCurrentAnswerStr(examId, userId, answerStr);

            if (!flag)
            {
                throw new ServiceException("Insert current answerStr fail");
            }
        }

        void IExamService.InsertExamScore(int examId, int userId, string userAnswer, int score)
        {
            bool flag = examDao.InsertExamScore(examId, userId, userAnswer, score);

            if (!flag)
            {
                throw new ServiceException("Insert exam result fail");
            }
        }

        Result IExamService.GetUserExamResult(int examId, int userId)
        {
            Result result = examDao.GetUserExamResult(examId, userId);

            if (result == null)
            {
                throw new ServiceException(string.Format(Constants.ENTITY_NOT_FOUND, Constants.ENTITY_RESULT));
            }

            return result;
        }

        List<Exam> IExamService.FindUndoExamList()
        {
            return examDao.FindUndoExamList();
        }

    }
}
