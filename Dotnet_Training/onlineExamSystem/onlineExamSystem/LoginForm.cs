using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using Common;
using CustomException;
using log4net;
using UI.UserService;

namespace UI
{
    public partial class FormLogin : Form
    {
        private UserServiceClient userService = new UserServiceClient();
        private Point mPoint = new Point();
        private ILog log = LogManager.GetLogger(Constants.LOGGER);

        public FormLogin()
        {
            InitializeComponent();
            HandleRememberMe();
        }

        #region Handle placeHolder style and description
        /// <summary>
        /// Click nearly location of textbox and auto focus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DoTxTUserFocus(object sender, EventArgs e)
        {
            Panel panel = sender is PictureBox ? ((sender as PictureBox).Parent as Panel)
                                               : sender as Panel;
            foreach (Control control in panel.Controls)
            {
                if (control is TextBox)
                {
                    control.Focus();
                }
            }
        }

        private void DoTxTUserEnter(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Name.EndsWith(Constants.USER_NAME) && txtBox.ForeColor == Constants.COLOR_GREY)
            {
                txtBox.Text = string.Empty;
                txtBox.ForeColor = Constants.COLOR_BLACK;
            }
            else if (txtBox.Name.EndsWith(Constants.PASSWORD) && txtBox.ForeColor == Constants.COLOR_GREY)
            {
                txtBox.Text = string.Empty;
                txtBox.PasswordChar = Constants.SIGN_CIRCLE;
                txtBox.ForeColor = Constants.COLOR_BLACK;
            }
        }
        
