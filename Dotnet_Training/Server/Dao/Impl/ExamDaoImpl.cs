using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Common;
using Model;

namespace Dao
{
    public class ExamDaoImpl : IExamDao
    {
        List<ExamList> IExamDao.FindExamListByConditions(PassPageParams request, ReturnParams<ExamList> response)
        {
            string tab = "[exam] e LEFT JOIN [result] s ON e.id = s.exam_id AND s.user_id = " + request.UserId;
            string strField = "e.[id], [name], [num], [effective_time], [duration], [pass_criteria], CASE WHEN ISNULL(s.[score], -1) = -1 " +
                              "THEN '-/' + CAST([total_score] AS varchar(50))" +
                              "ELSE CAST(s.[score] AS varchar(50)) + '/' + CAST([total_score] AS varchar(50)) END AS 'score'";
            if (request.Sort == null)
            {
                request.Sort = "s.[score]/e.[pass_criteria] DESC";
            }

            string strWhere = " AND e.status = 1 ";

            if (!request.StrWhere.Contains(strWhere))
            {
                request.StrWhere += strWhere;
            }

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter(Constants.DB_TAB, tab);
            param[1] = new SqlParameter(Constants.DB_FIELD, strField);
            param[2] = new SqlParameter(Constants.DB_WHERE, request.StrWhere);
            param[3] = new SqlParameter(Constants.DB_PAGE_NO, request.PageNo);
            param[4] = new SqlParameter(Constants.DB_PAGE_SIZE, request.PageSize);
            param[5] = new SqlParameter(Constants.DB_SORT, request.Sort);
            param[6] = new SqlParameter(Constants.DB_TOTAL_ITEM, response.TotalItem);
            param[6].Direction = ParameterDirection.Output;
            DataSet ds = SqlHelper.ExecuteDataSetProcedure("procCommonPagination", param);
            int totalItem;
            if (int.TryParse(param[6].Value.ToString(), out totalItem))
            {
                response.TotalItem = totalItem;
            }
            if (ds.Tables.Count != 0)
            {
                DataTable dt = ds.Tables[0];
                dt.Columns.Add("status", typeof(string));
                foreach (DataRow dr in dt.Rows)
                {
                    string content = string.Empty;
                    int passCriteria;
                    int duration;
                    if (int.TryParse(dr["pass_criteria"].ToString(), out passCriteria) && int.TryParse(dr["duration"].ToString(), out duration))
                    {
                        string score = dr["score"].ToString();
                        string str = score.Split(Constants.SIGN_SLASH)[0];

                        bool timeDiffence = DateTime.Compare(Convert.ToDateTime(dr["effective_time"].ToString()).AddMinutes(duration), DateTime.Now) > 0;

                        if ('-'.Equals(str[0]))
                        {
                            content = timeDiffence ? Status.Do_it.ToString().Replace("_", " ") : Status.Not_Attend.ToString().Replace("_", " ");
                        }
                        else
                        {
                            int currentScore = Convert.ToInt32(str);
                            // if score ==0 && current time between duration
                            content = (timeDiffence && currentScore == 0 ? Status.Continue
                                                   : currentScore < passCriteria ? Status.No_Pass : Status.Pass).ToString().Replace("_", " ");
                        }
                        dr["status"] = content;
                    }
                }
            }

            return SqlHelper.PutAllVal(new ExamList(), ds);
        }

        List<ExamResult> IExamDao.FindPaperListByCount(PassPageParams request, ReturnParams<ExamResult> response)
        {
            string tab = "exam e, (" +
                         "SELECT rt.exam_id, AVG(rt.score) AS average_score, COUNT(rt.user_id) AS examinee_count " +
                         "FROM result rt " +
                         "GROUP BY rt.exam_id ) s LEFT JOIN (" + 
                         "SELECT rt.exam_id, COUNT(*) AS qualified_num " +
                         "FROM result rt, exam e " +
                         "WHERE  e.id = rt.exam_id  AND rt.score >= e.pass_criteria " +
                         "GROUP BY rt.exam_id ) rt ON s.exam_id = rt.exam_id";
            string strField = "s.exam_id, name AS exam_name, num, effective_time, fact_quantity, average_score, examinee_count, " +
                              "qualified_num, (CAST(qualified_num/CAST(examinee_count AS float)*100 AS varchar(50))+ '%') AS pass_rate";
            if (request.Sort == null)
            {
                request.Sort = "[num] ASC";
            }

            string strWhere = " e.id = s.exam_id AND GETDATE() > (SELECT DATEADD(hour, e.duration/60.0, e.effective_time))";

            if (string.IsNullOrEmpty(request.StrWhere) || !request.StrWhere.Contains(strWhere))
            {
                strWhere += request.StrWhere;
            }
            request.StrWhere = strWhere;

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter(Constants.DB_TAB, tab);
            param[1] = new SqlParameter(Constants.DB_FIELD, strField);
            param[2] = new SqlParameter(Constants.DB_WHERE, request.StrWhere);
            param[3] = new SqlParameter(Constants.DB_PAGE_NO, request.PageNo);
            param[4] = new SqlParameter(Constants.DB_PAGE_SIZE, request.PageSize);
            param[5] = new SqlParameter(Constants.DB_SORT, request.Sort);
            param[6] = new SqlParameter(Constants.DB_TOTAL_ITEM, response.TotalItem);
            param[6].Direction = ParameterDirection.Output;
            DataSet ds = SqlHelper.ExecuteDataSetProcedure("procCommonPagination", param);
            int totalItem = -1;
            if (int.TryParse(param[6].Value.ToString(), out totalItem))
            {
                response.TotalItem = totalItem;
            }
            return SqlHelper.PutAllVal(new ExamResult(), ds);
        }

