using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;
using UI.Properties;
using CustomException;
using UI.ExamService;

namespace UI
{
    public partial class FormDetail : BaseForm
    {
        private ExamServiceClient examService = new ExamServiceClient();

        private ReturnParamsOfAttendanceYgFqSxnr response;
        private int examId;

        public FormDetail()
        {
            InitializeComponent();

            txtName.Enter += new EventHandler(DoTxTNameEnter);
            txtName.Leave += new EventHandler(DoTxTNameLeave);
        }
        /// <summary>
        /// Load information of exam details
        /// </summary>
        public void ShowInfo(int id)
        {
            examId = id;
            request.StrWhere = "e.[id] = " + examId;
            cboPageSize.SelectedIndex = 1;
        }
        /// <summary>
        /// Click Search button and reload list
        /// </summary>
        private void DoSearchOnClick(object sender, EventArgs e)
        {
            request.StrWhere = "u." + GetSearchCondition(txtName) + " AND e.[id] = " + examId;
            ShowDgvList();
        }
        /// <summary>
        /// Load attendance list
        /// </summary>
        protected override void ShowDgvList()
        {
            if (!bgwAttendanceList.IsBusy)
            {
                bgwAttendanceList.RunWorkerAsync();
            }
            
        }
        /// <summary>
        /// Find attendanceList by BackgroundWorker
        /// </summary>
        private void DoBgwAttendanceListDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                response = examService.FindAttendenceByExamId(request);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }
        /// <summary>
        /// UI performance after finding attendanceList
        /// </summary>
        private void DoBgwAttendanceListRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                dgvAttendanceList.DataSource = response.Result;
                ShowPagination(pnlAttendance, response.TotalItem);

                dgvAttendanceList.ClearSelection();
            }
            else
            {
                Exception ex = e.Result as Exception;

                string msg = string.Empty;
                ExceptionHandler.ReturnErrMsg(ex, out msg);
                ShowMsgBox(Res.ResourceManager.GetString(ex.Message));
                txtName.ForeColor = Color.FromArgb(94, 94, 94);
                txtName.Text = txtName.Focused ? string.Empty : Res.txtName_Text;
                // Clear search conditions
                string conditions = request.StrWhere;
                request.StrWhere = conditions.Substring(0, conditions.IndexOf('%') + 1) + conditions.Substring(conditions.LastIndexOf('%'));
            }
        }

        /// <summary>
        /// Get list order by specific conditions
        /// </summary>
        private void DoPicOrderOnClick(object sender, EventArgs e)
        {
            GetPageWhenOrder(sender, pnlOrderTitle, request);
        }
        /// <summary>
        /// Click to close this window
        /// </summary>
        protected override void DoPicCloseOnClick(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        /// <summary>
        /// Enter to search attendance list
        /// </summary>
        private void DoTxtBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoSearchOnClick(sender, e);
            }
        }
        /// <summary>
        /// Auto scale window
        /// </summary>
        private void FormDetailOnSizeChanged(object sender, EventArgs e)
        {
            autoScale.ControlAutoSize(this);
        }

        protected override void DopicMaxOnClick(object sender, EventArgs e)
        {

        }

        #region Reset datagridview style
        private void DoDgvPaperListOnCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
        }

        private void DodgvPaperListRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts = e.PaintParts ^ DataGridViewPaintParts.Focus;
        }
        #endregion

    }
}