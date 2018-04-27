using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Common;

namespace UI
{
    public partial class PanelLoop : UserControl
    {

        delegate void DataTransportHandler(int id);

        public PanelLoop(int rownum, int id, string name, string num, string effectiveTime, int duration, int passCriteria, string score, string status)
        {
            InitializeComponent();

            lblRownum.Text = rownum.ToString();
            llblName.Text = name;
            llblName.Tag = id;

            llblName.Click += new EventHandler(DoNameOrStatusOnClick);

            lblNum.Text = num;
            lblEffectiveTime.Text = effectiveTime;
            lblDuration.Text = duration.ToString();
            lblPassCriteria.Text = passCriteria.ToString();
            lblScore.Text = score;
            llblStatus.Text = status;
            llblStatus.Tag = id;
            llblStatus.Click += new EventHandler(DoNameOrStatusOnClick);
        }

        private void DoNameOrStatusOnClick(object sender, EventArgs e)
        {
            LinkLabel status = sender as LinkLabel;
            int id = Convert.ToInt32(status.Tag);
            string cellVal = llblStatus.Text;

            FormTakeExam formTakeExam = new FormTakeExam();
            if (Status.Do_it.ToString().Replace("_", " ").Equals(cellVal) || Status.Continue.ToString().Equals(cellVal))
            {
                DataTransportHandler dtHandler = new DataTransportHandler(formTakeExam.ShowInfo);
                dtHandler(id);
            }
            else if (Status.Pass.ToString().Equals(cellVal) || Status.No_Pass.ToString().Replace("_", " ").Equals(cellVal))
            {
                formTakeExam.LoadExamResult(id);
            }
            if (!Status.Not_Attend.ToString().Replace("_", " ").Equals(cellVal))
            {
                Jump2WindowOnce(this.ParentForm, formTakeExam);
            }
        }

        private void Jump2WindowOnce(Form currentForm, Form targetForm)
        {
            currentForm.Visible = false;
            targetForm.WindowState = currentForm.WindowState;
            DialogResult result = targetForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                currentForm.Visible = true;
            }
        }
    }
}
