using System;
namespace UI
{
    partial class FormTeacher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnActivated(System.EventArgs e)
        {
            base.OnActivated(e);
            picSearch.Focus();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTeacher));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.lblTabUser = new System.Windows.Forms.Label();
            this.lblLogout = new System.Windows.Forms.Label();
            this.llblChinese = new System.Windows.Forms.LinkLabel();
            this.lblTabExamList = new System.Windows.Forms.Label();
            this.pnlPaper = new System.Windows.Forms.Panel();
            this.lblLine = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.timerStart = new System.Windows.Forms.DateTimePicker();
            this.timerEnd = new System.Windows.Forms.DateTimePicker();
            this.picSearch = new System.Windows.Forms.PictureBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.pnlOrderTitle = new System.Windows.Forms.Panel();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblQualifiedNum = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblAverageScore = new System.Windows.Forms.Label();
            this.lblExaminee = new System.Windows.Forms.Label();
            this.picPassRate = new System.Windows.Forms.PictureBox();
            this.lblPassRate = new System.Windows.Forms.Label();
            this.picName = new System.Windows.Forms.PictureBox();
            this.picAverage = new System.Windows.Forms.PictureBox();
            this.picNum = new System.Windows.Forms.PictureBox();
            this.picTime = new System.Windows.Forms.PictureBox();
            this.dgvPaperList = new System.Windows.Forms.DataGridView();
            this.rownum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EffectiveTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Average = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExamineeCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QualifiedNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PassRate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lineContainer = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineOrderBottom = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineOrderTop = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.pnlSearch = new UI.AdvancedLabel();
            this.pnlTime = new UI.AdvancedLabel();
            this.bgwExamList = new System.ComponentModel.BackgroundWorker();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.pnlUpload = new System.Windows.Forms.Panel();
            this.lblTipMsg = new System.Windows.Forms.Label();
            this.lblUploadPic = new UI.AdvancedLabel();
            this.lblAddPhoto = new UI.AdvancedLabel();
            this.lblTipUpload = new System.Windows.Forms.Label();
            this.picUpload = new System.Windows.Forms.PictureBox();
            this.lblBack = new System.Windows.Forms.Label();
            this.lblWorkNum = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.picUserIcon = new System.Windows.Forms.PictureBox();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineUser = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.ofdPic = new System.Windows.Forms.OpenFileDialog();
            this.bgwPicUpload = new System.ComponentModel.BackgroundWorker();
            this.pnlNav.SuspendLayout();
            this.pnlPaper.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).BeginInit();
            this.pnlOrderTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaperList)).BeginInit();
            this.pnlUser.SuspendLayout();
            this.pnlUpload.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSystem
            // 
            resources.ApplyResources(this.lblSystem, "lblSystem");
            // 
            // txtPageNo
            // 
            resources.ApplyResources(this.txtPageNo, "txtPageNo");
            // 
            // cboPageSize
            // 
            resources.ApplyResources(this.cboPageSize, "cboPageSize");
            // 
            // pnlNav
            // 
            resources.ApplyResources(this.pnlNav, "pnlNav");
            this.pnlNav.BackColor = System.Drawing.Color.White;
            this.pnlNav.Controls.Add(this.lblTabUser);
            this.pnlNav.Controls.Add(this.lblLogout);
            this.pnlNav.Controls.Add(this.llblChinese);
            this.pnlNav.Controls.Add(this.lblTabExamList);
            this.pnlNav.Name = "pnlNav";
            // 
            // lblTabUser
            // 
            resources.ApplyResources(this.lblTabUser, "lblTabUser");
            this.lblTabUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblTabUser.Image = global::UI.Properties.Resources.ICN_Client_PersonalInformation_20x20;
            this.lblTabUser.Name = "lblTabUser";
            this.lblTabUser.Click += new System.EventHandler(this.DoToggleTabOnClick);
            // 
            // lblLogout
            // 
            resources.ApplyResources(this.lblLogout, "lblLogout");
            this.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Click += new System.EventHandler(this.DoLogoutOnClick);
            // 
            // llblChinese
            // 
            resources.ApplyResources(this.llblChinese, "llblChinese");
            this.llblChinese.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.llblChinese.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblChinese.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.llblChinese.Name = "llblChinese";
            this.llblChinese.TabStop = true;
            this.llblChinese.Tag = "";
            this.llblChinese.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DoLlblChineseOnLinkClicked);
            // 
            // lblTabExamList
            // 
            resources.ApplyResources(this.lblTabExamList, "lblTabExamList");
            this.lblTabExamList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.lblTabExamList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblTabExamList.Name = "lblTabExamList";
            this.lblTabExamList.Click += new System.EventHandler(this.DoToggleTabOnClick);
            // 
            // pnlPaper
            // 
            resources.ApplyResources(this.pnlPaper, "pnlPaper");
            this.pnlPaper.BackColor = System.Drawing.Color.White;
            this.pnlPaper.Controls.Add(this.lblLine);
            this.pnlPaper.Controls.Add(this.lblDate);
            this.pnlPaper.Controls.Add(this.timerStart);
            this.pnlPaper.Controls.Add(this.timerEnd);
            this.pnlPaper.Controls.Add(this.picSearch);
            this.pnlPaper.Controls.Add(this.txtName);
            this.pnlPaper.Controls.Add(this.pnlOrderTitle);
            this.pnlPaper.Controls.Add(this.dgvPaperList);
            this.pnlPaper.Controls.Add(this.lineContainer);
            this.pnlPaper.Controls.Add(this.pnlSearch);
            this.pnlPaper.Controls.Add(this.pnlTime);
            this.pnlPaper.Name = "pnlPaper";
            // 
            // lblLine
            // 
            resources.ApplyResources(this.lblLine, "lblLine");
            this.lblLine.Name = "lblLine";
            // 
            // lblDate
            // 
            resources.ApplyResources(this.lblDate, "lblDate");
            this.lblDate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.lblDate.Name = "lblDate";
            this.lblDate.Click += new System.EventHandler(this.DoSearchOnClick);
            // 
            // timerStart
            // 
            resources.ApplyResources(this.timerStart, "timerStart");
            this.timerStart.CalendarForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.timerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timerStart.Name = "timerStart";
            this.timerStart.Value = new System.DateTime(2016, 1, 1, 0, 0, 0, 0);
            this.timerStart.Leave += new System.EventHandler(this.DoTimerCheckOnLeave);
            // 
            // timerEnd
            // 
            resources.ApplyResources(this.timerEnd, "timerEnd");
            this.timerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.timerEnd.Name = "timerEnd";
            this.timerEnd.Value = new System.DateTime(2017, 1, 1, 0, 0, 0, 0);
            this.timerEnd.Leave += new System.EventHandler(this.DoTimerCheckOnLeave);
            // 
            // picSearch
            // 
            resources.ApplyResources(this.picSearch, "picSearch");
            this.picSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSearch.Image = global::UI.Properties.Resources.ICN_Search_15x20_png;
            this.picSearch.Name = "picSearch";
            this.picSearch.TabStop = false;
            this.picSearch.Click += new System.EventHandler(this.DoSearchOnClick);
            // 
            // txtName
            // 
            resources.ApplyResources(this.txtName, "txtName");
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.txtName.Name = "txtName";
            this.txtName.Tag = "";
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoTxtBoxOnKeyDown);
            // 
            // pnlOrderTitle
            // 
            resources.ApplyResources(this.pnlOrderTitle, "pnlOrderTitle");
            this.pnlOrderTitle.Controls.Add(this.lblQuantity);
            this.pnlOrderTitle.Controls.Add(this.lblQualifiedNum);
            this.pnlOrderTitle.Controls.Add(this.lblName);
            this.pnlOrderTitle.Controls.Add(this.lblNum);
            this.pnlOrderTitle.Controls.Add(this.lblTime);
            this.pnlOrderTitle.Controls.Add(this.lblAverageScore);
            this.pnlOrderTitle.Controls.Add(this.lblExaminee);
            this.pnlOrderTitle.Controls.Add(this.picPassRate);
            this.pnlOrderTitle.Controls.Add(this.lblPassRate);
            this.pnlOrderTitle.Controls.Add(this.picName);
            this.pnlOrderTitle.Controls.Add(this.picAverage);
            this.pnlOrderTitle.Controls.Add(this.picNum);
            this.pnlOrderTitle.Controls.Add(this.picTime);
            this.pnlOrderTitle.Name = "pnlOrderTitle";
            // 
            // lblQuantity
            // 
            resources.ApplyResources(this.lblQuantity, "lblQuantity");
            this.lblQuantity.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblQuantity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblQuantity.Name = "lblQuantity";
            // 
            // lblQualifiedNum
            // 
            resources.ApplyResources(this.lblQualifiedNum, "lblQualifiedNum");
            this.lblQualifiedNum.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblQualifiedNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblQualifiedNum.Name = "lblQualifiedNum";
            this.lblQualifiedNum.Tag = "";
            // 
            // lblName
            // 
            resources.ApplyResources(this.lblName, "lblName");
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblName.Name = "lblName";
            this.lblName.Tag = "picName";
            this.lblName.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblNum
            // 
            resources.ApplyResources(this.lblNum, "lblNum");
            this.lblNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblNum.Name = "lblNum";
            this.lblNum.Tag = "picNum";
            this.lblNum.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblTime
            // 
            resources.ApplyResources(this.lblTime, "lblTime");
            this.lblTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblTime.Name = "lblTime";
            this.lblTime.Tag = "picTime";
            this.lblTime.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblAverageScore
            // 
            resources.ApplyResources(this.lblAverageScore, "lblAverageScore");
            this.lblAverageScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAverageScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblAverageScore.Name = "lblAverageScore";
            this.lblAverageScore.Tag = "picAverage";
            this.lblAverageScore.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblExaminee
            // 
            resources.ApplyResources(this.lblExaminee, "lblExaminee");
            this.lblExaminee.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lblExaminee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblExaminee.Name = "lblExaminee";
            this.lblExaminee.Tag = "";
            // 
            // picPassRate
            // 
            resources.ApplyResources(this.picPassRate, "picPassRate");
            this.picPassRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPassRate.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picPassRate.Name = "picPassRate";
            this.picPassRate.TabStop = false;
            this.picPassRate.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblPassRate
            // 
            resources.ApplyResources(this.lblPassRate, "lblPassRate");
            this.lblPassRate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPassRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblPassRate.Name = "lblPassRate";
            this.lblPassRate.Tag = "picPassRate";
            this.lblPassRate.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picName
            // 
            resources.ApplyResources(this.picName, "picName");
            this.picName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picName.Image = global::UI.Properties.Resources.ICN_Increase_10x15_png;
            this.picName.Name = "picName";
            this.picName.TabStop = false;
            this.picName.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picAverage
            // 
            resources.ApplyResources(this.picAverage, "picAverage");
            this.picAverage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAverage.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picAverage.Name = "picAverage";
            this.picAverage.TabStop = false;
            this.picAverage.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picNum
            // 
            resources.ApplyResources(this.picNum, "picNum");
            this.picNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNum.Image = global::UI.Properties.Resources.ICN_Increase_10x15_png;
            this.picNum.Name = "picNum";
            this.picNum.TabStop = false;
            this.picNum.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picTime
            // 
            resources.ApplyResources(this.picTime, "picTime");
            this.picTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTime.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picTime.Name = "picTime";
            this.picTime.TabStop = false;
            this.picTime.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // dgvPaperList
            // 
            resources.ApplyResources(this.dgvPaperList, "dgvPaperList");
            this.dgvPaperList.AllowUserToAddRows = false;
            this.dgvPaperList.AllowUserToDeleteRows = false;
            this.dgvPaperList.AllowUserToResizeColumns = false;
            this.dgvPaperList.AllowUserToResizeRows = false;
            this.dgvPaperList.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaperList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPaperList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvPaperList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPaperList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaperList.ColumnHeadersVisible = false;
            this.dgvPaperList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rownum,
            this.ExamId,
            this.ExamName,
            this.num,
            this.EffectiveTime,
            this.FactQuantity,
            this.Average,
            this.ExamineeCount,
            this.QualifiedNum,
            this.PassRate});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPaperList.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPaperList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.dgvPaperList.MultiSelect = false;
            this.dgvPaperList.Name = "dgvPaperList";
            this.dgvPaperList.ReadOnly = true;
            this.dgvPaperList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvPaperList.RowHeadersVisible = false;
            this.dgvPaperList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dgvPaperList.RowTemplate.DividerHeight = 1;
            this.dgvPaperList.RowTemplate.Height = 40;
            this.dgvPaperList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvPaperList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoDgvPaperListOnCellContentClick);
            this.dgvPaperList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DoDgvPaperListOnCellPainting);
            this.dgvPaperList.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DodgvPaperListRowPrePaint);
            // 
            // rownum
            // 
            this.rownum.DataPropertyName = "Rownum";
            resources.ApplyResources(this.rownum, "rownum");
            this.rownum.Name = "rownum";
            this.rownum.ReadOnly = true;
            this.rownum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.rownum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExamId
            // 
            this.ExamId.DataPropertyName = "ExamId";
            resources.ApplyResources(this.ExamId, "ExamId");
            this.ExamId.Name = "ExamId";
            this.ExamId.ReadOnly = true;
            this.ExamId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExamName
            // 
            this.ExamName.DataPropertyName = "ExamName";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.ExamName.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.ExamName, "ExamName");
            this.ExamName.Name = "ExamName";
            this.ExamName.ReadOnly = true;
            this.ExamName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // num
            // 
            this.num.DataPropertyName = "Num";
            resources.ApplyResources(this.num, "num");
            this.num.Name = "num";
            this.num.ReadOnly = true;
            this.num.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.num.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EffectiveTime
            // 
            this.EffectiveTime.DataPropertyName = "EffectiveTime";
            resources.ApplyResources(this.EffectiveTime, "EffectiveTime");
            this.EffectiveTime.Name = "EffectiveTime";
            this.EffectiveTime.ReadOnly = true;
            this.EffectiveTime.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.EffectiveTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FactQuantity
            // 
            this.FactQuantity.DataPropertyName = "FactQuantity";
            resources.ApplyResources(this.FactQuantity, "FactQuantity");
            this.FactQuantity.Name = "FactQuantity";
            this.FactQuantity.ReadOnly = true;
            this.FactQuantity.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FactQuantity.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Average
            // 
            this.Average.DataPropertyName = "AverageScore";
            resources.ApplyResources(this.Average, "Average");
            this.Average.Name = "Average";
            this.Average.ReadOnly = true;
            this.Average.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Average.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExamineeCount
            // 
            this.ExamineeCount.DataPropertyName = "ExamineeCount";
            resources.ApplyResources(this.ExamineeCount, "ExamineeCount");
            this.ExamineeCount.Name = "ExamineeCount";
            this.ExamineeCount.ReadOnly = true;
            this.ExamineeCount.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ExamineeCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // QualifiedNum
            // 
            this.QualifiedNum.DataPropertyName = "QualifiedNum";
            dataGridViewCellStyle2.NullValue = "0";
            this.QualifiedNum.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.QualifiedNum, "QualifiedNum");
            this.QualifiedNum.Name = "QualifiedNum";
            this.QualifiedNum.ReadOnly = true;
            this.QualifiedNum.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.QualifiedNum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PassRate
            // 
            this.PassRate.DataPropertyName = "PassRate";
            dataGridViewCellStyle3.NullValue = "0%";
            this.PassRate.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.PassRate, "PassRate");
            this.PassRate.Name = "PassRate";
            this.PassRate.ReadOnly = true;
            this.PassRate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PassRate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lineContainer
            // 
            resources.ApplyResources(this.lineContainer, "lineContainer");
            this.lineContainer.Name = "lineContainer";
            this.lineContainer.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineOrderBottom,
            this.lineOrderTop});
            this.lineContainer.TabStop = false;
            // 
            // lineOrderBottom
            // 
            resources.ApplyResources(this.lineOrderBottom, "lineOrderBottom");
            this.lineOrderBottom.Name = "lineOrderBottom";
            // 
            // lineOrderTop
            // 
            resources.ApplyResources(this.lineOrderTop, "lineOrderTop");
            this.lineOrderTop.Name = "lineOrderTop";
            // 
            // pnlSearch
            // 
            resources.ApplyResources(this.pnlSearch, "pnlSearch");
            this.pnlSearch.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.pnlSearch.BorderSize = 1F;
            this.pnlSearch.DefaultBackColor = System.Drawing.Color.Empty;
            this.pnlSearch.DefaultFont = null;
            this.pnlSearch.DefaultFontColor = System.Drawing.Color.Empty;
            this.pnlSearch.MouseDownBackColor = System.Drawing.Color.Empty;
            this.pnlSearch.MouseDownFont = null;
            this.pnlSearch.MouseDownFontColor = System.Drawing.Color.Empty;
            this.pnlSearch.Name = "pnlSearch";
            this.pnlSearch.Radius = 5F;
            // 
            // pnlTime
            // 
            resources.ApplyResources(this.pnlTime, "pnlTime");
            this.pnlTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.pnlTime.BorderSize = 1F;
            this.pnlTime.DefaultBackColor = System.Drawing.Color.Empty;
            this.pnlTime.DefaultFont = null;
            this.pnlTime.DefaultFontColor = System.Drawing.Color.Empty;
            this.pnlTime.MouseDownBackColor = System.Drawing.Color.Empty;
            this.pnlTime.MouseDownFont = null;
            this.pnlTime.MouseDownFontColor = System.Drawing.Color.Empty;
            this.pnlTime.Name = "pnlTime";
            this.pnlTime.Radius = 5F;
            // 
            // bgwExamList
            // 
            this.bgwExamList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoDgwExamListRunWorkerDoWork);
            this.bgwExamList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoDgwExamListRunWorkerCompleted);
            // 
            // pnlUser
            // 
            resources.ApplyResources(this.pnlUser, "pnlUser");
            this.pnlUser.BackColor = System.Drawing.Color.White;
            this.pnlUser.Controls.Add(this.pnlUpload);
            this.pnlUser.Controls.Add(this.lblWorkNum);
            this.pnlUser.Controls.Add(this.lblUserName);
            this.pnlUser.Controls.Add(this.picUserIcon);
            this.pnlUser.Controls.Add(this.shapeContainer1);
            this.pnlUser.Name = "pnlUser";
            // 
            // pnlUpload
            // 
            resources.ApplyResources(this.pnlUpload, "pnlUpload");
            this.pnlUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.pnlUpload.Controls.Add(this.lblTipMsg);
            this.pnlUpload.Controls.Add(this.lblUploadPic);
            this.pnlUpload.Controls.Add(this.lblAddPhoto);
            this.pnlUpload.Controls.Add(this.lblTipUpload);
            this.pnlUpload.Controls.Add(this.picUpload);
            this.pnlUpload.Controls.Add(this.lblBack);
            this.pnlUpload.Name = "pnlUpload";
            // 
            // lblTipMsg
            // 
            resources.ApplyResources(this.lblTipMsg, "lblTipMsg");
            this.lblTipMsg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblTipMsg.Name = "lblTipMsg";
            // 
            // lblUploadPic
            // 
            resources.ApplyResources(this.lblUploadPic, "lblUploadPic");
            this.lblUploadPic.BorderColor = System.Drawing.Color.Empty;
            this.lblUploadPic.BorderSize = 0F;
            this.lblUploadPic.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.lblUploadPic.DefaultFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUploadPic.DefaultFontColor = System.Drawing.Color.White;
            this.lblUploadPic.ForeColor = System.Drawing.Color.White;
            this.lblUploadPic.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.lblUploadPic.MouseDownFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUploadPic.MouseDownFontColor = System.Drawing.Color.White;
            this.lblUploadPic.Name = "lblUploadPic";
            this.lblUploadPic.Radius = 5F;
            this.lblUploadPic.Click += new System.EventHandler(this.DoLblUploadPicOnClick);
            // 
            // lblAddPhoto
            // 
            resources.ApplyResources(this.lblAddPhoto, "lblAddPhoto");
            this.lblAddPhoto.BackColor = System.Drawing.Color.White;
            this.lblAddPhoto.BorderColor = System.Drawing.Color.Black;
            this.lblAddPhoto.BorderSize = 1F;
            this.lblAddPhoto.DefaultBackColor = System.Drawing.Color.White;
            this.lblAddPhoto.DefaultFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAddPhoto.DefaultFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblAddPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblAddPhoto.MouseDownBackColor = System.Drawing.Color.White;
            this.lblAddPhoto.MouseDownFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAddPhoto.MouseDownFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblAddPhoto.Name = "lblAddPhoto";
            this.lblAddPhoto.Radius = 5F;
            this.lblAddPhoto.Click += new System.EventHandler(this.DoLOblAddPhotoOnClick);
            // 
            // lblTipUpload
            // 
            resources.ApplyResources(this.lblTipUpload, "lblTipUpload");
            this.lblTipUpload.BackColor = System.Drawing.Color.White;
            this.lblTipUpload.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.lblTipUpload.Name = "lblTipUpload";
            // 
            // picUpload
            // 
            resources.ApplyResources(this.picUpload, "picUpload");
            this.picUpload.BackColor = System.Drawing.Color.White;
            this.picUpload.Name = "picUpload";
            this.picUpload.TabStop = false;
            // 
            // lblBack
            // 
            resources.ApplyResources(this.lblBack, "lblBack");
            this.lblBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblBack.ForeColor = System.Drawing.Color.White;
            this.lblBack.Name = "lblBack";
            // 
            // lblWorkNum
            // 
            resources.ApplyResources(this.lblWorkNum, "lblWorkNum");
            this.lblWorkNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblWorkNum.Name = "lblWorkNum";
            // 
            // lblUserName
            // 
            resources.ApplyResources(this.lblUserName, "lblUserName");
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblUserName.Name = "lblUserName";
            // 
            // picUserIcon
            // 
            resources.ApplyResources(this.picUserIcon, "picUserIcon");
            this.picUserIcon.BackColor = System.Drawing.Color.White;
            this.picUserIcon.Image = global::UI.Properties.Resources.ICN_Avatar_130x110_png;
            this.picUserIcon.Name = "picUserIcon";
            this.picUserIcon.TabStop = false;
            // 
            // shapeContainer1
            // 
            resources.ApplyResources(this.shapeContainer1, "shapeContainer1");
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineUser});
            this.shapeContainer1.TabStop = false;
            // 
            // lineUser
            // 
            resources.ApplyResources(this.lineUser, "lineUser");
            this.lineUser.Name = "lineUser";
            // 
            // ofdPic
            // 
            this.ofdPic.FileName = "openFileDialog1";
            resources.ApplyResources(this.ofdPic, "ofdPic");
            // 
            // bgwPicUpload
            // 
            this.bgwPicUpload.WorkerReportsProgress = true;
            this.bgwPicUpload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoBgwPicUploadDoWork);
            this.bgwPicUpload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.DoBgwPicUploadOnProgressChanged);
            this.bgwPicUpload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoBgwPicUploadRunWorkerCompleted);
            // 
            // FormTeacher
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.pnlPaper);
            this.Controls.Add(this.pnlUser);
            this.Controls.Add(this.pnlNav);
            this.Name = "FormTeacher";
            this.Controls.SetChildIndex(this.pnlNav, 0);
            this.Controls.SetChildIndex(this.pnlUser, 0);
            this.Controls.SetChildIndex(this.pnlPaper, 0);
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            this.pnlPaper.ResumeLayout(false);
            this.pnlPaper.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSearch)).EndInit();
            this.pnlOrderTitle.ResumeLayout(false);
            this.pnlOrderTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPassRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaperList)).EndInit();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.pnlUpload.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUserIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Label lblTabExamList;
        private System.Windows.Forms.Panel pnlPaper;
        private System.Windows.Forms.Panel pnlOrderTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblAverageScore;
        private System.Windows.Forms.Label lblExaminee;
        private System.Windows.Forms.PictureBox picPassRate;
        private System.Windows.Forms.Label lblPassRate;
        private System.Windows.Forms.PictureBox picName;
        private System.Windows.Forms.PictureBox picAverage;
        private System.Windows.Forms.PictureBox picNum;
        private System.Windows.Forms.PictureBox picTime;
        private System.Windows.Forms.DataGridView dgvPaperList;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer lineContainer;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineOrderBottom;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineOrderTop;
        private System.Windows.Forms.Label lblQualifiedNum;
        private System.Windows.Forms.PictureBox picSearch;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.DateTimePicker timerStart;
        private System.Windows.Forms.DateTimePicker timerEnd;
        private AdvancedLabel pnlSearch;
        private AdvancedLabel pnlTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn rownum;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn EffectiveTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Average;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExamineeCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn QualifiedNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn PassRate;
        private System.ComponentModel.BackgroundWorker bgwExamList;
        private System.Windows.Forms.Panel pnlUser;
        private System.Windows.Forms.Label lblWorkNum;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.PictureBox picUserIcon;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineUser;
        private System.Windows.Forms.Panel pnlUpload;
        private System.Windows.Forms.Label lblBack;
        private System.Windows.Forms.PictureBox picUpload;
        private System.Windows.Forms.Label lblTipUpload;
        private AdvancedLabel lblAddPhoto;
        private AdvancedLabel lblUploadPic;
        private System.Windows.Forms.OpenFileDialog ofdPic;
        private System.ComponentModel.BackgroundWorker bgwPicUpload;
        private System.Windows.Forms.Label lblTipMsg;
        public System.Windows.Forms.Label lblTabUser;
        public System.Windows.Forms.LinkLabel llblChinese;

    }
}