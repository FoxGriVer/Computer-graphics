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
    public class Rectangle : AbstractObject
    {
        public OurPoint StartPoint { get; set; }
        public string BorderColor { get; set; }
        public int WidthX { get; set; }
        public int Height { get; set; }
        public bool Fill { get; set; }

        public Rectangle()
        {

        }

        public Rectangle(OurPoint startPoint, int widthX, int height, string color = "Red", string borderColor = "Red", int widthB = 2, bool fill = true)
        {
            Width = widthB;
            BorderColor = borderColor;
            StartPoint = startPoint;
            WidthX = widthX;
            Height = height;
            Color = color;
            Fill = fill;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Color clr = System.Drawing.Color.FromName(Color);
            Color bClr = System.Drawing.Color.FromName(BorderColor);
            Pen OurPen = new Pen(bClr, Width);
            SolidBrush brush = new SolidBrush(clr);
            System.Drawing.Rectangle rectToDraw = new System.Drawing.Rectangle(StartPoint.X, StartPoint.Y, WidthX, Height);        
            e.Graphics.DrawRectangle(OurPen, rectToDraw);
            e.Graphics.FillRectangle(brush, rectToDraw);
        }
    }
}
