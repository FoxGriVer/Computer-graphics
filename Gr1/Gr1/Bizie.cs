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
    public class Bizie : AbstractObject
    {
        public OurPoint StartPoint { get; set; }
        public OurPoint EndPoint { get; set; }
        public OurPoint MejPoint1 { get; set; }
        public OurPoint MejPoint2 { get; set; }

        public Bizie()
        {

        }

        public Bizie(OurPoint startPoint, OurPoint endPoint, OurPoint mejPoint1, OurPoint mejPoint2, int width = 2, string color = "Red")
        {
            StartPoint = startPoint;
            EndPoint = endPoint;
            MejPoint1 = mejPoint1;
            MejPoint2 = mejPoint2;
            Width = width;
            Color = color;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Color clr = System.Drawing.Color.FromName(Color);
            Pen OurPen = new Pen(clr, Width);
            e.Graphics.DrawBezier(OurPen,StartPoint.X,StartPoint.Y,MejPoint1.X, MejPoint1.Y,MejPoint2.X, MejPoint2.Y, EndPoint.X, EndPoint.Y);
        }
    }
}
