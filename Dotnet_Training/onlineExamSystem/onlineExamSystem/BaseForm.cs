using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UI.Properties;
using System.Drawing.Drawing2D;
using Common;
using UI.ExamService;

namespace UI
{
    public partial class BaseForm : Form
    {
        private Point mPoint = new Point();
        protected PassPageParams request = new PassPageParams()
        {
            PageNo = 1,
            PageSize = 10
        };

        private int MaxPage { get; set; }

        private Image pageLeft = Resources.BTN_PageLeft_20x15_png;
        private Image pageRight = Resources.BTN_PageRight_20x15_png;
        protected Font defaultFont = new Font("Arial", 14, FontStyle.Regular, GraphicsUnit.Pixel);
        protected AutoScale autoScale = new AutoScale();

        #region Initial List And Dictionary
        private List<char> charList = new List<char>()
        {
            Constants.SIGN_SUB_LINE,
            Constants.SIGN_PERCENT
        };

        private Dictionary<string, Color> colorMapping = new Dictionary<string, Color>()
        {
            {"BLACK", Constants.COLOR_BLACK},
            {"ORANGE", Constants.COLOR_ORANGE},
            {"RED", Constants.COLOR_RED},
            {"BLUE", Constants.COLOR_BLUE_BORDER}
        };

        protected Dictionary<string, string> orderMapping = new Dictionary<string, string>()
        {
            {"picAttendance", "u.[name] "},
            {"picScore", "s.[score] "},
            {"picName", "[name] "},
            {"picNum", "[num] "},
            {"picTime", "[effective_time] "},
            {"picAverage", "[average_score] "},
            {"picPassRate", "[qualified_num]/cast([examinee_count] as float) "},
            {"picPass", "[pass_criteria] "},
            {"picOperation", "s.[score]/e.[pass_criteria] "}
        };
        #endregion

