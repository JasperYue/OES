namespace UI
{
    partial class DemoPanelLoop
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DemoPanelLoop));
            this.pnlNav = new System.Windows.Forms.Panel();
            this.lblLogout = new System.Windows.Forms.Label();
            this.picUser = new System.Windows.Forms.PictureBox();
            this.llblName = new System.Windows.Forms.LinkLabel();
            this.llblChinese = new System.Windows.Forms.LinkLabel();
            this.lblExamTab = new System.Windows.Forms.Label();
            this.pnlExam = new System.Windows.Forms.Panel();
            this.pnlExamList = new System.Windows.Forms.Panel();
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
            this.lblUnfinished = new System.Windows.Forms.Label();
            this.lblFinished = new System.Windows.Forms.Label();
            this.lblAll = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.bgwExamList = new System.ComponentModel.BackgroundWorker();
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
            this.SuspendLayout();
            // 
            // pnlNav
            // 
            this.pnlNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlNav.BackColor = System.Drawing.Color.White;
            this.pnlNav.Controls.Add(this.lblLogout);
            this.pnlNav.Controls.Add(this.picUser);
            this.pnlNav.Controls.Add(this.llblName);
            this.pnlNav.Controls.Add(this.llblChinese);
            this.pnlNav.Controls.Add(this.lblExamTab);
            this.pnlNav.Location = new System.Drawing.Point(0, 28);
            this.pnlNav.Name = "pnlNav";
            this.pnlNav.Size = new System.Drawing.Size(1024, 40);
            this.pnlNav.TabIndex = 2;
            // 
            // lblLogout
            // 
            this.lblLogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblLogout.AutoSize = true;
            this.lblLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogout.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLogout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblLogout.Location = new System.Drawing.Point(956, 12);
            this.lblLogout.Name = "lblLogout";
            this.lblLogout.Size = new System.Drawing.Size(52, 16);
            this.lblLogout.TabIndex = 5;
            this.lblLogout.Text = "Logout";
            this.lblLogout.Click += new System.EventHandler(this.DoLogoutOnClick);
            // 
            // picUser
            // 
            this.picUser.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.picUser.Image = ((System.Drawing.Image)(resources.GetObject("picUser.Image")));
            this.picUser.Location = new System.Drawing.Point(780, 10);
            this.picUser.Margin = new System.Windows.Forms.Padding(0);
            this.picUser.Name = "picUser";
            this.picUser.Size = new System.Drawing.Size(20, 20);
            this.picUser.TabIndex = 5;
            this.picUser.TabStop = false;
            // 
            // llblName
            // 
            this.llblName.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.llblName.AutoSize = true;
            this.llblName.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.llblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.llblName.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblName.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(103)))), ((int)(((byte)(147)))));
            this.llblName.Location = new System.Drawing.Point(806, 12);
            this.llblName.Name = "llblName";
            this.llblName.Size = new System.Drawing.Size(0, 16);
            this.llblName.TabIndex = 4;
            this.llblName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // llblChinese
            // 
            this.llblChinese.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.llblChinese.AutoSize = true;
            this.llblChinese.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.llblChinese.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.llblChinese.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblChinese.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.llblChinese.Location = new System.Drawing.Point(904, 12);
            this.llblChinese.Name = "llblChinese";
            this.llblChinese.Size = new System.Drawing.Size(36, 16);
            this.llblChinese.TabIndex = 3;
            this.llblChinese.TabStop = true;
            this.llblChinese.Text = "中文";
            this.llblChinese.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExamTab
            // 
            this.lblExamTab.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblExamTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.lblExamTab.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExamTab.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblExamTab.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblExamTab.Location = new System.Drawing.Point(20, 0);
            this.lblExamTab.Margin = new System.Windows.Forms.Padding(0);
            this.lblExamTab.Name = "lblExamTab";
            this.lblExamTab.Size = new System.Drawing.Size(110, 40);
            this.lblExamTab.TabIndex = 1;
            this.lblExamTab.Tag = "lblHomeTab";
            this.lblExamTab.Text = "My Exam";
            this.lblExamTab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlExam
            // 
            this.pnlExam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlExam.BackColor = System.Drawing.Color.White;
            this.pnlExam.Controls.Add(this.pnlExamList);
            this.pnlExam.Controls.Add(this.pnlOrderTitle);
            this.pnlExam.Controls.Add(this.lblUnfinished);
            this.pnlExam.Controls.Add(this.lblFinished);
            this.pnlExam.Controls.Add(this.lblAll);
            this.pnlExam.Controls.Add(this.shapeContainer1);
            this.pnlExam.Location = new System.Drawing.Point(20, 90);
            this.pnlExam.Name = "pnlExam";
            this.pnlExam.Size = new System.Drawing.Size(985, 660);
            this.pnlExam.TabIndex = 3;
            // 
            // pnlExamList
            // 
            this.pnlExamList.Location = new System.Drawing.Point(0, 116);
            this.pnlExamList.Name = "pnlExamList";
            this.pnlExamList.Size = new System.Drawing.Size(985, 400);
            this.pnlExamList.TabIndex = 31;
            // 
            // pnlOrderTitle
            // 
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
            this.pnlOrderTitle.Location = new System.Drawing.Point(0, 73);
            this.pnlOrderTitle.Name = "pnlOrderTitle";
            this.pnlOrderTitle.Size = new System.Drawing.Size(985, 40);
            this.pnlOrderTitle.TabIndex = 30;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.AutoSize = true;
            this.lblName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblName.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblName.Location = new System.Drawing.Point(101, 13);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 16);
            this.lblName.TabIndex = 5;
            this.lblName.Tag = "picName";
            this.lblName.Text = "Name";
            this.lblName.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblNum
            // 
            this.lblNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNum.AutoSize = true;
            this.lblNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblNum.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblNum.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblNum.Location = new System.Drawing.Point(232, 13);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(37, 16);
            this.lblNum.TabIndex = 6;
            this.lblNum.Tag = "picNum";
            this.lblNum.Text = "NUM";
            this.lblNum.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTime.AutoSize = true;
            this.lblTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTime.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblTime.Location = new System.Drawing.Point(323, 13);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(97, 16);
            this.lblTime.TabIndex = 7;
            this.lblTime.Tag = "picTime";
            this.lblTime.Text = "Effective Time";
            this.lblTime.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblDuration
            // 
            this.lblDuration.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblDuration.AutoSize = true;
            this.lblDuration.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblDuration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblDuration.Location = new System.Drawing.Point(475, 12);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(62, 16);
            this.lblDuration.TabIndex = 8;
            this.lblDuration.Text = "Duration";
            // 
            // lblPassCriteria
            // 
            this.lblPassCriteria.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPassCriteria.AutoSize = true;
            this.lblPassCriteria.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPassCriteria.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblPassCriteria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblPassCriteria.Location = new System.Drawing.Point(577, 13);
            this.lblPassCriteria.Name = "lblPassCriteria";
            this.lblPassCriteria.Size = new System.Drawing.Size(89, 16);
            this.lblPassCriteria.TabIndex = 9;
            this.lblPassCriteria.Tag = "picPass";
            this.lblPassCriteria.Text = "Pass Criteria";
            this.lblPassCriteria.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblScore
            // 
            this.lblScore.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblScore.AutoSize = true;
            this.lblScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblScore.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblScore.Location = new System.Drawing.Point(700, 13);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(119, 16);
            this.lblScore.TabIndex = 10;
            this.lblScore.Tag = "picScore";
            this.lblScore.Text = "Exam/Total Score";
            this.lblScore.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picOperation
            // 
            this.picOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.picOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOperation.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picOperation.Location = new System.Drawing.Point(946, 14);
            this.picOperation.Name = "picOperation";
            this.picOperation.Size = new System.Drawing.Size(10, 15);
            this.picOperation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picOperation.TabIndex = 17;
            this.picOperation.TabStop = false;
            this.picOperation.Visible = false;
            this.picOperation.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblOperation
            // 
            this.lblOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOperation.AutoSize = true;
            this.lblOperation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOperation.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblOperation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            this.lblOperation.Location = new System.Drawing.Point(875, 13);
            this.lblOperation.Name = "lblOperation";
            this.lblOperation.Size = new System.Drawing.Size(71, 16);
            this.lblOperation.TabIndex = 11;
            this.lblOperation.Tag = "picOperation";
            this.lblOperation.Text = "Operation";
            this.lblOperation.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picScore
            // 
            this.picScore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.picScore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picScore.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picScore.Location = new System.Drawing.Point(818, 13);
            this.picScore.Name = "picScore";
            this.picScore.Size = new System.Drawing.Size(10, 15);
            this.picScore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picScore.TabIndex = 16;
            this.picScore.TabStop = false;
            this.picScore.Visible = false;
            this.picScore.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picName
            // 
            this.picName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.picName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picName.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picName.Location = new System.Drawing.Point(143, 13);
            this.picName.Name = "picName";
            this.picName.Size = new System.Drawing.Size(10, 15);
            this.picName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picName.TabIndex = 12;
            this.picName.TabStop = false;
            this.picName.Visible = false;
            this.picName.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picPass
            // 
            this.picPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.picPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPass.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picPass.Location = new System.Drawing.Point(665, 13);
            this.picPass.Name = "picPass";
            this.picPass.Size = new System.Drawing.Size(10, 15);
            this.picPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPass.TabIndex = 15;
            this.picPass.TabStop = false;
            this.picPass.Visible = false;
            this.picPass.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picNum
            // 
            this.picNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.picNum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNum.Image = global::UI.Properties.Resources.ICN_Increase_10x15_png;
            this.picNum.Location = new System.Drawing.Point(267, 13);
            this.picNum.Name = "picNum";
            this.picNum.Size = new System.Drawing.Size(10, 15);
            this.picNum.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picNum.TabIndex = 13;
            this.picNum.TabStop = false;
            this.picNum.Visible = false;
            this.picNum.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // picTime
            // 
            this.picTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.picTime.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picTime.Image = global::UI.Properties.Resources.ICN_Decrese_10x15_png;
            this.picTime.Location = new System.Drawing.Point(418, 13);
            this.picTime.Name = "picTime";
            this.picTime.Size = new System.Drawing.Size(10, 15);
            this.picTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picTime.TabIndex = 14;
            this.picTime.TabStop = false;
            this.picTime.Visible = false;
            this.picTime.Click += new System.EventHandler(this.DoPicOrderOnClick);
            // 
            // lblUnfinished
            // 
            this.lblUnfinished.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblUnfinished.BackColor = System.Drawing.Color.White;
            this.lblUnfinished.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUnfinished.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblUnfinished.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblUnfinished.Location = new System.Drawing.Point(555, 30);
            this.lblUnfinished.Name = "lblUnfinished";
            this.lblUnfinished.Size = new System.Drawing.Size(100, 30);
            this.lblUnfinished.TabIndex = 2;
            this.lblUnfinished.Text = "Unfinished";
            this.lblUnfinished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUnfinished.Click += new System.EventHandler(this.DoLblUnfinishedOnClick);
            // 
            // lblFinished
            // 
            this.lblFinished.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblFinished.BackColor = System.Drawing.Color.White;
            this.lblFinished.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblFinished.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblFinished.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblFinished.Location = new System.Drawing.Point(427, 30);
            this.lblFinished.Name = "lblFinished";
            this.lblFinished.Size = new System.Drawing.Size(100, 30);
            this.lblFinished.TabIndex = 1;
            this.lblFinished.Text = "Finished";
            this.lblFinished.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFinished.Click += new System.EventHandler(this.DoLblFinishedOnClick);
            // 
            // lblAll
            // 
            this.lblAll.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lblAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblAll.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblAll.ForeColor = System.Drawing.Color.White;
            this.lblAll.Location = new System.Drawing.Point(300, 30);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(100, 30);
            this.lblAll.TabIndex = 0;
            this.lblAll.Text = "All";
            this.lblAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAll.Click += new System.EventHandler(this.DoLblAllOnClick);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(985, 660);
            this.shapeContainer1.TabIndex = 3;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 0;
            this.lineShape2.X2 = 985;
            this.lineShape2.Y1 = 115;
            this.lineShape2.Y2 = 115;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 0;
            this.lineShape1.X2 = 985;
            this.lineShape1.Y1 = 70;
            this.lineShape1.Y2 = 70;
            // 
            // bgwExamList
            // 
            this.bgwExamList.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoBgwExamListDoWork);
            this.bgwExamList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoBgwExamListRunWorkerCompleted);
            // 
            // DemoPanelLoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(227)))));
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.pnlExam);
            this.Controls.Add(this.pnlNav);
            this.Name = "DemoPanelLoop";
            this.Text = "DemoPanelLoop";
            this.Controls.SetChildIndex(this.pnlNav, 0);
            this.Controls.SetChildIndex(this.pnlExam, 0);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlNav;
        private System.Windows.Forms.Label lblLogout;
        private System.Windows.Forms.PictureBox picUser;
        public System.Windows.Forms.LinkLabel llblName;
        private System.Windows.Forms.LinkLabel llblChinese;
        private System.Windows.Forms.Label lblExamTab;
        private System.Windows.Forms.Panel pnlExam;
        private System.Windows.Forms.Panel pnlOrderTitle;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblNum;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblPassCriteria;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.PictureBox picOperation;
        private System.Windows.Forms.Label lblOperation;
        private System.Windows.Forms.PictureBox picScore;
        private System.Windows.Forms.PictureBox picName;
        private System.Windows.Forms.PictureBox picPass;
        private System.Windows.Forms.PictureBox picNum;
        private System.Windows.Forms.PictureBox picTime;
        private System.Windows.Forms.Label lblUnfinished;
        private System.Windows.Forms.Label lblFinished;
        private System.Windows.Forms.Label lblAll;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Panel pnlExamList;
        private System.ComponentModel.BackgroundWorker bgwExamList;
    }
}