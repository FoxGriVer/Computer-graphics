using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Gr3V2
{
    [Serializable]
    public class Poliline : AbstractObject
    {
        public float StartPointX { get; set; }
        public float StartPointY { get; set; }
        public Array3x3 ourArrays = new Array3x3();
        public Array3x3 comeBackArray = new Array3x3();
        public List<OurPoint> listOfPoints;
        public bool DrawingMode { get; set; }

        public Poliline()
        {
            listOfPoints = new List<OurPoint>();
            DrawingMode = false;
        }

        public void AddNode(OurPoint point)
        {
            listOfPoints.Add(point);
        }

        public Poliline(int startX, int startY, List<OurPoint> points)
        {
            listOfPoints = new List<OurPoint>();
            StartPointX = startX;
            StartPointY = startY;
            listOfPoints = points;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Pen OurPen = new Pen(Color.Black, 1);
            for (int i = 0; i < listOfPoints.Count; i++)
            {
                if (i == 0)
                {
                    e.Graphics.DrawLine(OurPen, StartPointX, StartPointY, listOfPoints[i].X, listOfPoints[i].Y);
                }
                else
                {
                    e.Graphics.DrawLine(OurPen, listOfPoints[i - 1].X, listOfPoints[i - 1].Y, listOfPoints[i].X, listOfPoints[i].Y);
                }
            }
        }

        public void Rotate(double inputAngle)
        {
            double angle = inputAngle * 3.14 / 180;
            Array3x3 MoveMatrix = new Array3x3();
            MoveMatrix.AddRow(new OurPoint((float)Math.Cos(inputAngle), -(float)Math.Sin(inputAngle), 0));
            MoveMatrix.AddRow(new OurPoint((float)Math.Sin(inputAngle), (float)Math.Cos(inputAngle), 0));
            MoveMatrix.AddRow(new OurPoint(0, 0, 1));

            ourArrays.MultiplyArrays(ourArrays, MoveMatrix);
            for (int i = 0; i < ourArrays.secondListOfPoints.Count; i++)
            {
                if (i == 0)
                {
                    StartPointX = ourArrays.secondListOfPoints[i].X;
                    StartPointY = ourArrays.secondListOfPoints[i].Y;
                }
                listOfPoints[i].X = ourArrays.secondListOfPoints[i].X;
                listOfPoints[i].Y = ourArrays.secondListOfPoints[i].Y;
            }
        }

        public void Move(int x, int y)
        {
            Array3x3 MoveMatrix = new Array3x3();
            MoveMatrix.AddRow(new OurPoint(1, 0, 0));
            MoveMatrix.AddRow(new OurPoint(0, 1, 0));
            MoveMatrix.AddRow(new OurPoint(x, y, 1));

            ourArrays.MultiplyArrays(ourArrays, MoveMatrix);
            for (int i = 0; i < ourArrays.secondListOfPoints.Count; i++)
            {
                if (i == 0)
                {
                    StartPointX = ourArrays.secondListOfPoints[i].X;
                    StartPointY = ourArrays.secondListOfPoints[i].Y;
                }
                listOfPoints[i].X = ourArrays.secondListOfPoints[i].X;
                listOfPoints[i].Y = ourArrays.secondListOfPoints[i].Y;
            }
        }

        public void ToReturn()
        {
            for (int i = 0; i < comeBackArray.secondListOfPoints.Count; i++)
            {
                if (i == 0)
                {
                    StartPointX = comeBackArray.secondListOfPoints[i].X;
                    StartPointY = comeBackArray.secondListOfPoints[i].Y;
                }
                listOfPoints[i].X = comeBackArray.secondListOfPoints[i].X;
                listOfPoints[i].Y = comeBackArray.secondListOfPoints[i].Y;
            }
        }

        public void Increase()
        {
            Array3x3 MoveMatrix = new Array3x3();
            MoveMatrix.AddRow(new OurPoint((float)1.5, 0, 0));
            MoveMatrix.AddRow(new OurPoint(0, (float)1.5, 0));
            MoveMatrix.AddRow(new OurPoint(0, 0, 1));

            ourArrays.MultiplyArrays(ourArrays, MoveMatrix);
            for(int i = 0; i < ourArrays.secondListOfPoints.Count; i++)
            {
                if(i == 0)
                {
                    StartPointX = ourArrays.secondListOfPoints[i].X;
                    StartPointY = ourArrays.secondListOfPoints[i].Y;
                }
                listOfPoints[i].X = ourArrays.secondListOfPoints[i].X;
                listOfPoints[i].Y = ourArrays.secondListOfPoints[i].Y;
            }
        }
    }
}
