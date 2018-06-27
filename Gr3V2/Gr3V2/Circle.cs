using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gr3V2
{   [Serializable]
    public class Circle : AbstractObject
    {
        public OurPoint Center { get; set; }
        public float Radius { get; set; }
        public float Angle1 { get; set; }
        public float Angle2 { get; set; }
        public Array3x3 ourArrays = new Array3x3();

        public Circle()
        {

        }

        public Circle(OurPoint center, float radius, float angle1, float angle2)
        {
            Center = new OurPoint();
            Center.X = center.X;
            Center.Y = center.Y;
            Radius = radius;
            Angle1 = angle1;
            Angle2 = angle2;
        }

        public void Increase()
        {    
            Radius *= (float)1.4;       
        }

        public void Move(int x, int y)
        {
            Center.X += x;
            Center.Y += y;
        }

        public void Rotate(double inputAngle)
        {
            double angle = inputAngle * 3.14 / 180;
            Array3x3 MoveMatrix = new Array3x3();
            MoveMatrix.AddRow(new OurPoint((float)Math.Cos(inputAngle), -(float)Math.Sin(inputAngle), 0));
            MoveMatrix.AddRow(new OurPoint((float)Math.Sin(inputAngle), (float)Math.Cos(inputAngle), 0));
            MoveMatrix.AddRow(new OurPoint(0, 0, 1));
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Pen OurPen = new Pen(Color.Black, 1);

            float temp1 = Angle1;
            float temp2 = Angle2;
            Angle1 = (float)((Angle1 / 180) * Math.PI);
            Angle2 = (float)((Angle2 / 180) * Math.PI);

            float koef = (float)(Math.PI * 2 / Math.Abs(Angle2 - Angle1));
            float iterations = (float)Math.Round((2 * Radius + 5) / koef);
            float delta = (Angle2 - Angle1) / iterations;

            float x1 = Center.X + Radius * (float)Math.Cos(Angle1);
            float y1 = Center.Y - Radius * (float)Math.Sin(Angle1);
            for (int i = 0; i < iterations; i++)
            {
                Angle1 += delta;
                float x2 = Center.X + Radius * (float)Math.Cos(Angle1);
                float y2 = Center.Y - Radius * (float)Math.Sin(Angle1);
                e.Graphics.DrawLine(OurPen, x1, y1, x2, y2);
                x1 = x2;
                y1 = y2;
            }
            Angle1 = temp1;
            Angle2 = temp2;
        }
    }
}