        private void DoTxtUserLeave(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.Name.EndsWith(Constants.USER_NAME) && string.IsNullOrWhiteSpace(txtBox.Text))
            {

                txtBox.Text = Res.txtUsername_Text;
                txtBox.ForeColor = Constants.COLOR_GREY;
            }
            else if (txtBox.Name.EndsWith(Constants.PASSWORD) && string.IsNullOrWhiteSpace(txtBox.Text))
            {
                txtBox.Text = Res.txtPassword_Text;
                txtBox.PasswordChar = new char();
                txtBox.ForeColor = Constants.COLOR_GREY;
            }
        }
        #endregion

        #region Validate Data
        private void DoTxTUserNameValidating(CancelEventArgs e, string userName)
        {
            if (string.IsNullOrWhiteSpace(userName) || txtUsername.ForeColor == Constants.COLOR_GREY)
            {
                SetVisibilityAndMsg(picUsernameErr, true, null, null);
                e.Cancel = true;
            }
            else
            {
                SetVisibilityAndMsg(picUsernameErr, false, null, null);
            }
        }

        private void DoTxTPasswordValidating(CancelEventArgs e, string password)
        {
            if (string.IsNullOrWhiteSpace(password) || txtPassword.ForeColor == Constants.COLOR_GREY)
            {
                SetVisibilityAndMsg(picPwdErr, true, null, null);
                e.Cancel = true;
            }
            else
            {
                SetVisibilityAndMsg(picPwdErr, false, null, null);
            }
        }
        private void SetVisibilityAndMsg(Control visibleControl, bool visible, Control msgControl, string msg)
        {
            visibleControl.Visible = visible;
            if (msgControl != null)
            {
                msgControl.Text = msg;
            }
        }
        #endregion

        #region Login
        /// <summary>
        /// Whether password is encrypted
        /// </summary>
        private bool IsEncrypted(string password)
        {
            bool flag = false;
            if (File.Exists(ApplicationUtil.BIN_DIR + Constants.XML_FILE_USER))
            {
                try
                {
                    User user = null;
                    ReadUserXml(ref user);
                    if (user != null && user.Password.Equals(password))
                    {
                        flag = true;
                    }
                }
                catch (Exception ex)
                {
                    string msg = string.Empty;
                    ExceptionHandler.ReturnErrMsg(ex, out msg);
                }
            }
            return flag;
        }
        /// <summary>
        /// User click button to login system
        /// </summary>
        private void DoBtnLoginOnClick(object sender, EventArgs e)
        {
            if (!bgwLogin.IsBusy)
            {
                // Validate data from frontend
                string userName = txtUsername.Text;
                string password = txtPassword.Text;
                CancelEventArgs cancelEventArgs = new CancelEventArgs();
                DoTxTUserNameValidating(cancelEventArgs, userName);
                DoTxTPasswordValidating(cancelEventArgs, password);

                if (cancelEventArgs.Cancel == false)
                {
                    SetVisibilityAndMsg(picUsernameErr, false, null, null);
                    SetVisibilityAndMsg(picPwdErr, false, null, null);
                    bgwLogin.RunWorkerAsync();
                }
                else
                {
                    SetVisibilityAndMsg(lblMsg, true, lblMsg, Res.INPUT_NOT_EMPTY);
                }
            }
        }
        /// <summary>
        /// Login system backgroundworker to get User info from DB
        /// </summary>
        private void DoBgwLoginDoWork(object sender, DoWorkEventArgs e)
        {
            string userName = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (!IsEncrypted(password))
            {
                password = ApplicationUtil.Md5(password);
            }

            try
            {
                User user = userService.VerifyUserLogOn(userName, password);

                if (chkRemember.Checked)
                {
                    WriteUser2Xml(user);
                }
                else if (File.Exists(ApplicationUtil.BIN_DIR + Constants.XML_FILE_USER))
                {
                    File.Delete(ApplicationUtil.BIN_DIR + Constants.XML_FILE_USER);// If exist, then delete
                }

                Program.user = user;
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }
        /// <summary>
        /// Login system UI performance
        /// </summary>
        private void DoBgwLoginRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                User user = Program.user;

                SetVisibilityAndMsg(lblMsg, false, lblMsg, string.Empty);

                if (user.RoleName.Equals(Role.Student.ToString()))
                {
                    FormStudent formStudent = new FormStudent();
                    formStudent.Show();
                }
                else if (user.RoleName.Equals(Role.Teacher.ToString()))
                {
                    FormTeacher formTeacher = new FormTeacher();
                    formTeacher.lblTabUser.Width = MeasureTextWidth(user.Name) + 30;
                    formTeacher.lblTabUser.Location = new Point(formTeacher.llblChinese.Location.X - 15 - formTeacher.lblTabUser.Width, formTeacher.lblTabUser.Location.Y);
                    formTeacher.Show();
                    formTeacher.cboPageSize.SelectedIndex = 1;
                }

                log.Info(user.Name + "[" + user.Id + "] Logon system at " + DateTime.Now);

                this.Hide();
            }
            else
            {
                Exception ex = e.Result as Exception;

                string msg = string.Empty;
                ExceptionHandler.ReturnErrMsg(ex, out msg);
                SetVisibilityAndMsg(lblMsg, true, lblMsg, Res.ResourceManager.GetString(msg));
                if (msg.Equals(Constants.USER_NOT_EXIST))
                {
                    picUsernameErr.Visible = true;
                }
                else if (msg.Equals(Constants.PASSWORD_NOT_CORRENT))
                {
                    picPwdErr.Visible = true;
                }
            }
        }
        #endregion

        /// <summary>
        /// Enter to Login
        /// </summary>
        private void DoTxtPasswordOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoBtnLoginOnClick(lblLogin, new EventArgs());
            }
        }
        /// <summary>
        /// Close application
        /// </summary>
        private void DoCloseLoginFormOnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region XML
        /// <summary>
        /// Remember me and write all information into xml file
        /// </summary>
        public void HandleRememberMe()
        {
            if (File.Exists(ApplicationUtil.BIN_DIR + Constants.XML_FILE_USER))
            {
                try
                {
                    User user = null;
                    ReadUserXml(ref user);
                    if (user != null)
                    {
                        txtUsername.Text = user.Name;
                        txtUsername.ForeColor = Constants.COLOR_BLACK;
                        txtPassword.PasswordChar = Constants.SIGN_CIRCLE;
                        txtPassword.ForeColor = Constants.COLOR_BLACK;
                        txtPassword.Text = user.Password;
                        chkRemember.Checked = true;
                    }
                }
                catch (Exception ex) // Only can raise FileNotLoadSuccessFully Exception
                {
                    string msg = string.Empty;
                    ExceptionHandler.ReturnErrMsg(ex, out msg);
                }
            }
        }
        /// <summary>
        /// Create Xml document node
        /// </summary>
        public void CreateNode(XmlDocument xmlDoc, XmlNode parentNode, string name, string value)
        {
            XmlNode node = xmlDoc.CreateNode(XmlNodeType.Element, name, null);
            node.InnerText = value;
            parentNode.AppendChild(node);
        }
        /// <summary>
        /// Write user info into Xml
        /// </summary>
        public void WriteUser2Xml(User user)
        {
            if (user != null)
            {
                XmlDocument xmlDoc = new XmlDocument();
                XmlNode node = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", "");
                xmlDoc.AppendChild(node);
                XmlNode root = xmlDoc.CreateElement(Constants.ENTITY_USER);
                xmlDoc.AppendChild(root);

                CreateNode(xmlDoc, root, Constants.XML_ID, user.Id.ToString());
                CreateNode(xmlDoc, root, Constants.USER_NAME, user.Name);
                CreateNode(xmlDoc, root, Constants.PASSWORD, user.Password);

                xmlDoc.Save(ApplicationUtil.BIN_DIR + Constants.XML_FILE_USER);
            }
        }
        /// <summary>
        /// Read user info from Xml
        /// </summary>
        public void ReadUserXml(ref User user)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(ApplicationUtil.BIN_DIR + Constants.XML_FILE_USER);
            XmlNode root = xmlDoc.SelectSingleNode(Constants.ENTITY_USER);
            if (root != null && root.ChildNodes.Count == 3)
            {
                if (root.SelectSingleNode(Constants.XML_ID) != null &&
                    root.SelectSingleNode(Constants.USER_NAME) != null &&
                    root.SelectSingleNode(Constants.PASSWORD) != null)
                {
                    if (user == null)
                    {
                        user = new User();
                    }

                    int id;
                    if (int.TryParse(root.SelectSingleNode(Constants.XML_ID).InnerText, out id))
                    {
                        user.Id = id;
                    }
                    user.Name = root.SelectSingleNode(Constants.USER_NAME).InnerText;
                    user.Password = root.SelectSingleNode(Constants.PASSWORD).InnerText;
                }
            }
        }
        #endregion

        #region Drag window
        private void DoLoginFormMouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void DoLoginFormMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }
        #endregion

        /// <summary>
        /// Caculate text take how many pixel
        /// </summary>
        private int MeasureTextWidth(string text)
        {
            Graphics graphics = CreateGraphics();
            SizeF sizeF = graphics.MeasureString(text, new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Pixel));
            graphics.Dispose();
            return (int)sizeF.Width;
        }
    }
}
