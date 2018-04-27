using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WcfService;
using Moq;
using Dao;
using Model;
using System.Data;
using CustomException;

namespace ServiceTest
{
    [TestFixture(Category = "student")]
    public class TestStudent
    {
        private IExamService examService;
        private Mock<IExamDao> examDao;
        private Dictionary<int, Exam> dicExam;
        private Dictionary<int, List<Question>> paper;
        private List<Exam> unDoExamList;
        private List<ExamResult> resultList;
        private List<Attendance> attendanceList;
        private List<ExamList> examAllList;
        private PassPageParams request;
        private ReturnParams<ExamList> respExamList;
        private ReturnParams<ExamResult> respExamResult;
        private ReturnParams<Attendance> respAttendance;

        #region data prepared
        private User user = new User()
        {
            Id = 2
        };
        private Exam exam1 = new Exam()
        {
            Id = 1,
            Num = "E00001",
            AnswerStr = "1=1&2=1&3=1",
            EffectiveTime = DateTime.Now.AddDays(1)
        };
        private Exam exam2 = new Exam()
        {
            Id = 2,
            Num = "E00002",
            AnswerStr = "1=1&2=1",
            EffectiveTime = DateTime.Now.AddDays(2)
        };
        private Exam exam3 = new Exam()
        {
            Id = 3,
            Num = "E00003",
            AnswerStr = "1=1&2=1",
            EffectiveTime = Convert.ToDateTime("2016-12-1 12:00:00")
        };
        private Exam exam4 = new Exam()
        {
            Id = 4,
            Num = "E00004",
            AnswerStr = "1=1&2=1",
            EffectiveTime = Convert.ToDateTime("2016-12-02 12:00:00")
        };
        private Exam exam5 = new Exam()
        {
            Id = 5,
            Num = "E00005",
            AnswerStr = "1=1&2=1&3=1&4=1",
            EffectiveTime = Convert.ToDateTime("2016-12-05 12:00:00")
        };
        private Question question1 = new Question()
        {
            Id = 1,
            Answer = 1
        };
        private Question question2 = new Question()
        {
            Id = 2,
            Answer = 1
        };
        private Question question3 = new Question()
        {
            Id = 3,
            Answer = 1
        };
        private Question question4 = new Question()
        {
            Id = 4,
            Answer = 1
        };
        private Result result1 = new Result() 
        {
            ExamId = 2,
            UserId = 2,
            AnswerStr = "1=1",
            Score = 0
        };
        private Result result2 = new Result()
        {
            ExamId = 3,
            UserId = 2,
            AnswerStr = "1=1&2=1",
            Score = 100
        };
        private ExamResult examResult1 = new ExamResult()
        {
            Num = "E00001",
            ExamineeCount = 30
        };
        private ExamResult examResult2 = new ExamResult()
        {
            Num = "E00002",
            ExamineeCount = 30
        };
        private Attendance attendance1 = new Attendance()
        {
            Result = "Pass",
            PassCriteria = 60
        };
        private Attendance attendance2 = new Attendance()
        {
            Result = "No Pass",
            PassCriteria = 50
        };
        private ExamList examList1 = new ExamList()
        {
            Id = 1
        };
        private ExamList examList2 = new ExamList()
        {
            Id = 2
        };
        private ExamList examList3 = new ExamList()
        {
            Id = 3
        };
        private ExamList examList4 = new ExamList()
        {
            Id = 4
        };
        private ExamList examList5 = new ExamList()
        {
            Id = 5
        };
        #endregion
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            examDao = new Mock<IExamDao>();
            examService = new ExamServiceImpl(examDao.Object);
            unDoExamList = new List<Exam>()
            {
                exam1,
                exam2,
                exam3,
                exam4,
                exam5
            };
            dicExam = new Dictionary<int, Exam>()
            {
                {1, exam1},
                {2, exam2},
                {3, exam3},
                {4, exam4},
                {5, exam5}
            };

            paper = new Dictionary<int, List<Question>>();

            paper.Add(exam1.Id, new List<Question>()
            {
                question1,
                question2,
                question3
            });
            paper.Add(exam2.Id, new List<Question>()
            {
                question1,
                question3
            });
            paper.Add(exam3.Id, new List<Question>()
            {
                question1,
                question4
            });
            paper.Add(exam4.Id, new List<Question>()
            {
                question1,
                question2
            });
            paper.Add(exam5.Id, new List<Question>()
            {
                question1,
                question2,
                question3,
                question4
            });

            resultList = new List<ExamResult>()
            {
                examResult1,
                examResult2
            };

            attendanceList = new List<Attendance>()
            {
                attendance1,
                attendance2
            };

            examAllList = new List<ExamList>()
            {
                examList1,
                examList2,
                examList3,
                examList4,
                examList5
            };

            request = new PassPageParams()
            {
                PageNo = 1,
                PageSize = 10
            };

