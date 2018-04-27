using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.VisualBasic.PowerPacks;
using System.Drawing;

namespace UI
{
    public class AutoScale
    {
        public struct controlRect
        {
            public int Left;
            public int Width;
        }

        // Container of control in this window
        public List<controlRect> oldCtrl = new List<controlRect>();
        int ctrlNo = 0;
        // Original width of window
        int width = 1024;
        // Record cboPageSize's location X
        int cboLeft;

        private void AddControl(Control ctl)
        {
            foreach (Control c in ctl.Controls)
            {
                controlRect objCtrl;
                objCtrl.Left = c.Left;
                objCtrl.Width = c.Width;
                oldCtrl.Add(objCtrl);
                // Add current control then sub control
                if (c.Controls.Count > 0 && !c.Name.Equals("pnlPageBar"))
                {
                    AddControl(c);// Recursion to add sub control of current super control
                }
            }
        }
        public void ControlAutoSize(Control mForm)
        {
            if (ctrlNo == 0)
            {
                controlRect cR;
                cR.Left = 0;
                cR.Width = mForm.Width;
                oldCtrl.Add(cR);// First is current window and only add once
                AddControl(mForm);// Recursion to add sub control of window. It's the beginning of AddControl().
            }

            float wScale = (float)mForm.Width / (float)oldCtrl[0].Width;// Scale between new window and original window

            float dgvScale = (float)mForm.Width / (float)width;// Scale between new window and last window

            width = mForm.Width;
            ctrlNo = 1;// First is current window and the sub control start at 1
            AutoScaleControl(mForm, wScale, dgvScale);//Recursion to auto scale control and sub control
        }

        private void AutoScaleControl(Control ctl, float wScale, float dgvScale)
        {
            int ctrLeft, ctrWidth;
            foreach (Control c in ctl.Controls)
            {
                if (c.GetType().Equals(typeof(Microsoft.VisualBasic.PowerPacks.ShapeContainer)))
                {
                    // Hack on lineshape and modify it location X to support maximization
                    ShapeContainer sc = (ShapeContainer)c;
                    foreach (LineShape l in sc.Shapes)
                    {
                        l.X1 = (int)Math.Round(l.X1 * dgvScale);
                        l.X2 = (int)Math.Round(l.X2 * dgvScale);
                    }
                    ctrlNo++;
                }
                else if (c.GetType().Equals(typeof(System.Windows.Forms.DataGridView)))
                {
                    // Hack on DataGridView and scale all columns to support maximization
                    DataGridView dgv = (DataGridView)c;

                    dgv.Width = (int)Math.Round(dgv.Width * dgvScale);
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        dgv.Columns[i].Width = (int)Math.Round(dgv.Columns[i].Width * dgvScale);
                    }

                    ctrlNo++;
                    if (c.Controls.Count > 0)
                        AutoScaleControl(c, wScale, dgvScale);// DataGridView has two sub control, without this statement will throw exception
                }
                else
                {
                    ctrLeft = oldCtrl[ctrlNo].Left;
                    ctrWidth = oldCtrl[ctrlNo].Width;
                    c.Left = (int)Math.Round(ctrLeft * wScale);// Auto scale control location and control only related to window

                    if (!c.Name.Equals("lblTabUser"))
                    {
                        c.Width = (int)Math.Round(ctrWidth * wScale);// Auto scale control width.
                    }
                    ctrlNo++;

                    // Record comboBox location X and refine pnlPageBar location X
                    if (c.Name.Equals("cboPageSize"))
                    {
                        cboLeft = c.Left;
                    }
                    // Refine pnlPageBar width
                    if (c.Name.Equals("pnlPageBar"))
                    {
                        c.Width = 60 + (c.Controls.Count - 2) * 30;
                    }
                    else if (c.Controls.Count > 0)
                    {
                        AutoScaleControl(c, wScale, dgvScale);// Recursion to auto scale control
                    }
                }
            }

            // Refine pnlPageBar location X
            foreach (Control c in ctl.Controls)
            {
                if (c.Name.Equals("pnlPageBar"))
                {
                    int size = c.Controls.Count;
                    c.Left = cboLeft - 70 - (size - 2) * 30;
                }
            }
        }
    }
}
