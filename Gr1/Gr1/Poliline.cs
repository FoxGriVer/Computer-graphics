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
    public class Poliline : AbstractObject
    {
        public int StartPointX { get; set; }
        public int StartPointY { get; set; }
        public List<OurPoint> listOfPoints;

        public Poliline()
        {
            listOfPoints = new List<OurPoint>();
        }

        public void AddNode(OurPoint point)
        {
            listOfPoints.Add(point);
        }

        public Poliline(int startX, int startY, List<OurPoint> points, int width = 2, string color = "Red")
        {
            listOfPoints = new List<OurPoint>();
            StartPointX = startX;
            StartPointX = startY;
            Width = width;
            Color = color;
            listOfPoints = points;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Color clr = System.Drawing.Color.FromName(Color);
            Pen OurPen = new Pen(clr, Width);
            for (int i = 0; i < listOfPoints.Count; i ++)
            {
                if(i == 0)
                {
                    e.Graphics.DrawLine(OurPen, StartPointX, StartPointY, listOfPoints[i].X, listOfPoints[i].Y);
                }
                else
                {
                    e.Graphics.DrawLine(OurPen, listOfPoints[i-1].X, listOfPoints[i-1].Y, listOfPoints[i].X, listOfPoints[i].Y);
                }
            }            
        }
    }
}
