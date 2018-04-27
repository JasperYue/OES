using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common;
using CustomException;
using UI.Properties;
using UI.ExamService;
using System.ComponentModel;

namespace UI
{
    public partial class FormTakeExam : BaseForm
    {
        private Image wrongImage = Resources.ICN_Wrong_15x15;
        private Image defaultImage = Resources.BTN_Radio_Unselected_16x16_png;
        private Image selectedImage = Resources.BTN_Radio_Selected_16x16_png;
        private ExamServiceClient examService = new ExamServiceClient();
        private Timer tmr = new Timer();
        private Exam exam;
        private List<Question> questionList;
        private int currentNum;
        private string answerStr;

        public FormTakeExam()
        {
            InitializeComponent();
        }

        #region Load ShowInfo
        /// <summary>
        /// Load information of exam description
        /// </summary>
        public void ShowInfo(int id)
        {
            try
            {
                exam = examService.GetExamById(id);
                lblName.Text += exam.Name;
                lblNum.Text += exam.Num;
                lblStartTime.Text += exam.EffectiveTime;
                lblEndTime.Text += exam.EffectiveTime.AddMinutes(exam.Duration);
                lblDuration.Text += exam.Duration + " min";
                lblScore.Text += exam.TotalScore;
                lblQuantity.Text += exam.FactQuantity;

                lblTimer.Text = DateTime.Compare(exam.EffectiveTime, DateTime.Now) > 0
                                            ? DateDiff(DateTime.Now, exam.EffectiveTime, true)
                                            : Constants.TIP_TIME_HASDAY;

                TimerStart(tmr, new EventHandler(DoTmrOnTick));
            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                ExceptionHandler.ReturnErrMsg(ex, out msg);
                ShowMsgBox(ex.Message);
                DialogResult = DialogResult.Cancel;
            }
        }
        /// <summary>
        /// Timer start to carry out function
        /// </summary>
        private void DoTmrOnTick(object sender, EventArgs e)
        {
            lblTimer.Text = DateTime.Compare(exam.EffectiveTime, DateTime.Now) > 0
                                        ? DateDiff(DateTime.Now, exam.EffectiveTime, true)
                                        : Constants.TIP_TIME_HASDAY;

            if (DateTime.Compare(exam.EffectiveTime, DateTime.Now) == 0)
            {
                tmr.Stop();
            }
        }
        #endregion
        /// <summary>
        /// Click to start exam and do some validation
        /// </summary>
        private void DoLblStartTestOnClick(object sender, EventArgs e)
        {
            string msg = string.Empty;
            if (DateTime.Compare(exam.EffectiveTime, DateTime.Now) > 0)
            {
                msg = "EXAM_NOT_START";
            }
            if (DateTime.Compare(exam.EffectiveTime.AddMinutes(exam.Duration), DateTime.Now) < 0)
            {
                msg = "EXAM_CLOSED";
            }
            if (!string.IsNullOrEmpty(msg))
            {
                ShowMsgBox(Res.ResourceManager.GetString(msg));
            }
            else
            {
                try
                {
                    tmr.Stop();

                    base.lblSystem.Text = exam.Name;
                    //Load data
                    questionList = examService.FindQuestionListByExamId(out answerStr, exam.Id, Program.user.Id);

                    lblTimingSpan.Text = DateTime.Compare(exam.EffectiveTime.AddMinutes(exam.Duration), DateTime.Now) > 0
                                            ? DateDiff(exam.EffectiveTime.AddMinutes(exam.Duration), DateTime.Now, false)
                                            : Constants.TIP_TIME_NODAY;

                    lblQuestionNo.Paint += new PaintEventHandler(ResetRoundRect);

                    TimerStart(tmr, new EventHandler(DoTmrOnTickAtTakingExam));

                    lblTotalNum.Text = "/" + questionList.Count;

                    // Continue exam or start exam
                    currentNum = string.IsNullOrEmpty(answerStr) ? 0
                                                                    : Convert.ToInt32(answerStr.Substring(answerStr.LastIndexOf("=") - 1, 1));

                    DoLoadQuestion();

                    pnlDescription.Visible = false;
                    pnlTakeExam.Visible = true;
                }
                catch (Exception ex)
                {
                    string message = string.Empty;
                    ExceptionHandler.ReturnErrMsg(ex, out message);
                    ShowMsgBox(ex.Message);
                    DialogResult = DialogResult.Cancel;
                }
            }
        }
        /// <summary>
        /// Auto Commit user answer string
        /// </summary>
        private void DoTmrOnTickAtTakingExam(object sender, EventArgs e)
        {
            lblTimingSpan.Text = DateTime.Compare(exam.EffectiveTime.AddMinutes(exam.Duration), DateTime.Now) > 0
                                        ? DateDiff(exam.EffectiveTime.AddMinutes(exam.Duration), DateTime.Now, false)
                                        : Constants.TIP_TIME_NODAY;
            
            if (DateTime.Compare(exam.EffectiveTime.AddMinutes(exam.Duration), DateTime.Now) < 0)
            {
                tmr.Stop();
                // Auto commit
                lblNext.Enabled = false;
                lblNext.BackColor = Constants.COLOR_GREY;

                CaculateResult();
            }
        }
        /// <summary>
        /// Click next question button & insert current answer string and load new question
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoLblNextOnClick(object sender, EventArgs e)
        {
            string tag = string.Empty;
            if (!IsPicBtnChecked(out tag))
            {
                ShowMsgBox(Res.NO_CHOOSE_ANSWER);
            }
            else
            {
                // Caculate current answerStr
                string currentAnswer = currentNum.ToString() + Constants.SIGN_EQUALS + tag;

                answerStr += string.IsNullOrEmpty(answerStr) ? currentAnswer : Constants.SIGN_AND + currentAnswer;

                try
                {
                    // Insert current answerStr into DB
                    examService.InsertCurrentAnswerStr(exam.Id, Program.user.Id, answerStr);
                    DoLoadQuestion();
                }
                catch (Exception ex)
                {
                    string msg = string.Empty;
                    ExceptionHandler.ReturnErrMsg(ex, out msg);
                    ShowMsgBox(ex.Message);
                }
            }
        }
        /// <summary>
        /// Load question list after do it or continue
        /// </summary>
        private void DoLoadQuestion()
        {
            if (currentNum == questionList.Count)
            {
                // Click to Commit
                CaculateResult();
            }
            else
            {
                Question question = questionList[currentNum];
                lblCurrentNum.Text = (++currentNum).ToString();
                LoadQuestionDetails(currentNum, question);
            }
        }
        /// <summary>
        /// Load new question
        /// </summary>
        private void LoadQuestionDetails(int questionNo, Question question)
        {
            // Reset item
            DoPicBtnReset();

            if (questionNo == questionList.Count)
            {
                lblNext.Text = Res.SUBMIT;
            }

            lblQuestionNo.Text = questionNo.ToString();
            lblItemA.Text = question.ItemA;
            lblItemB.Text = question.ItemB;
            lblItemC.Text = question.ItemC;
            lblItemD.Text = question.ItemD;

            lblQuestionTitle.Text = question.Title;
        }
        /// <summary>
        /// Caculate Result when auto commit or self commit
        /// </summary>
        private void CaculateResult()
        {
            // Caculate exam result
            string rightAnswer = exam.AnswerStr;
            string userAnswer = answerStr;

            int score = 0;
            int rightNum = 0;

            // Pass 1: all answer is right

            if (rightAnswer.Equals(userAnswer))
            {
                score = exam.TotalScore;
                rightNum = questionList.Count;
            }
            else
            {
                // Pass 2: resolve string and caculate score
                // 1=1&2=2&3=1
                // 1=2&2=3&3=1

                string[] userArr = userAnswer.Split(Constants.SIGN_AND);
                string[] rightArr = rightAnswer.Split(Constants.SIGN_AND);

                if (userAnswer.Length < rightAnswer.Length)
                {
                    int start = userAnswer.Length == 0 ? userArr.Length : userArr.Length + 1;
                    for (int i = start; i <= rightArr.Length; i++)
                    {
                        if (string.IsNullOrEmpty(userAnswer))
                        {
                            userAnswer += i + "=";
                        }
                        else
                        {
                            userAnswer += "&" + i + "=";
                        }
                    }
                }
                //1=&2=
                //1=1&2=1
                userArr = userAnswer.Split(Constants.SIGN_AND);

                for (int i = 0; i < userArr.Length; i++)
                {
                    if (userArr[i].Split(Constants.SIGN_EQUALS)[1].Equals(rightArr[i].Split(Constants.SIGN_EQUALS)[1]))
                    {
                        rightNum++;
                    }
                }
                score = rightNum * exam.SingleScore;

            }
            try
            {
                // Insert exam result into DB
                examService.InsertExamScore(exam.Id, Program.user.Id, userAnswer, score);
                
                // Page go to view result
                lblExamStrResult.Text = string.Format(Res.lblExamStrResult_Text, score.ToString(), rightNum.ToString());
                
                pnlTakeExam.Visible = false;
                pnlViewResult.Visible = true;
            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                ExceptionHandler.ReturnErrMsg(ex, out msg);
                ShowMsgBox(ex.Message);
            }
        }
        /// <summary>
        /// Close this window
        /// </summary>
        protected override void DoPicCloseOnClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// Load exam result
        /// </summary>
        private void DoLblBtnViewOnClick(object sender, EventArgs e)
        {
            LoadExamResult(exam.Id);
        }
        /// <summary>
        /// Load exam result
        /// </summary>
        public void LoadExamResult(int examId)
        {
            // hide all panel except pnlResult
            pnlDescription.Visible = false;
            pnlTakeExam.Visible = false;
            pnlViewResult.Visible = false;
            pnlResult.Visible = true;
            pnlResult.Focus();

            try
            {
                // Get Data needed
                //1.exam
                //2.questionList
                //3.result
                exam = examService.GetExamById(examId);
                questionList = examService.FindQuestionListByExamId(out answerStr, examId, Program.user.Id);
                Result result = examService.GetUserExamResult(examId, Program.user.Id);
                base.lblSystem.Text = exam.Name + Res.TIP_EXAM_RESULT;
                lblCurrentScore.Text = result.Score.ToString();
                lblTipMsg.Text = string.Format(Res.TIP_CURRECT_QUESTION, (result.Score / exam.SingleScore).ToString());

                // Set value to label
                lblExamName.Text += exam.Name;
                lblExamTime.Text += exam.EffectiveTime.ToString();
                lblExamDuration.Text += exam.Duration.ToString() + Res.MIN_UNIT;
                lblExamQuestion.Text += exam.FactQuantity.ToString();
                lblExamNum.Text += exam.Num;
                lblUserScore.Text += result.Score.ToString();
                lblExamTotalScore.Text += exam.TotalScore.ToString();

                string[] answerArr = exam.AnswerStr.Split(Constants.SIGN_AND);
                string[] userArr = result.AnswerStr.Split(Constants.SIGN_AND);

                for (int i = 0; i < questionList.Count; i++)
                {
                    // Loop control to load question list
                    Item item = new Item();
                    item.lblNum.Text = (i + 1).ToString();
                    item.lblTitle.Text = questionList[i].Title;
                    item.lblAnswerA.Text += questionList[i].ItemA;
                    item.lblAnswerB.Text += questionList[i].ItemB;
                    item.lblAnswerC.Text += questionList[i].ItemC;
                    item.lblAnswerD.Text += questionList[i].ItemD;
                    string rightAnswer = answerArr[i].Split(Constants.SIGN_EQUALS)[1];
                    string userAnswer = userArr[i].Split(Constants.SIGN_EQUALS)[1];
                    // Add right or wrong style
                    if (!rightAnswer.Equals(userAnswer))
                    {
                        item.picRight.Image = wrongImage;
                        item.lblNum.Tag = "RED";
                        item.lblNum.ForeColor = Constants.COLOR_RED;
                    }
                    else
                    {
                        item.lblNum.Tag = "ORANGE";
                    }
                    // Draw border radius
                    item.lblNum.Paint += new PaintEventHandler(ResetRoundRect);
                    // Loop to add question list to current panel
                    for (int j = 0; j < item.Controls.Count; j++)
                    {
                        if (item.Controls[j] is PictureBox && !"picRight".Equals(item.Controls[j].Name))
                        {
                            if (userAnswer.Equals(item.Controls[j].Tag.ToString()))
                            {
                                PictureBox picBox = item.Controls[j] as PictureBox;
                                picBox.Image = selectedImage;
                            }                      
                        }
                        if (item.Controls[j] is Label && item.Controls[j].Name.StartsWith("lblAnswer"))
                        {
                            if (rightAnswer.Equals(item.Controls[j].Tag.ToString()))
                            {
                                Label label = item.Controls[j] as Label;
                                label.BackColor = ColorTranslator.FromHtml("#D2DAE3");
                            }
                        }
                    }

                    item.Location = new Point(130, 250 + i * 250);

                    pnlResult.Controls.Add(item);
                }
            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                ExceptionHandler.ReturnErrMsg(ex, out msg);
                ShowMsgBox(ex.Message);
            }
        }

