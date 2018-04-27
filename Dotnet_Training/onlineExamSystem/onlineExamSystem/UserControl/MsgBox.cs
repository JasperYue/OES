using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Common;

namespace UI
{
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }

        delegate void RadiusHanlder(object sender, PaintEventArgs e);

        private void DoCloseWindow(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void DoMsgBoxOnPaint(object sender, PaintEventArgs e)
        {
            BaseForm baseForm = new BaseForm();
            RadiusHanlder drawRadius = new RadiusHanlder(baseForm.ResetRoundRect);
            drawRadius(sender, e);
        }

        private void DoMsgBoxOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DoCloseWindow(this, e);
            }
        }
    }
}
