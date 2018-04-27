namespace UI
{
    partial class BaseForm
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.picMin = new System.Windows.Forms.PictureBox();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.picMax = new System.Windows.Forms.PictureBox();
            this.lblSystem = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlPageBar = new System.Windows.Forms.Panel();
            this.lblGo = new System.Windows.Forms.Label();
            this.txtPageNo = new System.Windows.Forms.TextBox();
            this.lblPerPage = new System.Windows.Forms.Label();
            this.cboPageSize = new System.Windows.Forms.ComboBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            resources.ApplyResources(this.pnlHeader, "pnlHeader");
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.pnlHeader.Controls.Add(this.picMin);
            this.pnlHeader.Controls.Add(this.picClose);
            this.pnlHeader.Controls.Add(this.picMax);
            this.pnlHeader.Controls.Add(this.lblSystem);
            this.pnlHeader.Controls.Add(this.picLogo);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DoFormMouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DoFormMouseMove);
            // 
            // picMin
            // 
            resources.ApplyResources(this.picMin, "picMin");
            this.picMin.Image = global::UI.Properties.Resources.LOGO_Client_Minimize;
            this.picMin.Name = "picMin";
            this.picMin.TabStop = false;
            this.picMin.Click += new System.EventHandler(this.DoPicMinOnClick);
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
            this.picMax.Click += new System.EventHandler(this.DopicMaxOnClick);
            // 
            // lblSystem
            // 
            resources.ApplyResources(this.lblSystem, "lblSystem");
            this.lblSystem.ForeColor = System.Drawing.Color.White;
            this.lblSystem.Name = "lblSystem";
            // 
            // picLogo
            // 
            resources.ApplyResources(this.picLogo, "picLogo");
            this.picLogo.Name = "picLogo";
            this.picLogo.TabStop = false;
            // 
            // pnlPageBar
            // 
            resources.ApplyResources(this.pnlPageBar, "pnlPageBar");
            this.pnlPageBar.BackColor = System.Drawing.Color.White;
            this.pnlPageBar.Name = "pnlPageBar";
            // 
            // lblGo
            // 
            resources.ApplyResources(this.lblGo, "lblGo");
            this.lblGo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.lblGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblGo.ForeColor = System.Drawing.Color.White;
            this.lblGo.Name = "lblGo";
            // 
            // txtPageNo
            // 
            resources.ApplyResources(this.txtPageNo, "txtPageNo");
            this.txtPageNo.Name = "txtPageNo";
            // 
            // lblPerPage
            // 
            resources.ApplyResources(this.lblPerPage, "lblPerPage");
            this.lblPerPage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(94)))), ((int)(((byte)(94)))));
            this.lblPerPage.Name = "lblPerPage";
            // 
            // cboPageSize
            // 
            resources.ApplyResources(this.cboPageSize, "cboPageSize");
            this.cboPageSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPageSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.cboPageSize.FormattingEnabled = true;
            this.cboPageSize.Items.AddRange(new object[] {
            resources.GetString("cboPageSize.Items"),
            resources.GetString("cboPageSize.Items1")});
            this.cboPageSize.Name = "cboPageSize";
            // 
            // BaseForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BaseForm";
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picMin;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.PictureBox picMax;
        private System.Windows.Forms.PictureBox picLogo;
        public System.Windows.Forms.Label lblSystem;
        private System.Windows.Forms.Panel pnlPageBar;
        private System.Windows.Forms.Label lblGo;
        public System.Windows.Forms.TextBox txtPageNo;
        private System.Windows.Forms.Label lblPerPage;
        public System.Windows.Forms.ComboBox cboPageSize;
    }
}
