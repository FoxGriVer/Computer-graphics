using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gr1
{
    [Serializable]
    public class Cirlcle : AbstractObject
    {
        public OurPoint Center { get; set; }
        public int Radius { get; set; }
        public bool Fill { get; set; }
        public string BorderColor { get; set; }


        public Cirlcle()
        {

        }

        public Cirlcle(OurPoint center, int radius, string color = "Red", string borderColor = "Red", int widthB = 2, bool fill = true )
        {
            Center = center;
            Radius = radius;
            Color = color;
            Fill = fill;
            BorderColor = borderColor;
            Width = widthB;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Color clr = System.Drawing.Color.FromName(Color);
            Color bClr = System.Drawing.Color.FromName(BorderColor);
            Pen OurPen = new Pen(bClr, Width);
            e.Graphics.DrawEllipse(OurPen, Center.X, Center.Y, Radius, Radius);
            if (Fill)
            {
                SolidBrush brush = new SolidBrush(clr);
                e.Graphics.FillEllipse(brush, Center.X, Center.Y, Radius, Radius);
            }
        }
    }
}
