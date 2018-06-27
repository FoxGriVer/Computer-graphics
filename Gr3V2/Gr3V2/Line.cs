using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Gr3V2
{
    [Serializable]
    public class Line : AbstractObject
    {       
        public OurPoint pointStart { get; set; }
        public OurPoint pointEnd { get; set; }


        public Line()
        {

        }

        public Line(OurPoint start, OurPoint end)
        {
            pointStart = new OurPoint();
            pointEnd = new OurPoint();
            pointStart.X = start.X;
            pointStart.Y = start.Y;
            pointEnd.X = end.X;
            pointEnd.Y = end.Y;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Pen OurPen = new Pen(Color.Black, 1);
            e.Graphics.DrawLine(OurPen, pointStart.X, pointStart.Y, pointEnd.X, pointEnd.Y);
        }
    }
}
