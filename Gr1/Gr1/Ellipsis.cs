using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gr1
{
    [Serializable]
    public class Ellipsis: Cirlcle
    {
        public int WidthX { get; set; }
        public int Height { get; set; }

        public Ellipsis()
        {

        }

        public Ellipsis(OurPoint center,int width, int height, string color = "Red", string borderColor = "Red", int widthB = 2, bool fill = true )
            : base(center,0,color,borderColor,widthB, fill)
        {
            WidthX = width;
            Height = height;
            Width = widthB;
            BorderColor = borderColor;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Color clr = System.Drawing.Color.FromName(Color);
            Color bClr = System.Drawing.Color.FromName(BorderColor);
            Pen OurPen = new Pen(bClr, Width);
            e.Graphics.DrawEllipse(OurPen, Center.X, Center.Y, WidthX, Height);
            if (Fill)
            {
                SolidBrush brush = new SolidBrush(clr);
                e.Graphics.FillEllipse(brush, Center.X, Center.Y, WidthX, Height);
            }
        }
    }
}
