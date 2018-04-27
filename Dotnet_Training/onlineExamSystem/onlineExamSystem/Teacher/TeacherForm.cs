using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Common;
using UI.Properties;
using System.Text;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Data;
using CustomException;
using UI.ExamService;
using System.IO;
using System.Drawing.Drawing2D;
using UI.UserService;
using UI.FileService;
using System.Threading;

namespace UI
{
    public partial class FormTeacher : BaseForm
    {
        private ExamServiceClient examService = new ExamServiceClient();
        private FileServiceClient fileService = new FileServiceClient();

        private Action<int> processUpdate;

        delegate void DataTransportHandler(int id);

        private ReturnParamsOfExamResultYgFqSxnr response;

        public FormTeacher()
        {
            InitializeComponent();

            lblTabUser.Text = Program.user.Name;
            //cboPageSize.SelectedIndex = 1;

            txtName.Enter += new EventHandler(DoTxTNameEnter);
            txtName.Leave += new EventHandler(DoTxTNameLeave);
            // Lambda expression to set label text
            processUpdate = (percentage) => { lblTipMsg.Text = percentage + "%"; };
        }

        #region ShowDgvList
        /// <summary>
        /// Find ExamList info from DB by using background worker
        /// </summary>
        private void DoDgwExamListRunWorkerDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                response = examService.FindPaperListByCount(request);
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }
        /// <summary>
        /// UI performance after find data from DB
        /// </summary>
        private void DoDgwExamListRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
            {
                dgvPaperList.DataSource = response.Result;
                ShowPagination(pnlPaper, response.TotalItem);

                dgvPaperList.ClearSelection();
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
                if (conditions != null)
                {
                    request.StrWhere = conditions.Substring(0, conditions.IndexOf('%') + 1) + conditions.Substring(conditions.LastIndexOf('%'));
                }
            }
        }
        /// <summary>
        /// Load gridview data
        /// </summary>
        protected override void ShowDgvList()
        {
            if (!bgwExamList.IsBusy)
            {
                bgwExamList.RunWorkerAsync();
            }
        }
        #endregion

        /// <summary>
        /// To attendance page on column index is 2
        /// </summary>
        private void DoDgvPaperListOnCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                int rowIndex = e.RowIndex;
                int id;
                if (int.TryParse(dgvPaperList.Rows[rowIndex].Cells[1].Value.ToString(), out id))
                {
                    FormDetail formDetail = new FormDetail();
                    DataTransportHandler dtHandler = new DataTransportHandler(formDetail.ShowInfo);
                    dtHandler(id);

                    Jump2WindowOnce(this, formDetail);
                }
            }
        }

        #region FuzzySearch
        /// <summary>
        /// Click to search
        /// </summary>
        private void DoSearchOnClick(object sender, EventArgs e)
        {
            bool isTimeValid = DoTimerValidating();

            if (isTimeValid)
            {
                request.StrWhere = " AND " + GetSearchCondition(txtName) + " AND " + GetSearchTime(timerStart.Value.ToString(), timerEnd.Value.ToString());
                ShowDgvList();
            }
        }
        /// <summary>
        /// Validate time formatter when leave timePicker
        /// </summary>
        private void DoTimerCheckOnLeave(object sender, EventArgs e)
        {
            DoTimerValidating();
        }
        /// <summary>
        /// Validate time formatter
        /// </summary>
        private bool DoTimerValidating()
        {
            bool flag = true;
            DateTime timeStart = timerStart.Value;
            DateTime timeEnd = timerEnd.Value;
            if (DateTime.Compare(timeStart, timeEnd) > 0)
            {
                ShowMsgBox(Res.TIME_START_BEFORE_END);
                timerEnd.Text = Constants.DEFAULT_TIME_END;
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// Get time condition
        /// </summary>
        private string GetSearchTime(string timeStartStr, string timeEndStr)
        {
            return string.Format("[effective_time] BETWEEN '{0}' AND '{1}' ", timeStartStr, timeEndStr);
        }
        #endregion

        /// <summary>
        /// Enter to Fuzzy Search
        /// </summary>
        private void DoTxtBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoSearchOnClick(sender, e);
            }
        }

        /// <summary>
        /// Auto scale when click max button
        /// </summary>
        protected override void DopicMaxOnClick(object sender, EventArgs e)
        {
            autoScale.ControlAutoSize(this);
            base.DopicMaxOnClick(sender, e);
            autoScale.ControlAutoSize(this);
        }
        /// <summary>
        /// Application Exit
        /// </summary>
        protected override void DoPicCloseOnClick(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Log out
        /// </summary>
        private void DoLogoutOnClick(object sender, EventArgs e)
        {
            FormLogin formLogin = new FormLogin();
            formLogin.Show();

            this.Close();
        }
        /// <summary>
        /// Get list order by current conditions
        /// </summary>
        private void DoPicOrderOnClick(object sender, EventArgs e)
        {
            GetPageWhenOrder(sender, pnlOrderTitle, request);
        }

        #region Reset dgv style
        /// <summary>
        /// Remove default select (1, 1)
        /// </summary>
        private void DodgvPaperListRowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            e.PaintParts = e.PaintParts ^ DataGridViewPaintParts.Focus;
        }
        /// <summary>
        /// Refine UI performance
        /// </summary>
        private void DoDgvPaperListOnCellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
            e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
        }
        #endregion
        /// <summary>
        /// Toggle user info and exam list
        /// </summary>
        private void DoToggleTabOnClick(object sender, EventArgs e)
        {
            if ((sender as Control).Name.Equals("lblTabExamList"))
            {
                SetVisibility(pnlPaper, pnlUser);
                SetBackColor(lblTabUser, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
                SetBackColor(lblTabExamList, Constants.COLOR_HOME_GREY, Constants.COLOR_BLUE);
            }
            else
            {
                SetVisibility(pnlUser, pnlPaper);
                SetBackColor(lblTabExamList, Constants.COLOR_WHITE, Constants.COLOR_BLUE);
                SetBackColor(lblTabUser, Constants.COLOR_HOME_GREY, Constants.COLOR_BLUE);
                LoadUserInfomation();
            }
        }
        /// <summary>
        /// Load user infomation
        /// </summary>
        private void LoadUserInfomation()
        {
            User user = Program.user;
            lblUserName.Text = user.Name;
            lblWorkNum.Text = user.Id.ToString();

            picUpload.Image = null;
            lblTipUpload.Visible = true;
            lblUploadPic.Enabled = false;
            lblTipMsg.Text = string.Empty;

            string path = ApplicationUtil.IMAGE_DIR +  @"\" + user.ImgSrc;
            if (File.Exists(path))
            {
                picUserIcon.Image = ResizeImage(new Bitmap(FileToStream(path)), picUserIcon);
            }
            else if (!string.IsNullOrEmpty(user.ImgSrc) && !File.Exists(path))
            {
                Bitmap bitmap = fileService.GetUserIcon(user.Id);
                StreamToFile(BytesToStream(BitmapToBytes(bitmap)), path);
                picUserIcon.Image = ResizeImage(bitmap, picUserIcon);
            }
        }

        #region FileUpload
        /// <summary>
        /// Click Add button and open OpenFileDialog
        /// </summary>
        private void DoLOblAddPhotoOnClick(object sender, EventArgs e)
        {
            ofdPic.Filter = "(*.jpg,*.gif,*.bmp;*.png;)|*.jpg;*.gif;*.bmp*;.png;";
            if (DialogResult.OK.Equals(ofdPic.ShowDialog()))
            {
                string msg = string.Empty;
                Stream stream = FileToStream(ofdPic.FileName);
                Bitmap imgBitmap = null;
                try
                {
                    imgBitmap = new Bitmap(stream);
                }
                catch
                {
                    msg = "Not a picture!";
                }
                if (!stream.CanRead)
                {
                    msg = "Invalid File!";
                }
                else if (Convert.ToInt32(stream.Length) > 5 * 1024 * 1024)
                {
                    msg = string.Format("FileSize exceed, at most 5 M");
                }

                if (!string.IsNullOrWhiteSpace(msg))
                {
                    ShowMsgBox(Res.ResourceManager.GetString(msg));
                    ResetUpload();
                }
                else
                {
                    // Add photo and show it in picBox
                    picUpload.Image = ResizeImage(imgBitmap, picUpload);

                    lblTipMsg.Text = string.Empty;
                    lblTipUpload.Visible = false;
                    lblUploadPic.Enabled = true;
                }
            }
        }
        /// <summary>
        /// Reset default style
        /// </summary>
        private void ResetUpload()
        {
            lblTipMsg.Text = string.Empty;
            lblTipUpload.Visible = true;
            lblUploadPic.Enabled = false;
            lblAddPhoto.Enabled = true;
            picUpload.Image = null;
        }
        /// <summary>
        /// Upload file to server and get current progress
        /// </summary>
        private void DoBgwPicUploadDoWork(object sender, DoWorkEventArgs e)
        {
            // Pass 1: Save pic to local folder
            if (!Directory.Exists(ApplicationUtil.IMAGE_DIR))
            {
                Directory.CreateDirectory(ApplicationUtil.IMAGE_DIR);
            }

            Stream stream = FileToStream(ofdPic.FileName);

            string uniqueId = Guid.NewGuid().ToString();

            string path = ApplicationUtil.IMAGE_DIR + @"\" + uniqueId + "_" + ofdPic.SafeFileName;
            // Save file to local path
            StreamToFile(stream, path);

            // Pass 2: 
            FileUploadData uploadData = new FileUploadData()
            {
                FileData = stream,
                FileName = uniqueId + "_" + ofdPic.SafeFileName,
                FileSize = Convert.ToInt32(stream.Length),
                FileUniqueID = uniqueId,
                UserId = Program.user.Id
            };

            // Upload file to server path and save server relative path to server
            fileService.UploadFileAsync(uploadData.FileName, uploadData.FileSize, uploadData.FileUniqueID, uploadData.UserId, uploadData.FileData);

            var totalSize = uploadData.FileSize;

            var currProcess = fileService.GetUploadFileInfo(uploadData.FileUniqueID);

            bgwPicUpload.ReportProgress(currProcess * 100 / totalSize);
            // Get curreng progress by polling
            while (currProcess < totalSize)
            {
                // Report progress to BackgroundWorker and update UI performance
                bgwPicUpload.ReportProgress(currProcess * 100 / totalSize);

                currProcess = fileService.GetUploadFileInfo(uploadData.FileUniqueID);
            }
            // Finish upload file and refine label text to 100
            bgwPicUpload.ReportProgress(100);
        }

        /// <summary>
        /// Show current progress like progress bar
        /// </summary>
        private void DoBgwPicUploadOnProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            processUpdate(e.ProgressPercentage);
        }
        /// <summary>
        /// UI proformance after uploading file to server
        /// </summary>
        private void DoBgwPicUploadRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblUploadPic.Enabled = true;
            lblAddPhoto.Enabled = true;

            ShowMsgBox(Res.SET_USER_ICON_SUC);

            Program.user.ImgSrc = ofdPic.SafeFileName;

            // Add photo and show it in picBox
            string path = ApplicationUtil.IMAGE_DIR + @"\" + ofdPic.SafeFileName;
            picUserIcon.Image = ResizeImage(new Bitmap(FileToStream(path)), picUserIcon);
        }
        /// <summary>
        /// Click to run BackgroundWorker and upload file
        /// </summary>
        private void DoLblUploadPicOnClick(object sender, EventArgs e)
        {
            // Only image is a new picbox can server upload this pic
            if (!bgwPicUpload.IsBusy)
            {
                // Disabled button
                lblUploadPic.Enabled = false;
                lblAddPhoto.Enabled = false;

                bgwPicUpload.RunWorkerAsync();
            }
        }
        #endregion

        #region FileUpload Util
        /// <summary>
        /// Resize image according to given picture box
        /// </summary>
        private Bitmap ResizeImage(Bitmap bmp, PictureBox picBox)
        {
            float xRate = (float)bmp.Width / picBox.Size.Width;
            float yRate = (float)bmp.Height / picBox.Size.Height;
            if (xRate <= 1 && yRate <= 1)
            {
                return bmp;
            }
            else
            {
                Graphics g = null;
                try
                {
                    int newW = (int)(bmp.Width / xRate);
                    int newH = (int)(bmp.Height / yRate);
                    Bitmap b = new Bitmap(newW, newH);
                    g = Graphics.FromImage(b);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
                    g.Dispose();
                    return b;
                }
                catch
                {
                    return null;
                }
                finally
                {
                    if (null != g)
                    {
                        g.Dispose();
                    }
                }
            }
        }
        /// <summary>
        /// Read file to Stream
        /// </summary>
        public Stream FileToStream(string fileName)
        {
            // Open specific file
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            // Read file byte array
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            // Transfer array to stream
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
        /// <summary>
        /// Write stream to file, safe simple name
        /// </summary>
        public void StreamToFile(Stream stream, string fileName)
        {
            if (stream != null)
            {
                // Transfer stream to array
                byte[] bytes = new byte[stream.Length];
                stream.Read(bytes, 0, bytes.Length);
                // Start at the beginning of steam
                stream.Seek(0, SeekOrigin.Begin);
                // Write byte array to file
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    using (BinaryWriter bw = new BinaryWriter(fs))
                    {
                        bw.Write(bytes);
                    }
                }
            }
        }
        /// <summary>
        /// Convert Bitmap to Bytes
        /// </summary>
        public byte[] BitmapToBytes(Bitmap Bitmap)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                Bitmap.Save(ms, Bitmap.RawFormat);
                byte[] byteImage = new Byte[ms.Length];
                byteImage = ms.ToArray();
                return byteImage;
            }
        }
        /// <summary>
        /// Convert Bytes to Stream
        /// </summary>
        public Stream BytesToStream(byte[] bytes)
        {
            return new MemoryStream(bytes);
        }
        #endregion
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
            FormTeacher t = new FormTeacher();
            t.Show();
            cboPageSize.SelectedIndex = 1;
            this.Close();
        }

    }
}
