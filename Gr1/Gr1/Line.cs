using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Gr1
{
    [Serializable]
    public class Line : AbstractObject
    {
        public int StartPointX { get; set; }
        public int StartPointY { get; set; }
        public int EndPointX { get; set; }
        public int EndPointY { get; set; }    
        public OurPoint point { get; set; }    

        public Line()
        {

        }

        public Line (int startX, int startY, int endX, int endY, int width = 2, string color = "Red" )
        {
            StartPointX = startX;
            StartPointX = startY;
            EndPointX = endX;
            EndPointY = endY;
            Width = width;
            Color = color;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Color clr = System.Drawing.Color.FromName(Color);
            Pen OurPen = new Pen(clr,Width);
            e.Graphics.DrawLine(OurPen, StartPointX, StartPointY, EndPointX, EndPointY);
        }
    }
}
