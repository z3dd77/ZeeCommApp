using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;

namespace ZeeCommApp
{
    public class RoundedLabel : Label
    {
        private Color pillColor = Color.LightGray;
        private Color labelBackColor = SystemColors.Control; // Default to the system control color

        public Color PillColor
        {
            get { return pillColor; }
            set
            {
                pillColor = value;
                Invalidate(); // Redraw the control when the pill color is changed
            }
        }

        public Color LabelBackColor
        {
            get { return labelBackColor; }
            set
            {
                labelBackColor = value;
                Invalidate(); // Redraw the control when the label background color is changed
            }
        }

        public RoundedLabel()
        {
            this.Size = new Size(100, 30); // Adjust the size as needed
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            RectangleF rect = new RectangleF(0, 0, this.Width, this.Height);

            using (GraphicsPath roundedRect = GetRoundedRectangle(rect, 15))
            using (SolidBrush pillBrush = new SolidBrush(pillColor))
            using (SolidBrush labelBackBrush = new SolidBrush(labelBackColor))
            {
                e.Graphics.FillPath(pillBrush, roundedRect);
                e.Graphics.FillRectangle(labelBackBrush, rect.Width / 2, 0, rect.Width / 2, rect.Height);
            }

            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, Rectangle.Round(rect), this.ForeColor, labelBackColor, TextFormatFlags.VerticalCenter | TextFormatFlags.Left);
        }

        private GraphicsPath GetRoundedRectangle(RectangleF rect, float radius)
        {
            GraphicsPath roundedRect = new GraphicsPath();

            roundedRect.AddArc(rect.X, rect.Y, radius * 2, radius * 2, 180, 90);
            roundedRect.AddArc(rect.Right - radius * 2, rect.Y, radius * 2, radius * 2, 270, 90);
            roundedRect.AddArc(rect.Right - radius * 2, rect.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            roundedRect.AddArc(rect.X, rect.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);

            roundedRect.CloseFigure();

            return roundedRect;
        }
    }
}
