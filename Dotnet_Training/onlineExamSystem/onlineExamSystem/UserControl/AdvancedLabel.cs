using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace UI
{
    public class AdvancedLabel : Control
    {
        private Color stateBackGroundColor;

        public float Radius { get; set; }

        public new Color DefaultBackColor { get; set; }
        public Color MouseDownBackColor { get; set; }

        public Color BorderColor { get; set; }
        public float BorderSize { get; set; }

        public new Font DefaultFont { get; set; }
        public Font MouseDownFont { get; set; }
        public Color DefaultFontColor { get; set; }
        public Color MouseDownFontColor { get; set; }

        private bool isMouseDown;
        
        public AdvancedLabel()
        {
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.UpdateStyles();
            base.CreateControl();

            this.Radius = 3.0f;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x20; // Control support transparent
                return cp;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            this.stateBackGroundColor = this.MouseDownBackColor;
            this.isMouseDown = true;
            this.Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            this.stateBackGroundColor = this.DefaultBackColor;
            this.isMouseDown = false;
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            Rectangle actualArea =
                new Rectangle(
                    this.DisplayRectangle.X,
                    this.DisplayRectangle.Y,
                    this.DisplayRectangle.Width - 1,
                    this.DisplayRectangle.Height - 1);

            g.SmoothingMode = SmoothingMode.AntiAlias;

            GraphicsPath path = CreateBorderPath(actualArea, this.Radius, this.BorderSize);

            if (this.stateBackGroundColor.IsEmpty)
            {
                this.stateBackGroundColor = this.DefaultBackColor;
            }

            if (!this.isMouseDown)
            {
                if (this.BorderSize > 0)
                {
                    g.DrawPath(new Pen(this.BorderColor, this.BorderSize), path);
                }
                this.Font = this.DefaultFont;
                this.ForeColor = this.DefaultFontColor;
            }
            else
            {
                this.Font = this.MouseDownFont;
                this.ForeColor = this.MouseDownFontColor;
            }

            g.FillPath(new SolidBrush(this.stateBackGroundColor), path);

            Rectangle textArea = new Rectangle(actualArea.X, actualArea.Y, actualArea.Width, (int)(actualArea.Height * 0.9));
            TextRenderer.DrawText(g, Text, this.Font, textArea, ForeColor);
        
        }

        private GraphicsPath CreateBorderPath(RectangleF rectangle, float radius, float width)
        {
            int halfWidth = (int)(width / 2);
            float actualRadus = radius - halfWidth;

            GraphicsPath gp = new GraphicsPath();

            gp.AddLine(
                new PointF(rectangle.X + radius / 2, rectangle.Y + halfWidth),
                new PointF(rectangle.Right - radius, rectangle.Y + halfWidth));

            gp.AddArc(
                new RectangleF(rectangle.Right - radius, rectangle.Y + halfWidth, actualRadus, actualRadus),
                270F,
                90F);

            gp.AddLine(
                new PointF(rectangle.Right - halfWidth, rectangle.Y + radius),
                new PointF(rectangle.Right - halfWidth, rectangle.Bottom - radius));

            gp.AddArc(
                new RectangleF(rectangle.Right - radius, rectangle.Bottom - radius, actualRadus, actualRadus),
                0F,
                90F);

            gp.AddLine(
                new PointF(rectangle.Right - radius, rectangle.Bottom - halfWidth),
                new PointF(rectangle.X + radius, rectangle.Bottom - halfWidth));

            gp.AddArc(
                new RectangleF(rectangle.X + halfWidth, rectangle.Bottom - radius, actualRadus, actualRadus),
                90F,
                90F);

            gp.AddLine(
                new PointF(rectangle.X + halfWidth, rectangle.Bottom - radius),
                new PointF(rectangle.X + halfWidth, rectangle.Y + radius));

            gp.AddArc(
                new RectangleF(rectangle.X + halfWidth, rectangle.Y, actualRadus, actualRadus),
                180F,
                90F);

            return gp;
        }
    }
}
