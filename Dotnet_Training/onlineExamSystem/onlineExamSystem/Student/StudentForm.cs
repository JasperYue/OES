using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using UI.Properties;
using Common;
using CustomException;
using log4net;
using UI.ExamService;
using System.ComponentModel;
using System.Threading;

namespace UI
{
    public partial class FormStudent : BaseForm
    {
        private ExamServiceClient examService = new ExamServiceClient();

        private ILog log = LogManager.GetLogger(Constants.LOGGER);

        private ReturnParamsOfExamListYgFqSxnr response;

        delegate void DataTransportHandler(int id);

        public FormStudent()
        {
            InitializeComponent();
            cboPageSize.SelectedIndex = 1;
            llblName.Text = Program.user.Name;
            LoadNotice();
        }

        #region Notice
        /// <summary>
        /// Load user Undo ExamList
        /// </summary>
        private void LoadNotice()
        {
            List<Exam> examList = examService.FindUndoExamList();
            pnlTip.Controls.Clear();

            for (int i = 0; i < examList.Count; i++)
            {
                Label prevLabel = GetNoticeLabel(i + 1 + Res.TIP_ATTEND, defaultFont, new Point(0, i * 30));
                pnlTip.Controls.Add(prevLabel);

                Label midLabel = GetNoticeLabel("\"" + examList[i].Name + "\"", defaultFont, new Point(prevLabel.Width, i * 30));
                midLabel.Tag = examList[i].Id;
                midLabel.ForeColor = Constants.COLOR_BLUE_BORDER;
                midLabel.Click += new EventHandler(DoJumpExamDescription);
                pnlTip.Controls.Add(midLabel);

                DateTime datetime = examList[i].EffectiveTime;
                Label nextLabel = GetNoticeLabel(Res.TIP_TIME + datetime.ToShortDateString().ToString() + Res.TIP_AT + datetime.ToShortTimeString().ToString(),
                                                defaultFont, new Point(midLabel.Location.X + midLabel.Width, i * 30));
                pnlTip.Controls.Add(nextLabel);
            }
        }
        /// <summary>
        /// Get notice label
        /// </summary>
        private Label GetNoticeLabel(string text, Font font, Point point)
        {
            Label label = new Label();
            label.AutoSize = true;
            label.Text = text;
            label.Font = font;
            label.Location = point;
            return label;
        }
        #endregion

        #region Reset DataGridView Style
        private void DoDgvExamListOnCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;

            if (e.Value.ToString().Equals(Res.ResourceManager.GetString(Status.Do_it.ToString().Replace("_", " ")), StringComparison.OrdinalIgnoreCase) ||
                e.Value.ToString().Equals(Res.ResourceManager.GetString(Status.Continue.ToString()), StringComparison.OrdinalIgnoreCase))
            {
                e.CellStyle.ForeColor = Color.FromArgb(41, 103, 147);
                e.CellStyle.Font = new Font("Arial", 12, FontStyle.Underline, GraphicsUnit.Pixel);
            }
        }