        List<Attendance> IExamDao.FindAttendanceByExamId(PassPageParams request, ReturnParams<Attendance> response)
        {
            string tab = " exam e, [user] u, result s ";
            string strField = "u.name, e.pass_criteria,  CAST(s.score AS varchar(50)) + '/' + CAST(e.total_score AS varchar(50)) AS score, " +
                              "CASE WHEN s.score >= e.pass_criteria " +
                              "THEN 'Pass' " +
                              "ELSE 'No Pass' END AS result ";
            if (request.Sort == null)
            {
                request.Sort = "u.[name] ASC";
            }

            string strWhere = " AND u.id = s.user_id AND e.id = s.exam_id ";

            if (!request.StrWhere.Contains(strWhere))
            {
                request.StrWhere += strWhere;
            }

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter(Constants.DB_TAB, tab);
            param[1] = new SqlParameter(Constants.DB_FIELD, strField);
            param[2] = new SqlParameter(Constants.DB_WHERE, request.StrWhere);
            param[3] = new SqlParameter(Constants.DB_PAGE_NO, request.PageNo);
            param[4] = new SqlParameter(Constants.DB_PAGE_SIZE, request.PageSize);
            param[5] = new SqlParameter(Constants.DB_SORT, request.Sort);
            param[6] = new SqlParameter(Constants.DB_TOTAL_ITEM, response.TotalItem);
            param[6].Direction = ParameterDirection.Output;
            DataSet ds = SqlHelper.ExecuteDataSetProcedure("procCommonPagination", param);
            int totalItem = -1;
            if (int.TryParse(param[6].Value.ToString(), out totalItem))
            {
                response.TotalItem = totalItem;
            }
            return SqlHelper.PutAllVal(new Attendance(), ds);
        }

        Exam IExamDao.GetExamById(int id)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter(Constants.DB_TAB, "[exam]");
            param[1] = new SqlParameter(Constants.DB_FIELD, "[id], [num], [name], [effective_time], [duration], [fact_quantity], [total_score], [answer_str], [single_score]");
            param[2] = new SqlParameter(Constants.DB_WHERE, "id = " + id);
            DataSet ds = SqlHelper.ExecuteDataSetProcedure("procGetSingleObject", param);
            List<Exam> examList = SqlHelper.PutAllVal(new Exam(), ds);
            Exam exam = null;
            if (examList.Count != 0)
            {
                exam = examList[0];
            }
            return exam;
        }

        List<Question> IExamDao.FindQuestionListByExamId(int examId, int userId, out string answerStr)
        {
            answerStr = string.Empty;
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter(Constants.DB_EXAM_ID, examId);
            param[1] = new SqlParameter(Constants.DB_USER_ID, userId);
            param[2] = new SqlParameter(Constants.DB_EXAM_ANSWER, SqlDbType.VarChar, 4000);
            param[2].Value = answerStr;
            
            param[2].Direction = ParameterDirection.Output;
            DataSet ds = SqlHelper.ExecuteDataSetProcedure("procFindQuestionListByExamId", param);
            answerStr = param[2].Value.ToString();
            return SqlHelper.PutAllVal(new Question(), ds);
        }

        bool IExamDao.InsertCurrentAnswerStr(int examId, int userId, string answerStr)
        {
            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter(Constants.DB_EXAM_ID, examId);
            param[1] = new SqlParameter(Constants.DB_USER_ID, userId);
            param[2] = new SqlParameter(Constants.DB_EXAM_ANSWER, answerStr);
            return SqlHelper.ExecteNonQueryProcedure("procInsertCurrentAnswerStr", param) == -1;
        }

        bool IExamDao.InsertExamScore(int examId, int userId, string userAnswer, int score)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter(Constants.DB_EXAM_ID, examId);
            param[1] = new SqlParameter(Constants.DB_USER_ID, userId);
            param[2] = new SqlParameter(Constants.DB_EXAM_ANSWER, userAnswer);
            param[3] = new SqlParameter(Constants.DB_RESULT_SCORE, score);
            return SqlHelper.ExecteNonQueryProcedure("procInsertExamScore", param) == -1;
        }

        Result IExamDao.GetUserExamResult(int examId, int userId)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter(Constants.DB_EXAM_ID, examId);
            param[1] = new SqlParameter(Constants.DB_USER_ID, userId);
            DataSet ds = SqlHelper.ExecuteDataSetProcedure("procFindExamResult", param);
            List<Result> resultList = SqlHelper.PutAllVal(new Result(), ds);
            Result result = null;
            if (resultList.Count != 0)
            {
                result = resultList[0];
            }
            return result;
        }

        List<Exam> IExamDao.FindUndoExamList()
        {
            DataSet ds = SqlHelper.ExecuteDataSetProcedure("procFindUndoExamList");
            return SqlHelper.PutAllVal(new Exam(), ds);
        }
    }
}