        public BaseForm()
        {
            InitializeComponent();

            cboPageSize.TextChanged += new EventHandler(DoPageSizeOnTextChanged);
            txtPageNo.KeyDown += new KeyEventHandler(DoTxtPageNoOnKeyDown);
        }
        /// <summary>
        /// Get current conditions Max page
        /// </summary>
        private void GetMaxPage(int totalItem, int pageSize)
        {
            MaxPage = totalItem % pageSize == 0 ? totalItem / pageSize
                                             : totalItem / pageSize + 1;
        }
        /// <summary>
        /// Get current pagination list
        /// </summary>
        private List<int> GetPagination(PassPageParams request, int totalItem)
        {
            List<int> paginationList = new List<int>();
            GetMaxPage(totalItem, request.PageSize);

            if (MaxPage <= 5)
            {
                for (int i = 1; i <= MaxPage; i++)
                {
                    paginationList.Add(i);
                }
            }
            else
            {
                if (request.PageNo - 1 > 2 && MaxPage - request.PageNo <= 2)
                {
                    paginationList.Add(1);
                    paginationList.Add(-1);
                    for (int i = MaxPage - 2; i <= MaxPage; i++)
                    {
                        paginationList.Add(i);
                    }
                }
                else if (MaxPage - request.PageNo > 2 && request.PageNo - 1 <= 2)
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        paginationList.Add(i);
                    }
                    paginationList.Add(-1);
                    paginationList.Add(MaxPage);
                }
                else if (request.PageNo - 1 >= 3 && MaxPage - request.PageNo >= 3)
                {
                    paginationList.Add(1);
                    paginationList.Add(-1);
                    if (request.PageNo <= 5)
                    {
                        for (int i = request.PageNo; i <= request.PageNo + 4; i++)
                        {
                            paginationList.Add(i);
                        }
                    }
                    else if (request.PageNo >= MaxPage - 4)
                    {
                        if (MaxPage - 7 <= 3)
                        {
                            for (int i = 4; i <= MaxPage - 3; i++)
                            {
                                paginationList.Add(i);
                            }
                        }
                        else
                        {
                            for (int i = MaxPage - 7; i <= MaxPage - 3; i++)
                            {
                                paginationList.Add(i);
                            }
                        }
                    }
                    else
                    {
                        for (int i = request.PageNo - 2; i <= request.PageNo + 2; i++)
                        {
                            paginationList.Add(i);
                        }
                    }
                    paginationList.Add(-1);
                    paginationList.Add(MaxPage);
                }
            }
            return paginationList;
        }
        /// <summary>
        /// Virtual method support sub class to override
        /// Function : Load current window main list data from DB
        /// </summary>
        protected virtual void ShowDgvList()
        {

        }

        #region pagination tool bar
        /// <summary>
        /// Generate Pagination Label
        /// </summary>
        private Label GetLabel(string text, bool isCurrent, int i)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Width = 30;
            label.Height = 15;
            label.Text = text;
            label.ForeColor = isCurrent ? Color.FromArgb(254, 153, 1) : Color.FromArgb(94, 94, 94);
            label.Cursor = Cursors.Hand;
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Location = new Point(30 + 30 * i, 0);
            return label;
        }
        /// <summary>
        /// Generate Pagination PicBox
        /// </summary>
        private PictureBox GetPicBox(string picName, Image image)
        {
            PictureBox pic = new PictureBox();
            pic.Name = picName;
            pic.Width = 20;
            pic.Height = 15;
            pic.Image = image;
            pic.Cursor = Cursors.Hand;
            return pic;
        }
        /// <summary>
        /// Reload data when click page number, only valid number can be transport to backend
        /// </summary>
        private void DoPageNoOnClick(object sender, EventArgs e)
        {
            int pageNo = 1;
            if (int.TryParse((sender as Label).Text, out pageNo))
            {
                request.PageNo = pageNo;
            }
            ShowDgvList();
        }
        /// <summary>
        /// Reload data when click prev pic, only valid number can be transport to backend
        /// </summary>
        private void DoPicPrePageOnClick(object sender, EventArgs e)
        {
            if (ApplicationUtil.IsSameImage((sender as PictureBox).Image, pageLeft) && request.PageNo > 1)
            {
                request.PageNo -= 1;
                ShowDgvList();
            }
        }
        /// <summary>
        /// Reload data when click next pic, only valid number can be transport to backend
        /// </summary>
        private void DoPicNextPageOnClick(object sender, EventArgs e)
        {
            if (ApplicationUtil.IsSameImage((sender as PictureBox).Image, pageRight) && request.PageNo < MaxPage)
            {
                request.PageNo += 1;
                ShowDgvList();
            }
        }
        /// <summary>
        /// Reload data when click comboBox, only valid number can be transport to backend
        /// </summary>
        protected void DoPageSizeOnTextChanged(object sender, EventArgs e)
        {
            request.PageSize = Convert.ToInt32((sender as ComboBox).Text);
            request.PageNo = 1;
            ShowDgvList();
        }
        /// <summary>
        /// Jump page when user input a pageNo, only valid number can be transport to backend
        /// </summary>
        protected void DoLblGoOnClick(object sender, EventArgs e)
        {
            string pageNoStr = txtPageNo.Text;
            int pageNo = 1;
            if (int.TryParse(pageNoStr, out pageNo) && pageNo > 0)// Validate pageNo is valid
            {
                request.PageNo = pageNo > MaxPage ? MaxPage : pageNo;
                ShowDgvList();
            }
            else
            {
                ShowMsgBox(Res.INPUT_NOT_NUM);
                txtPageNo.Clear();
            }
        }
        /// <summary>
        /// Enter to invoke "GO" method
        /// </summary>
        protected void DoTxtPageNoOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoLblGoOnClick(sender, e);
            }
        }
        /// <summary>
        /// Do loop to add paginationList dynamicly to panel
        /// </summary>
        private void AddPaginationList(int totalItem)
        {
            pnlPageBar.Controls.Clear();

            List<int> list = GetPagination(request, totalItem);
            int size = list.Count;

            pnlPageBar.Width = 60 + size * 30;
            pnlPageBar.Location = new Point(cboPageSize.Location.X - 10 - pnlPageBar.Width, 550);

            PictureBox picPrevPage = GetPicBox("picPrevPage", pageLeft);
            picPrevPage.Click += new EventHandler(DoPicPrePageOnClick);
            picPrevPage.Location = new Point(0, 0);
            pnlPageBar.Controls.Add(picPrevPage);

            for (int i = 0; i < list.Count; i++)
            {
                int pageNo = list[i];
                string text = pageNo != -1 ? pageNo.ToString() : "...";
                Label label = pageNo == request.PageNo ? GetLabel(text, true, i) : GetLabel(text, false, i);
                if (!"...".Equals(text))
                {
                    label.Click += new EventHandler(DoPageNoOnClick);
                }
                pnlPageBar.Controls.Add(label);
            }

            PictureBox picNextPage = GetPicBox("picNextPage", pageRight);
            picNextPage.Click += new EventHandler(DoPicNextPageOnClick);
            picNextPage.Location = new Point(pnlPageBar.Width - 20, 0);
            pnlPageBar.Controls.Add(picNextPage);
        }
        /// <summary>
        /// Show pagination(Add control to current panel)
        /// </summary>
        protected void ShowPagination(Panel pnlPage, int totalItem)
        {
            AddPaginationList(totalItem);

            pnlPage.Controls.Add(this.pnlPageBar);
            pnlPage.Controls.Add(this.lblGo);
            pnlPage.Controls.Add(this.txtPageNo);
            pnlPage.Controls.Add(this.lblPerPage);
            pnlPage.Controls.Add(this.cboPageSize);
        }
        #endregion
        
        /// <summary>
        /// Student and Teacher Jump to sub window
        /// </summary>
        protected void Jump2WindowOnce(Form currentForm, Form targetForm)
        {
            currentForm.Visible = false;
            targetForm.WindowState = currentForm.WindowState;
            DialogResult result = targetForm.ShowDialog();

            if (result == DialogResult.Cancel)
            {
                currentForm.Visible = true;
                if (currentForm.Name.Equals("FormStudent"))
                {
                    ShowDgvList();
                }
            }
        }
        /// <summary>
        /// Show MessageBox
        /// </summary>
        protected void ShowMsgBox(string text)
        {
            MsgBox msgBox = new MsgBox();
            msgBox.lblMsg.Text = text;
            DialogResult result = msgBox.ShowDialog();
        }

        #region Get Name Fuzzy Search Condition
        /// <summary>
        /// Get name condition
        /// </summary>
        protected string GetSearchCondition(Control control)
        {
            string nameLike = control.Text.Trim();

            // Not Null 
            if (!IsEmpty(nameLike))
            {
                // _ %
                foreach (char ch in charList)
                {
                    if (nameLike.Contains(ch + string.Empty))
                    {
                        string temp = string.Empty;
                        string[] nameArr = nameLike.Split(ch);
                        for (int i = 0; i < nameArr.Length; i++)
                        {
                            temp += i == 1 ? nameArr[i] : "[" + ch + "]" + nameArr[i];
                        }
                        nameLike = temp;
                    }
                }

                // '
                List<int> chList = new List<int>();
                char[] charArr = nameLike.ToCharArray();
                for (int i = 0; i < charArr.Length; i++)
                {
                    if (charArr[i].Equals('\''))
                    {
                        chList.Add(i);
                    }
                }

                if (chList.Count != 0)
                {
                    StringBuilder sb = new StringBuilder(nameLike);
                    int offset = 0;
                    foreach (int index in chList)
                    {
                        sb.Insert(index + offset, "'");
                    }
                    nameLike = sb.ToString();
                }

                nameLike = "%" + nameLike + "%";
            }
            else
            {
                nameLike = "%%";
            }

            return string.Format("[name] LIKE '{0}' ", nameLike);
        }
        /// <summary>
        /// Whether name field is empty
        /// </summary>
        protected bool IsEmpty(string nameLike)
        {
            bool flag = false;
            if (nameLike.Equals(Res.txtName_Text) || string.IsNullOrEmpty(nameLike))
            {
                flag = true;
            }
            return flag;
        }
        #endregion

        #region Order
        protected void GetPageWhenOrder(object sender, Control control, PassPageParams page)
        {
            // Get current order picbox
            PictureBox picBox = GetPicBoxOrderClicked(sender, control);
            page.PageNo = 1;
            // Get current order condition
            page.Sort = GetSort(picBox, orderMapping[picBox.Name]);
            // Reload list
            ShowDgvList();
        }
        /// <summary>
        /// Get pic user checked
        /// </summary>
        protected PictureBox GetPicBoxOrderClicked(object sender, Control container)
        {

            PictureBox picBox = null;
            if (sender is Label)
            {
                foreach (Control control in container.Controls)
                {
                    if (control.Name.Equals((sender as Label).Tag.ToString()))
                    {
                        picBox = control as PictureBox;
                    }
                    else if (control is PictureBox)
                    {
                        control.Visible = false;
                    }
                }
            }
            else if (sender is PictureBox)
            {
                picBox = sender as PictureBox;
            }

            picBox.Visible = true;

            return picBox;
        }
       /// <summary>
       /// get sort condition
       /// </summary>
        protected string GetSort(PictureBox picBox, string sort)
        {
            if (ApplicationUtil.IsSameImage(picBox.Image, Resources.ICN_Decrese_10x15_png))
            {
                sort += "ASC ";
                picBox.Image = Resources.ICN_Increase_10x15_png;
            }
            else
            {
                sort += "DESC ";
                picBox.Image = Resources.ICN_Decrese_10x15_png;
            }
            return sort;
        }
        #endregion

        protected void SetBackColor(Control control, Color backColor, Color foreColor)
        {
            control.BackColor = backColor;
            control.ForeColor = foreColor;
        }

        protected void SetVisibility(Control prevPanel, Control nextPanel)
        {
            prevPanel.Visible = true;
            nextPanel.Visible = false;
        }

        #region Title tool bar
        private void DoPicMinOnClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        /// <summary>
        /// Maximized or Normal window
        /// </summary>
        protected virtual void DopicMaxOnClick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else
            {
                WindowState = FormWindowState.Maximized;
            }
        }
        /// <summary>
        /// virtual method support sub class to override and implement close window customly
        /// </summary>
        protected virtual void DoPicCloseOnClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region Round Rect
        public void ResetRoundRect(object sender, PaintEventArgs e)
        {
            Control control = sender as Control;
            DrawRoundRect(e.Graphics, control, colorMapping[control.Tag.ToString()]);
        }

        protected void DrawRoundRect(Graphics graphics, Control control, Color borderColor)
        {
            float X = float.Parse(control.Width.ToString()) - 1;
            float Y = float.Parse(control.Height.ToString()) - 1;
            PointF[] points = { new PointF(2, 0), new PointF(X - 2, 0), new PointF(X - 1, 1), new PointF(X, 2), new PointF(X, Y - 2), new PointF(X - 1, Y - 1), new PointF(X - 2, Y), new PointF(2, Y), new PointF(1, Y - 1), new PointF(0, Y - 2), new PointF(0, 2), new PointF(1, 1) };
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);
            Pen pen = new Pen(borderColor, 1);
            pen.DashStyle = DashStyle.Solid;
            graphics.DrawPath(pen, path);
        }
        #endregion

        #region PlaceHolder
        protected void DoTxTNameLeave(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(txtBox.Text))
            {
                txtBox.Text = Res.txtName_Text;
                txtBox.ForeColor = Color.FromArgb(94, 94, 94);
            }
        }

        protected void DoTxTNameEnter(object sender, EventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            if (txtBox.ForeColor == Color.FromArgb(94, 94, 94))
            {
                txtBox.Text = string.Empty;
                txtBox.ForeColor = Constants.COLOR_BLACK;
            }
        }
        #endregion

        #region Drag window
        private void DoFormMouseDown(object sender, MouseEventArgs e)
        {
            mPoint.X = e.X;
            mPoint.Y = e.Y;
        }

        private void DoFormMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point myPosittion = MousePosition;
                myPosittion.Offset(-mPoint.X, -mPoint.Y);
                Location = myPosittion;
            }
        }
        #endregion

    }
}