        private void DodgvExamListRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts = e.PaintParts ^ DataGridViewPaintParts.Focus;
        }
        #endregion
        /// <summary>
        /// Bind data to DataGridView
        /// </summary>
        protected override void ShowDgvList()
        {
            if (!bgwStudentList.IsBusy)
            {
                bgwStudentList.RunWorkerAsync();
            }
        }
        /// <summary>
        /// Find student List from DB by using BackgroundWorker
        /// </summary>
        private void DoBgwStudentListDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                GetStatus();
                response = examService.FindExamListByConditions(request);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }
        /// <summary>
        /// UI performance after finding student list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoBgwStudentListRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                List<ExamList> examList = response.Result;

                foreach(ExamList exam in examList)
                {
                    exam.Status = Res.ResourceManager.GetString(exam.Status);
                }

                dgvExamList.DataSource = response.Result;

                ShowPagination(pnlExam, response.TotalItem);

                dgvExamList.ClearSelection();
            }
            else
            {
                Exception ex = e.Result as Exception;

                string msg = string.Empty;
                ExceptionHandler.ReturnErrMsg(ex, out msg);
                ShowMsgBox(Res.ResourceManager.GetString(ex.Message));
            }
        }
        /// <summary>
        /// Click do it or continue
        /// </summary>
        private void DoDgvExamListOnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            if (columnIndex == 2 || columnIndex == 8)
            {
                int rowIndex = e.RowIndex;
                string cellVal = dgvExamList.Rows[rowIndex].Cells[8].Value.ToString();

                int id = (int)dgvExamList.Rows[rowIndex].Cells[1].Value;
                FormTakeExam formTakeExam = new FormTakeExam();
                if (Res.ResourceManager.GetString(Status.Do_it.ToString().Replace("_", " ")).Equals(cellVal) || Res.ResourceManager.GetString(Status.Continue.ToString()).Equals(cellVal))
                {
                    DataTransportHandler dtHandler = new DataTransportHandler(formTakeExam.ShowInfo);
                    dtHandler(id);
                }
                else if (Res.ResourceManager.GetString(Status.Pass.ToString()).Equals(cellVal) || Res.ResourceManager.GetString(Status.No_Pass.ToString().Replace("_", " ")).Equals(cellVal))
                {
                    formTakeExam.LoadExamResult(id);
                }
                if (!Res.ResourceManager.GetString(Status.Not_Attend.ToString().Replace("_", " ")).Equals(cellVal))
                {
                    Jump2WindowOnce(this, formTakeExam);
                }
            }
        }
        /// <summary>
        /// Jump exam description
        /// </summary>
        private void DoJumpExamDescription(object sender, EventArgs e)
        {
            Control control = sender as Control;
            FormTakeExam formTakeExam = new FormTakeExam();
            DataTransportHandler dtHandler = new DataTransportHandler(formTakeExam.ShowInfo);
            int id;
            if (int.TryParse(control.Tag.ToString(), out id))
            {
                dtHandler(id);
                Jump2WindowOnce(this, formTakeExam);
            }
        }

        #region Order
        /// <summary>
        /// Get list order by specific conditions
        /// </summary>
        private void DoPicOrderOnClick(object sender, EventArgs e)
        {
            GetPageWhenOrder(sender, pnlOrderTitle, request);
        }
        /// <summary>
        /// Click ALL, FINISH, UNFINISH to get conditions
        /// </summary>
        private string GetStatus()
        {
            string strWhere = " s.[user_id] = " + Program.user.Id + " or s.[user_id] is NULL";
            if (lblFinished.BackColor == Constants.COLOR_BLUE)
            {
                strWhere = " s.[user_id] = " + Program.user.Id;
            }
            else if (lblUnfinished.BackColor == Constants.COLOR_BLUE)
            {
                strWhere = " s.[user_id] is NULL";
            }
            request.UserId = Program.user.Id;
            return request.StrWhere = strWhere;
        }
        #endregion

        #region Toggle LeftTab
        private void DoLblHomeTabOnClick(object sender, EventArgs e)
        {
            LoadNotice();
            SetVisibility(pnlHome, pnlExam);
            SetBackColor(lblHomeTab, Constants.COLOR_HOME_GREY, Constants.COLOR_BLUE);
            SetBackColor(lblExamTab, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
        }

        private void DoLblExamTabOnClick(object sender, EventArgs e)
        {
            SetVisibility(pnlExam, pnlHome);
            SetBackColor(lblExamTab, Constants.COLOR_HOME_GREY, Constants.COLOR_BLUE);
            SetBackColor(lblHomeTab, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
        }

        private void DoLblTabNoticeOnClick(object sender, EventArgs e)
        {
            LoadNotice();
            SetVisibility(pnlNotice, pnlAbout);
            SetBackColor(lblTabAbout, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
            SetBackColor(lblTabNotice, Constants.COLOR_BLUE, Constants.COLOR_WHITE);
        }

        private void DoLblTabAboutOnClick(object sender, EventArgs e)
        {
            SetVisibility(pnlAbout, pnlNotice);
            SetBackColor(lblTabNotice, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
            SetBackColor(lblTabAbout, Constants.COLOR_BLUE, Constants.COLOR_WHITE);
        }
        #endregion

        #region Toggle Label
        private void DoLblAllOnClick(object sender, EventArgs e)
        {
            SetBackColor(lblFinished, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
            SetBackColor(lblUnfinished, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
            SetBackColor(lblAll, Constants.COLOR_BLUE, Constants.COLOR_WHITE);
            request.PageNo = 1;
            ShowDgvList();
        }

        private void DoLblFinishedOnClick(object sender, EventArgs e)
        {
            SetBackColor(lblAll, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
            SetBackColor(lblUnfinished, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
            SetBackColor(lblFinished, Constants.COLOR_BLUE, Constants.COLOR_WHITE);
            request.PageNo = 1;
            ShowDgvList();
        }

        private void DoLblUnfinishedOnClick(object sender, EventArgs e)
        {
            SetBackColor(lblAll, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
            SetBackColor(lblFinished, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
            SetBackColor(lblUnfinished, Constants.COLOR_BLUE, Constants.COLOR_WHITE);
            request.PageNo = 1;
            ShowDgvList();
        }
        #endregion
        /// <summary>
        /// Maximize or normal window
        /// </summary>
        protected override void DopicMaxOnClick(object sender, EventArgs e)
        {
            autoScale.ControlAutoSize(this);
            base.DopicMaxOnClick(sender, e);
            autoScale.ControlAutoSize(this);
        }
        /// <summary>
        /// Close application
        /// </summary>
        protected override void DoPicCloseOnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Click to log out system
        /// </summary>
        private void DoLogoutOnClick(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Close();
            log.Info(Program.user.Name + "[" + Program.user.Id + "] Logout system at " + DateTime.Now);
        }
        /// <summary>
        /// Change language to support i18n
        /// </summary>
        private void DoLlblChineseOnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((sender as Control).Text.Equals("English"))
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-cn");
            }
            FormStudent t = new FormStudent();
            t.Show();
            this.Close();
        }
    }
}