        #region PicBox Check
        /// <summary>
        /// User check answer radio
        /// </summary>
        private void DoPicBtnOnClick(object sender, EventArgs e)
        {
            for (int i = 0; i < pnlTakeExam.Controls.Count; i++)
            {
                if (pnlTakeExam.Controls[i] is PictureBox)
                {
                    PictureBox pic = pnlTakeExam.Controls[i] as PictureBox;
                    pic.Image = pic.Name != (sender as Control).Name ? defaultImage : selectedImage;
                }
            }
        }
        /// <summary>
        /// Reset radio checked style
        /// </summary>
        private void DoPicBtnReset()
        {
            for (int i = 0; i < pnlTakeExam.Controls.Count; i++)
            {
                if (pnlTakeExam.Controls[i] is PictureBox)
                {
                    PictureBox pic = pnlTakeExam.Controls[i] as PictureBox;
                    pic.Image = defaultImage;
                }
            }
        }
        /// <summary>
        /// Whether this pic is checked
        /// </summary>
        private bool IsPicBtnChecked(out string tag)
        {
            bool isChecked = false;
            tag = string.Empty;
            for (int i = 0; i < pnlTakeExam.Controls.Count; i++)
            {
                if (pnlTakeExam.Controls[i] is PictureBox)
                {
                    PictureBox pic = pnlTakeExam.Controls[i] as PictureBox;
                    if (ApplicationUtil.IsSameImage(pic.Image, selectedImage))
                    {
                        tag = pic.Tag.ToString();
                        isChecked = true;
                        break;
                    }
                }
            }
            return isChecked;
        }

        #endregion

        private void DoFormTakeExamOnSizeChanged(object sender, EventArgs e)
        {
            autoScale.ControlAutoSize(this);
        }

        /// <summary>
        /// Caculate time diffence between two times
        /// </summary>
        private string DateDiff(DateTime prevDateTime, DateTime nextDateTime, bool isHasDay)
        {
            string dateDiff = null;
            TimeSpan ts1 = new TimeSpan(prevDateTime.Ticks);
            TimeSpan ts2 = new TimeSpan(nextDateTime.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            dateDiff = isHasDay ? ts.Days.ToString().PadLeft(2, '0') + ":" + ts.Hours.ToString().PadLeft(2, '0') + ":" + ts.Minutes.ToString().PadLeft(2, '0') + ":" + ts.Seconds.ToString().PadLeft(2, '0')
                                : ts.Hours.ToString().PadLeft(2, '0') + ":" + ts.Minutes.ToString().PadLeft(2, '0') + ":" + ts.Seconds.ToString().PadLeft(2, '0');
            return dateDiff;
        }

        private void TimerStart(Timer timer, EventHandler handler)
        {
            timer.Interval = 1000;
            timer.Tick += handler;
            timer.Start();
        }
    }
}