            IExamService service = new ExamServiceImpl();
        }
        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            
        }

        [Test]
        public void TestFindExamListByConditionsSuccess()
        {
            examDao.Setup(p => p.FindExamListByConditions(It.IsAny<PassPageParams>(), It.IsAny<ReturnParams<ExamList>>())).Returns(examAllList);
            respExamList = examService.FindExamListByConditions(new PassPageParams());
            Assert.AreEqual(examAllList, respExamList.Result);
        }
        [Test]
        [ExpectedException(ExpectedException = typeof(ServiceException), ExpectedMessage = "No Record On This Condition!")]
        public void TestFindExamListByConditionsFail()
        {
            examDao.Setup(p => p.FindExamListByConditions(It.IsAny<PassPageParams>(), It.IsAny<ReturnParams<ExamList>>())).Returns(new List<ExamList>());
            examService.FindExamListByConditions(new PassPageParams());
        }
        
        [Test]
        [ExpectedException(ExpectedException = typeof(ServiceException), ExpectedMessage = "No Record On This Condition!")]
        public void TestFindPaperListByCountFail()
        {
            examDao.Setup(p => p.FindPaperListByCount(It.IsAny<PassPageParams>(), It.IsAny<ReturnParams<ExamResult>>())).Returns(new List<ExamResult>());
            examService.FindPaperListByCount(new PassPageParams());
        }
        [Test]
        public void TestFindPaperListByCountSuccess()
        {
            examDao.Setup(p => p.FindPaperListByCount(It.IsAny<PassPageParams>(), It.IsAny<ReturnParams<ExamResult>>())).Returns(resultList);
            respExamResult = examService.FindPaperListByCount(new PassPageParams());
            Assert.AreEqual(resultList, respExamResult.Result);
        }
        [Test]
        [ExpectedException(ExpectedException = typeof(ServiceException), ExpectedMessage = "No Record On This Condition!")]
        public void TestFindAttendenceByExamIdFail()
        {
            examDao.Setup(p => p.FindAttendanceByExamId(It.IsAny<PassPageParams>(), It.IsAny<ReturnParams<Attendance>>())).Returns(new List<Attendance>());
            examService.FindAttendenceByExamId(new PassPageParams());
        }
        [Test]
        public void TestFindAttendenceByExamIdSuccess()
        {
            examDao.Setup(p => p.FindAttendanceByExamId(It.IsAny<PassPageParams>(), It.IsAny<ReturnParams<Attendance>>())).Returns(attendanceList);
            respAttendance = examService.FindAttendenceByExamId(new PassPageParams());
            Assert.AreEqual(attendanceList, respAttendance.Result);
        }
        [Test]
        public void TestGetExamByIdSuccess()
        {
            int key = 2;
            examDao.Setup(p => p.GetExamById(key)).Returns(dicExam[key]);
            Exam exam = examService.GetExamById(key);
            Assert.AreSame(dicExam[key], exam);
        }
        [Test]
        [ExpectedException(ExpectedException = typeof(ServiceException), ExpectedMessage = "Entity Exam not found!")]
        public void TestGetExamByIdFail()
        {
            int key = 5;
            examDao.Setup(p => p.GetExamById(key)).Returns(dicExam[key]);
            Exam exam = examService.GetExamById(8);
        }
        [Test]
        public void TestFindQuestionListByExamIdSuccess()
        {
            int key = 1;
            string answerStr = dicExam[key].AnswerStr;
            examDao.Setup(p => p.FindQuestionListByExamId(key, user.Id, out answerStr)).Returns(paper[key]);
            List<Question> list = examService.FindQuestionListByExamId(key, user.Id, out answerStr);
            Assert.AreSame(paper[key], list);
        }
        [Test]
        [ExpectedException(ExpectedException = typeof(ServiceException), ExpectedMessage = "Query question list fail")]
        public void TestFindQuestionListByExamIdFail()
        {
            string answerStr = string.Empty;
            examDao.Setup(p => p.FindQuestionListByExamId(It.IsAny<int>(), user.Id, out answerStr)).Returns(new List<Question>());
            List<Question> list = examService.FindQuestionListByExamId(2, user.Id, out answerStr);
        }
        [Test]
        public void TestGetUserExamResultSuccess()
        {
            examDao.Setup(p => p.GetUserExamResult(2, 2)).Returns(result1);
            Result result = examService.GetUserExamResult(2, 2);
            Assert.AreSame(result1, result);
        }
        [Test]
        [ExpectedException(ExpectedException = typeof(ServiceException), ExpectedMessage = "Entity Result not found!")]
        public void TestGetUserExamResultFail()
        {
            examDao.Setup(p => p.GetUserExamResult(It.IsAny<int>(), It.IsAny<int>())).Returns(() => null);
            Result result = examService.GetUserExamResult(2, 3);
        }
        [Test]
        public void TestFindUndoExamListSuccess()
        {
            examDao.Setup(p => p.FindUndoExamList()).Returns(unDoExamList);
            List<Exam> list = examService.FindUndoExamList();
            list = list.Where(s => s.EffectiveTime > DateTime.Now ).ToList();
            List<Exam> biggerList = new List<Exam>() { exam1, exam2};
            Assert.AreEqual(2, list.Count);
            Assert.AreEqual(biggerList, list);
        }
        [Test]
        public void TestInsertCurrentAnswerStrSuccess()
        {
            examDao.Setup(p => p.InsertCurrentAnswerStr(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(true);
            examService.InsertCurrentAnswerStr(2, 2, "1=1&2=1");
        }
        [Test]
        [ExpectedException(ExpectedException = typeof(ServiceException), ExpectedMessage = "Insert current answerStr fail!")]
        public void TestInsertCurrentAnswerStrFail()
        {
            examDao.Setup(p => p.InsertCurrentAnswerStr(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>())).Returns(false);
            examService.InsertCurrentAnswerStr(2, 2, "1=1&2=1");
        }
        [Test]
        public void TestInsertExamScoreSuccess()
        {
            examDao.Setup(p => p.InsertExamScore(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>())).Returns(true);
            examService.InsertExamScore(2, 2, "1=1&2=1", 100);
        }
        [Test]
        [ExpectedException(ExpectedException = typeof(ServiceException), ExpectedMessage = "Insert exam result fail!")]
        public void TestInsertExamScoreFail()
        {
            examDao.Setup(p => p.InsertExamScore(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<int>())).Returns(false);
            examService.InsertExamScore(2, 2, "1=1&2=1", 50);
        }
    }
}
