namespace UI
{
    partial class FormStudent
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
            picUser.Focus();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStudent));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMax = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlNav = new System.Windows.Forms.Panel();
            this.lblLogout = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.llblName = new System.Windows.Forms.LinkLabel();
            this.llblChinese = new System.Windows.Forms.LinkLabel();
            this.lblExamTab = new System.Windows.Forms.Label();
            this.lblHomeTab = new System.Windows.Forms.Label();
            this.pnlExam = new System.Windows.Forms.Panel();
            this.pnlOrderTitle = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.lblNum = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblPassCriteria = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.picOperation = new System.Windows.Forms.PictureBox();
            this.lblOperation = new System.Windows.Forms.Label();
            this.picScore = new System.Windows.Forms.PictureBox();
            this.picName = new System.Windows.Forms.PictureBox();
            this.picPass = new System.Windows.Forms.PictureBox();
            this.picNum = new System.Windows.Forms.PictureBox();
            this.picTime = new System.Windows.Forms.PictureBox();
            this.dgvExamList = new System.Windows.Forms.DataGridView();
            this.rownum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.num = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.effective_time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pass_criteria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalscore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblUnfinished = new System.Windows.Forms.Label();
            this.lblFinished = new System.Windows.Forms.Label();
            this.lblAll = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.pnlNotice = new System.Windows.Forms.Panel();
            this.pnlTip = new System.Windows.Forms.Panel();
            this.lblNotice1 = new System.Windows.Forms.Label();
            this.shapeContainer3 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape5 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.pnlHome = new System.Windows.Forms.Panel();
            this.pnlAbout = new System.Windows.Forms.Panel();
            this.lblExaminationRule = new UI.AdvancedLabel();
            this.lblRule6 = new System.Windows.Forms.Label();
            this.lblRule5 = new System.Windows.Forms.Label();
            this.lblRule4 = new System.Windows.Forms.Label();
            this.lblRule2 = new System.Windows.Forms.Label();
            this.lblRule1 = new System.Windows.Forms.Label();
            this.lblExamRule = new System.Windows.Forms.Label();
            this.lblContact = new System.Windows.Forms.Label();
            this.lblSysInfo = new System.Windows.Forms.Label();
            this.lblNotice2 = new System.Windows.Forms.Label();
            this.shapeContainer4 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape6 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lblTabAbout = new System.Windows.Forms.Label();
            this.lblTabNotice = new System.Windows.Forms.Label();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lsVertical = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lsBottom = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lsTop = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.bgwStudentList = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlNav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).BeginInit();
            this.pnlExam.SuspendLayout();
            this.pnlOrderTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOperation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamList)).BeginInit();
            this.pnlNotice.SuspendLayout();
            this.pnlHome.SuspendLayout();
            this.pnlAbout.SuspendLayout();
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
            // picMin
            // 
            resources.ApplyResources(this.picMin, "picMin");
            this.picMin.Image = global::UI.Properties.Resources.LOGO_Client_Minimize;
            this.picMin.Name = "picMin";
            this.picMin.TabStop = false;
            // 
            // picClose
            // 
            resources.ApplyResources(this.picClose, "picClose");
            this.picClose.Image = global::UI.Properties.Resources.LOGO_Client_TS_Close;
            this.picClose.Name = "picClose";
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.DoPicCloseOnClick);
            // 
            // picMax
            // 
            resources.ApplyResources(this.picMax, "picMax");
            this.picMax.Image = global::UI.Properties.Resources.LOGO_Client_Maxmize;
            this.picMax.Name = "picMax";
            this.picMax.TabStop = false;
            // 
            // picLogo
            // 
            resources.ApplyResources(this.picLogo, "picLogo");
            this.picLogo.Name = "picLogo";
            this.picLogo.TabStop = false;
            // 
            // pnlNav
            // 
            resources.ApplyResources(this.pnlNav, "pnlNav");
            this.pnlNav.BackColor = System.Drawing.Color.White;
            this.pnlNav.Controls.Add(this.lblLogout);
            this.pnlNav.Controls.Add(this.picUser);
            this.pnlNav.Controls.Add(this.llblName);
            this.pnlNav.Controls.Add(this.llblChinese);
            this.pnlNav.Controls.Add(this.lblExamTab);
            this.pnlNav.Controls.Add(this.lblHomeTab);
            this.pnlNav.Name = "pnlNav";
            // 
            // lblLogout
            // 
            resources.ApplyResources(this.lblLogout, "lblLogout");
            this.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Click += new System.EventHandler(this.DoLogoutOnClick);
            // 
            // picUser
            // 
            resources.ApplyResources(this.picUser, "picUser");
            this.picUser.Name = "picUser";
            this.picUser.TabStop = false;
            // 
            // llblName
            // 
            resources.ApplyResources(this.llblName, "llblName");
            this.llblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.llblName.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblName.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.llblName.Name = "llblName";
            // 
            // llblChinese
            // 
            resources.ApplyResources(this.llblChinese, "llblChinese");
            this.llblChinese.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.llblChinese.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblChinese.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.llblChinese.Name = "llblChinese";
            this.llblChinese.TabStop = true;
            this.llblChinese.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DoLlblChineseOnLinkClicked);
            // 
            // lblExamTab
            // 
            resources.ApplyResources(this.lblExamTab, "lblExamTab");
            this.lblExamTab.BackColor = System.Drawing.Color.White;
            this.lblExamTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExamTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblExamTab.Name = "lblExamTab";
            this.lblExamTab.Tag = "lblHomeTab";
            this.lblExamTab.Click += new System.EventHandler(this.DoLblExamTabOnClick);
            // 
            // lblHomeTab
            // 
            resources.ApplyResources(this.lblHomeTab, "lblHomeTab");
            this.lblHomeTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.lblHomeTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHomeTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblHomeTab.Name = "lblHomeTab";
            this.lblHomeTab.Tag = "lblExamTab";
            this.lblHomeTab.Click += new System.EventHandler(this.DoLblHomeTabOnClick);
            // 
            // pnlExam
            // 
            resources.ApplyResources(this.pnlExam, "pnlExam");
            this.pnlExam.BackColor = System.Drawing.Color.White;
            this.pnlExam.Controls.Add(this.pnlOrderTitle);
            this.pnlExam.Controls.Add(this.dgvExamList);
            this.pnlExam.Controls.Add(this.lblUnfinished);
            this.pnlExam.Controls.Add(this.lblFinished);
            this.pnlExam.Controls.Add(this.lblAll);
            this.pnlExam.Controls.Add(this.shapeContainer1);
            this.pnlExam.Name = "pnlExam";
            // 
            // pnlOrderTitle
            // 
            resources.ApplyResources(this.pnlOrderTitle, "pnlOrderTitle");
            this.pnlOrderTitle.Controls.Add(this.lblName);
            this.pnlOrderTitle.Controls.Add(this.lblNum);
            this.pnlOrderTitle.Controls.Add(this.lblTime);
            this.pnlOrderTitle.Controls.Add(this.lblDuration);
            this.pnlOrderTitle.Controls.Add(this.lblPassCriteria);
            this.pnlOrderTitle.Controls.Add(this.lblScore);
            this.pnlOrderTitle.Controls.Add(this.picOperation);
            this.pnlOrderTitle.Controls.Add(this.lblOperation);
            this.pnlOrderTitle.Controls.Add(this.picScore);
            this.pnlOrderTitle.Controls.Add(this.picName);
            this.pnlOrderTitle.Controls.Add(this.picPass);
            this.pnlOrderTitle.Controls.Add(this.picNum);
            this.pnlOrderTitle.Controls.Add(this.picTime);
            this.pnlOrderTitle.Name = "pnlOrderTitle";
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
            // lblDuration
            // 
            resources.ApplyResources(this.lblDuration, "lblDuration");
            this.lblDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblDuration.Name = "lblDuration";
            // 
            // lblPassCriteria
            // 
            resources.ApplyResources(this.lblPassCriteria, "lblPassCriteria");
            this.lblPassCriteria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPassCriteria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblPassCriteria.Name = "lblPassCriteria";
            this.lblPassCriteria.Tag = "picPass";
            this.lblPassCriteria.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblScore
            // 
            resources.ApplyResources(this.lblScore, "lblScore");
            this.lblScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblScore.Name = "lblScore";
            this.lblScore.Tag = "picScore";
            this.lblScore.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picOperation
            // 
            resources.ApplyResources(this.picOperation, "picOperation");
            this.picOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOperation.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picOperation.Name = "picOperation";
            this.picOperation.TabStop = false;
            this.picOperation.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblOperation
            // 
            resources.ApplyResources(this.lblOperation, "lblOperation");
            this.lblOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Tag = "picOperation";
            this.lblOperation.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picScore
            // 
            resources.ApplyResources(this.picScore, "picScore");
            this.picScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picScore.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picScore.Name = "picScore";
            this.picScore.TabStop = false;
            this.picScore.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picName
            // 
            resources.ApplyResources(this.picName, "picName");
            this.picName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picName.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picName.Name = "picName";
            this.picName.TabStop = false;
            this.picName.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picPass
            // 
            resources.ApplyResources(this.picPass, "picPass");
            this.picPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPass.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picPass.Name = "picPass";
            this.picPass.TabStop = false;
            this.picPass.Click += new System.EventHandler(this.DoPicOrderOnClick);
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
            // dgvExamList
            // 
            resources.ApplyResources(this.dgvExamList, "dgvExamList");
            this.dgvExamList.AllowUserToAddRows = false;
            this.dgvExamList.AllowUserToDeleteRows = false;
            this.dgvExamList.AllowUserToResizeColumns = false;
            this.dgvExamList.AllowUserToResizeRows = false;
            this.dgvExamList.BackgroundColor = System.Drawing.Color.White;
            this.dgvExamList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvExamList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvExamList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExamList.ColumnHeadersVisible = false;
            this.dgvExamList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rownum,
            this.id,
            this.name,
            this.num,
            this.effective_time,
            this.duration,
            this.pass_criteria,
            this.totalscore,
            this.status});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvExamList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvExamList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.dgvExamList.MultiSelect = false;
            this.dgvExamList.Name = "dgvExamList";
            this.dgvExamList.ReadOnly = true;
            this.dgvExamList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvExamList.RowHeadersVisible = false;
            this.dgvExamList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.Transparent;
            this.dgvExamList.RowTemplate.DividerHeight = 1;
            this.dgvExamList.RowTemplate.Height = 40;
            this.dgvExamList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvExamList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DoDgvExamListOnCellContentClick);
            this.dgvExamList.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DoDgvExamListOnCellPainting);
            this.dgvExamList.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.DodgvExamListRowPrePaint);
            // 
            // rownum
            // 
            this.rownum.DataPropertyName = "Rownum";
            resources.ApplyResources(this.rownum, "rownum");
            this.rownum.Name = "rownum";
            this.rownum.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "Id";
            resources.ApplyResources(this.id, "id");
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // name
            // 
            this.name.DataPropertyName = "Name";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.name.DefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.name, "name");
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // num
            // 
            this.num.DataPropertyName = "Num";
            resources.ApplyResources(this.num, "num");
            this.num.Name = "num";
            this.num.ReadOnly = true;
            // 
            // effective_time
            // 
            this.effective_time.DataPropertyName = "EffectiveTime";
            resources.ApplyResources(this.effective_time, "effective_time");
            this.effective_time.Name = "effective_time";
            this.effective_time.ReadOnly = true;
            // 
            // duration
            // 
            this.duration.DataPropertyName = "Duration";
            resources.ApplyResources(this.duration, "duration");
            this.duration.Name = "duration";
            this.duration.ReadOnly = true;
            // 
            // pass_criteria
            // 
            this.pass_criteria.DataPropertyName = "PassCriteria";
            resources.ApplyResources(this.pass_criteria, "pass_criteria");
            this.pass_criteria.Name = "pass_criteria";
            this.pass_criteria.ReadOnly = true;
            // 
            // totalscore
            // 
            this.totalscore.DataPropertyName = "Score";
            resources.ApplyResources(this.totalscore, "totalscore");
            this.totalscore.Name = "totalscore";
            this.totalscore.ReadOnly = true;
            // 
            // status
            // 
            this.status.DataPropertyName = "Status";
            resources.ApplyResources(this.status, "status");
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // lblUnfinished
            // 
            resources.ApplyResources(this.lblUnfinished, "lblUnfinished");
            this.lblUnfinished.BackColor = System.Drawing.Color.White;
            this.lblUnfinished.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUnfinished.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblUnfinished.Name = "lblUnfinished";
            this.lblUnfinished.Click += new System.EventHandler(this.DoLblUnfinishedOnClick);
            // 
            // lblFinished
            // 
            resources.ApplyResources(this.lblFinished, "lblFinished");
            this.lblFinished.BackColor = System.Drawing.Color.White;
            this.lblFinished.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFinished.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblFinished.Name = "lblFinished";
            this.lblFinished.Click += new System.EventHandler(this.DoLblFinishedOnClick);
            // 
            // lblAll
            // 
            resources.ApplyResources(this.lblAll, "lblAll");
            this.lblAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAll.ForeColor = System.Drawing.Color.White;
            this.lblAll.Name = "lblAll";
            this.lblAll.Click += new System.EventHandler(this.DoLblAllOnClick);
            // 
            // shapeContainer1
            // 
            resources.ApplyResources(this.shapeContainer1, "shapeContainer1");
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            resources.ApplyResources(this.lineShape2, "lineShape2");
            this.lineShape2.Name = "lineShape2";
            // 
            // lineShape1
            // 
            resources.ApplyResources(this.lineShape1, "lineShape1");
            this.lineShape1.Name = "lineShape1";
            // 
            // pnlNotice
            // 
            resources.ApplyResources(this.pnlNotice, "pnlNotice");
            this.pnlNotice.BackColor = System.Drawing.Color.White;
            this.pnlNotice.Controls.Add(this.pnlTip);
            this.pnlNotice.Controls.Add(this.lblNotice1);
            this.pnlNotice.Controls.Add(this.shapeContainer3);
            this.pnlNotice.Name = "pnlNotice";
            // 
            // pnlTip
            // 
            resources.ApplyResources(this.pnlTip, "pnlTip");
            this.pnlTip.Name = "pnlTip";
            // 
            // lblNotice1
            // 
            resources.ApplyResources(this.lblNotice1, "lblNotice1");
            this.lblNotice1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblNotice1.Name = "lblNotice1";
            // 
            // shapeContainer3
            // 
            resources.ApplyResources(this.shapeContainer3, "shapeContainer3");
            this.shapeContainer3.Name = "shapeContainer3";
            this.shapeContainer3.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape5});
            this.shapeContainer3.TabStop = false;
            // 
            // lineShape5
            // 
            resources.ApplyResources(this.lineShape5, "lineShape5");
            this.lineShape5.Name = "lineShape5";
            // 
            // pnlHome
            // 
            resources.ApplyResources(this.pnlHome, "pnlHome");
            this.pnlHome.BackColor = System.Drawing.Color.White;
            this.pnlHome.Controls.Add(this.pnlAbout);
            this.pnlHome.Controls.Add(this.pnlNotice);
            this.pnlHome.Controls.Add(this.lblTabAbout);
            this.pnlHome.Controls.Add(this.lblTabNotice);
            this.pnlHome.Controls.Add(this.shapeContainer2);
            this.pnlHome.Name = "pnlHome";
            // 
            // pnlAbout
            // 
            resources.ApplyResources(this.pnlAbout, "pnlAbout");
            this.pnlAbout.Controls.Add(this.lblExaminationRule);
            this.pnlAbout.Controls.Add(this.lblRule6);
            this.pnlAbout.Controls.Add(this.lblRule5);
            this.pnlAbout.Controls.Add(this.lblRule4);
            this.pnlAbout.Controls.Add(this.lblRule2);
            this.pnlAbout.Controls.Add(this.lblRule1);
            this.pnlAbout.Controls.Add(this.lblExamRule);
            this.pnlAbout.Controls.Add(this.lblContact);
            this.pnlAbout.Controls.Add(this.lblSysInfo);
            this.pnlAbout.Controls.Add(this.lblNotice2);
            this.pnlAbout.Controls.Add(this.shapeContainer4);
            this.pnlAbout.Name = "pnlAbout";
            // 
            // lblExaminationRule
            // 
            resources.ApplyResources(this.lblExaminationRule, "lblExaminationRule");
            this.lblExaminationRule.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.lblExaminationRule.BorderSize = 1F;
            this.lblExaminationRule.DefaultBackColor = System.Drawing.Color.Empty;
            this.lblExaminationRule.DefaultFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblExaminationRule.DefaultFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.lblExaminationRule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.lblExaminationRule.MouseDownBackColor = System.Drawing.Color.Empty;
            this.lblExaminationRule.MouseDownFont = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblExaminationRule.MouseDownFontColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.lblExaminationRule.Name = "lblExaminationRule";
            this.lblExaminationRule.Radius = 5F;
            // 
            // lblRule6
            // 
            resources.ApplyResources(this.lblRule6, "lblRule6");
            this.lblRule6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblRule6.Name = "lblRule6";
            // 
            // lblRule5
            // 
            resources.ApplyResources(this.lblRule5, "lblRule5");
            this.lblRule5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblRule5.Name = "lblRule5";
            // 
            // lblRule4
            // 
            resources.ApplyResources(this.lblRule4, "lblRule4");
            this.lblRule4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblRule4.Name = "lblRule4";
            // 
            // lblRule2
            // 
            resources.ApplyResources(this.lblRule2, "lblRule2");
            this.lblRule2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblRule2.Name = "lblRule2";
            // 
            // lblRule1
            // 
            resources.ApplyResources(this.lblRule1, "lblRule1");
            this.lblRule1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblRule1.Name = "lblRule1";
            // 
            // lblExamRule
            // 
            resources.ApplyResources(this.lblExamRule, "lblExamRule");
            this.lblExamRule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblExamRule.Name = "lblExamRule";
            // 
            // lblContact
            // 
            resources.ApplyResources(this.lblContact, "lblContact");
            this.lblContact.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.lblContact.Name = "lblContact";
            // 
            // lblSysInfo
            // 
            resources.ApplyResources(this.lblSysInfo, "lblSysInfo");
            this.lblSysInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblSysInfo.Name = "lblSysInfo";
            // 
            // lblNotice2
            // 
            resources.ApplyResources(this.lblNotice2, "lblNotice2");
            this.lblNotice2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblNotice2.Name = "lblNotice2";
            // 
            // shapeContainer4
            // 
            resources.ApplyResources(this.shapeContainer4, "shapeContainer4");
            this.shapeContainer4.Name = "shapeContainer4";
            this.shapeContainer4.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape6});
            this.shapeContainer4.TabStop = false;
            // 
            // lineShape6
            // 
            resources.ApplyResources(this.lineShape6, "lineShape6");
            this.lineShape6.Name = "lineShape6";
            // 
            // lblTabAbout
            // 
            resources.ApplyResources(this.lblTabAbout, "lblTabAbout");
            this.lblTabAbout.BackColor = System.Drawing.Color.White;
            this.lblTabAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabAbout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.lblTabAbout.Name = "lblTabAbout";
            this.lblTabAbout.Click += new System.EventHandler(this.DoLblTabAboutOnClick);
            // 
            // lblTabNotice
            // 
            resources.ApplyResources(this.lblTabNotice, "lblTabNotice");
            this.lblTabNotice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(66)))), ((int)(((byte)(88)))));
            this.lblTabNotice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTabNotice.ForeColor = System.Drawing.Color.White;
            this.lblTabNotice.Name = "lblTabNotice";
            this.lblTabNotice.Click += new System.EventHandler(this.DoLblTabNoticeOnClick);
            // 
            // shapeContainer2
            // 
            resources.ApplyResources(this.shapeContainer2, "shapeContainer2");
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lsVertical,
            this.lsBottom,
            this.lsTop});
            this.shapeContainer2.TabStop = false;
            // 
            // lsVertical
            // 
            resources.ApplyResources(this.lsVertical, "lsVertical");
            this.lsVertical.Name = "lsVertical";
            // 
            // lsBottom
            // 
            resources.ApplyResources(this.lsBottom, "lsBottom");
            this.lsBottom.Name = "lsBottom";
            // 
            // lsTop
            // 
            resources.ApplyResources(this.lsTop, "lsTop");
            this.lsTop.Name = "lsTop";
            // 
            // bgwStudentList
            // 
            this.bgwStudentList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoBgwStudentListDoWork);
            this.bgwStudentList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoBgwStudentListRunWorkerCompleted);
            // 
            // FormStudent
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.Controls.Add(this.pnlExam);
            this.Controls.Add(this.pnlHome);
            this.Controls.Add(this.pnlNav);
            this.Name = "FormStudent";
            this.Controls.SetChildIndex(this.pnlNav, 0);
            this.Controls.SetChildIndex(this.pnlHome, 0);
            this.Controls.SetChildIndex(this.pnlExam, 0);
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlNav.ResumeLayout(false);
            this.pnlNav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUser)).EndInit();
            this.pnlExam.ResumeLayout(false);
            this.pnlOrderTitle.ResumeLayout(false);
            this.pnlOrderTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOperation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picScore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExamList)).EndInit();
            this.pnlNotice.ResumeLayout(false);
            this.pnlHome.ResumeLayout(false);
            this.pnlAbout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label lblExamTab;
        private System.Windows.Forms.Label lblHomeTab;
        private System.Windows.Forms.LinkLabel llblChinese;
        private System.Windows.Forms.PictureBox picUser;
        private System.Windows.Forms.Panel pnlExam;
        private System.Windows.Forms.Label lblAll;
        private System.Windows.Forms.Label lblUnfinished;
        private System.Windows.Forms.Label lblFinished;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.DataGridView dgvExamList;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lblPassCriteria;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox picOperation;
        private System.Windows.Forms.PictureBox picScore;
        private System.Windows.Forms.PictureBox picPass;
        private System.Windows.Forms.PictureBox picTime;
        private System.Windows.Forms.PictureBox picNum;
        private System.Windows.Forms.PictureBox picName;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Panel pnlHome;
        private System.Windows.Forms.Label lblTabAbout;
        private System.Windows.Forms.Label lblTabNotice;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lsBottom;
        private Microsoft.VisualBasic.PowerPacks.LineShape lsTop;
        private Microsoft.VisualBasic.PowerPacks.LineShape lsVertical;
        private System.Windows.Forms.Label lblNotice1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape5;
        private System.Windows.Forms.Panel pnlNotice;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer3;
        private System.Windows.Forms.Panel pnlAbout;
        private System.Windows.Forms.Label lblNotice2;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer4;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape6;
        private System.Windows.Forms.Label lblContact;
        private System.Windows.Forms.Label lblSysInfo;
        private System.Windows.Forms.Label lblExamRule;
        private System.Windows.Forms.Label lblRule1;
        private System.Windows.Forms.Label lblRule6;
        private System.Windows.Forms.Label lblRule5;
        private System.Windows.Forms.Label lblRule4;
        private System.Windows.Forms.Label lblRule2;
        private System.Windows.Forms.Panel pnlOrderTitle;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMax;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Panel pnlTip;
        public System.Windows.Forms.LinkLabel llblName;
        private AdvancedLabel lblExaminationRule;
        private System.Windows.Forms.DataGridViewTextBoxColumn rownum;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn num;
        private System.Windows.Forms.DataGridViewTextBoxColumn effective_time;
        private System.Windows.Forms.DataGridViewTextBoxColumn duration;
        private System.Windows.Forms.DataGridViewTextBoxColumn pass_criteria;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalscore;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.ComponentModel.BackgroundWorker bgwStudentList;

    }
}