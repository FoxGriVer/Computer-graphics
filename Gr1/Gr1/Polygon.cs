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
    public class Polygon : AbstractObject
    {
        public List<OurPoint> listOfPoints;
        public bool Fill { get; set; }
        public string BorderColor { get; set; }


        public Polygon()
        {
            listOfPoints = new List<OurPoint>();
        }

        public Polygon(List<OurPoint> points, string color = "Red", string borderColor = "Red", int widthB = 2, bool fill = true)
        {
            listOfPoints = new List<OurPoint>();
            Color = color;
            listOfPoints = points;
            Fill = fill;
            BorderColor = borderColor;
            Width = widthB;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            PointF[] list = new PointF[listOfPoints.Count];
            for (int i = 0; i < listOfPoints.Count; i ++)
            {
                list[i] = new PointF(listOfPoints[i].X, listOfPoints[i].Y);
            }
           
            Color clr = System.Drawing.Color.FromName(Color);
            Color bClr = System.Drawing.Color.FromName(BorderColor);
            Pen OurPen = new Pen(bClr, Width);
            SolidBrush brush = new SolidBrush(clr);
            e.Graphics.FillPolygon(brush, list);
            e.Graphics.DrawPolygon(OurPen, list);

        }
    }
}
