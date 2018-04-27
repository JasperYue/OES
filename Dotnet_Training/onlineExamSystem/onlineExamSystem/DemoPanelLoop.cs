using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using UI.ExamService;
using CustomException;

namespace UI
{
    public partial class DemoPanelLoop : BaseForm
    {

        private ExamServiceClient examService = new ExamServiceClient();

        private ReturnParamsOfExamListYgFqSxnr response;


        public DemoPanelLoop()
        {
            InitializeComponent();
            cboPageSize.SelectedIndex = 1;
            llblName.Text = Program.user.Name;
        }

        protected override void ShowDgvList()
        {
            if (!bgwExamList.IsBusy)
            {
                bgwExamList.RunWorkerAsync();
            }
        }

        private void DoBgwExamListDoWork(object sender, DoWorkEventArgs e)
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

        private void DoBgwExamListRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                LoadPanelList();
                ShowPagination(pnlExam, response.TotalItem);
            }
            else
            {
                Exception ex = e.Result as Exception;
                string msg = string.Empty;
                ExceptionHandler.ReturnErrMsg(ex, out msg);
                ShowMsgBox(ex.Message);
            }
        }

        private void LoadPanelList()
        {
            List<ExamList> examList = response.Result;
            pnlExamList.Controls.Clear();
            for (int i = 0; i < examList.Count; i++)
            {
                ExamList exam = examList[i];
                PanelLoop panel = new PanelLoop(exam.Rownum, exam.Id, exam.Name, exam.Num, exam.EffectiveTime.ToString(), exam.Duration, exam.PassCriteria, exam.Score, exam.Status);
                panel.Location = new Point(0, 0 + i * 40);
                pnlExamList.Controls.Add(panel);
            }
        }

        #region order
        private void DoPicOrderOnClick(object sender, EventArgs e)
        {
            GetPageWhenOrder(sender, pnlOrderTitle, request);
        }

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
            return request.StrWhere = strWhere;
        }
        #endregion

        #region Toggle top label
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

        protected override void DoPicCloseOnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DoLogoutOnClick(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Close();
        }

    }
}
