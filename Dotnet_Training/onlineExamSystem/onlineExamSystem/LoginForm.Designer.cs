namespace UI
{
    partial class FormLogin
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
            lblLogin.Focus();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.btnCloseLogin = new System.Windows.Forms.PictureBox();
            this.picHeader = new System.Windows.Forms.PictureBox();
            this.lblMsg = new System.Windows.Forms.Label();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.picUsername = new System.Windows.Forms.PictureBox();
            this.pnlPwd = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.picPwd = new System.Windows.Forms.PictureBox();
            this.chkRemember = new System.Windows.Forms.CheckBox();
            this.llblForget = new System.Windows.Forms.LinkLabel();
            this.lblLogin = new UI.AdvancedLabel();
            this.bgwLogin = new System.ComponentModel.BackgroundWorker();
            this.picPwdErr = new System.Windows.Forms.PictureBox();
            this.picUsernameErr = new System.Windows.Forms.PictureBox();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).BeginInit();
            this.pnlUsername.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).BeginInit();
            this.pnlPwd.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPwd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPwdErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsernameErr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            resources.ApplyResources(this.pnlHeader, "pnlHeader");
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.btnCloseLogin);
            this.pnlHeader.Controls.Add(this.picHeader);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DoLoginFormMouseDown);
            this.pnlHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DoLoginFormMouseMove);
            // 
            // btnCloseLogin
            // 
            resources.ApplyResources(this.btnCloseLogin, "btnCloseLogin");
            this.btnCloseLogin.Image = global::UI.Properties.Resources.ICN_CloseLogin_15x15_png;
            this.btnCloseLogin.Name = "btnCloseLogin";
            this.btnCloseLogin.TabStop = false;
            this.btnCloseLogin.Click += new System.EventHandler(this.DoCloseLoginFormOnClick);
            // 
            // picHeader
            // 
            resources.ApplyResources(this.picHeader, "picHeader");
            this.picHeader.BackColor = System.Drawing.Color.White;
            this.picHeader.Image = global::UI.Properties.Resources.LOGO_Client_Title_120x20;
            this.picHeader.Name = "picHeader";
            this.picHeader.TabStop = false;
            // 
            // lblMsg
            // 
            resources.ApplyResources(this.lblMsg, "lblMsg");
            this.lblMsg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(203)))), ((int)(((byte)(155)))));
            this.lblMsg.ForeColor = System.Drawing.Color.Red;
            this.lblMsg.Name = "lblMsg";
            // 
            // pnlUsername
            // 
            resources.ApplyResources(this.pnlUsername, "pnlUsername");
            this.pnlUsername.BackColor = System.Drawing.Color.White;
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Controls.Add(this.picUsername);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Click += new System.EventHandler(this.DoTxTUserFocus);
            // 
            // txtUsername
            // 
            resources.ApplyResources(this.txtUsername, "txtUsername");
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Enter += new System.EventHandler(this.DoTxTUserEnter);
            this.txtUsername.Leave += new System.EventHandler(this.DoTxtUserLeave);
            // 
            // picUsername
            // 
            resources.ApplyResources(this.picUsername, "picUsername");
            this.picUsername.BackColor = System.Drawing.Color.White;
            this.picUsername.Image = global::UI.Properties.Resources.ICN_Usename_20x20_png;
            this.picUsername.Name = "picUsername";
            this.picUsername.TabStop = false;
            this.picUsername.Click += new System.EventHandler(this.DoTxTUserFocus);
            // 
            // pnlPwd
            // 
            resources.ApplyResources(this.pnlPwd, "pnlPwd");
            this.pnlPwd.BackColor = System.Drawing.Color.White;
            this.pnlPwd.Controls.Add(this.txtPassword);
            this.pnlPwd.Controls.Add(this.picPwd);
            this.pnlPwd.Name = "pnlPwd";
            this.pnlPwd.Click += new System.EventHandler(this.DoTxTUserFocus);
            // 
            // txtPassword
            // 
            resources.ApplyResources(this.txtPassword, "txtPassword");
            this.txtPassword.BackColor = System.Drawing.Color.White;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(157)))), ((int)(((byte)(157)))));
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Enter += new System.EventHandler(this.DoTxTUserEnter);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoTxtPasswordOnKeyDown);
            this.txtPassword.Leave += new System.EventHandler(this.DoTxtUserLeave);
            // 
            // picPwd
            // 
            resources.ApplyResources(this.picPwd, "picPwd");
            this.picPwd.BackColor = System.Drawing.Color.White;
            this.picPwd.Image = global::UI.Properties.Resources.ICN_Password_20x15_png;
            this.picPwd.Name = "picPwd";
            this.picPwd.TabStop = false;
            this.picPwd.Click += new System.EventHandler(this.DoTxTUserFocus);
            // 
            // chkRemember
            // 
            resources.ApplyResources(this.chkRemember, "chkRemember");
            this.chkRemember.ForeColor = System.Drawing.Color.White;
            this.chkRemember.Name = "chkRemember";
            this.chkRemember.UseVisualStyleBackColor = true;
            // 
            // llblForget
            // 
            resources.ApplyResources(this.llblForget, "llblForget");
            this.llblForget.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.llblForget.LinkColor = System.Drawing.Color.White;
            this.llblForget.Name = "llblForget";
            this.llblForget.TabStop = true;
            // 
            // lblLogin
            // 
            resources.ApplyResources(this.lblLogin, "lblLogin");
            this.lblLogin.BorderColor = System.Drawing.Color.Empty;
            this.lblLogin.BorderSize = 0F;
            this.lblLogin.DefaultBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.lblLogin.DefaultFont = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLogin.DefaultFontColor = System.Drawing.Color.White;
            this.lblLogin.ForeColor = System.Drawing.Color.White;
            this.lblLogin.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(153)))), ((int)(((byte)(1)))));
            this.lblLogin.MouseDownFont = new System.Drawing.Font("Arial", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.lblLogin.MouseDownFontColor = System.Drawing.Color.White;
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Radius = 5F;
            this.lblLogin.Click += new System.EventHandler(this.DoBtnLoginOnClick);
            this.lblLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DoTxtPasswordOnKeyDown);
            // 
            // bgwLogin
            // 
            this.bgwLogin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DoBgwLoginDoWork);
            this.bgwLogin.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.DoBgwLoginRunWorkerCompleted);
            // 
            // picPwdErr
            // 
            resources.ApplyResources(this.picPwdErr, "picPwdErr");
            this.picPwdErr.Image = global::UI.Properties.Resources.ICN_Client_Login_Wrong_20X20;
            this.picPwdErr.Name = "picPwdErr";
            this.picPwdErr.TabStop = false;
            // 
            // picUsernameErr
            // 
            resources.ApplyResources(this.picUsernameErr, "picUsernameErr");
            this.picUsernameErr.Image = global::UI.Properties.Resources.ICN_Client_Login_Wrong_20X20;
            this.picUsernameErr.Name = "picUsernameErr";
            this.picUsernameErr.TabStop = false;
            // 
            // picLogo
            // 
            resources.ApplyResources(this.picLogo, "picLogo");
            this.picLogo.Image = global::UI.Properties.Resources.LOGO_Client_Login_40X300;
            this.picLogo.Name = "picLogo";
            this.picLogo.TabStop = false;
            // 
            // FormLogin
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(67)))), ((int)(((byte)(88)))));
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.picPwdErr);
            this.Controls.Add(this.picUsernameErr);
            this.Controls.Add(this.llblForget);
            this.Controls.Add(this.chkRemember);
            this.Controls.Add(this.pnlPwd);
            this.Controls.Add(this.pnlUsername);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.picLogo);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.pnlHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnCloseLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHeader)).EndInit();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUsername)).EndInit();
            this.pnlPwd.ResumeLayout(false);
            this.pnlPwd.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPwd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPwdErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picUsernameErr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.PictureBox picHeader;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.PictureBox picUsername;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.Panel pnlPwd;
        private System.Windows.Forms.PictureBox picPwd;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.CheckBox chkRemember;
        private System.Windows.Forms.LinkLabel llblForget;
        private System.Windows.Forms.PictureBox picUsernameErr;
        private System.Windows.Forms.PictureBox picPwdErr;
        private System.Windows.Forms.PictureBox btnCloseLogin;
        private AdvancedLabel lblLogin;
        private System.ComponentModel.BackgroundWorker bgwLogin;
    }
}

