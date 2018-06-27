using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gr3V2
{
    public partial class Form1 : Form
    {
        public List<AbstractObject> ListOfObjects;
        List<AbstractObject> bufferListAbstract;
        bool draw = true;
        int functionMode = 0;

        public Form1()
        {
            InitializeComponent();

            ListOfObjects = new List<AbstractObject>();
            bufferListAbstract = new List<AbstractObject>();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "XML file (*.xml)|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Parser OurParser = new Parser();
                ListOfObjects.Clear();
                ListOfObjects = OurParser.ReadFromFile(openFileDialog.FileName);
                DrawElements();                
            }

            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "XML file (*.xml)|*.xml";
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    Parser OurParser = new Parser();
            //    OurParser.SaveInFile(saveFileDialog.FileName, ListOfObjects);
            //}
        }   

        public void DrawElements()
        {
            pictureBox1.Invalidate();
        }

        public OurPoint WorldToScreen(OurPoint inputPoint)
        {
            var point = new OurPoint();
            point.X = (inputPoint.X + pictureBox1.Width / 2);
            point.Y = -inputPoint.Y + pictureBox1.Height / 2;
            return point;
        }

        //public OurPoint ScreenToPictureBox(OurPoint inputPoint)
        //{
        //    var point = new OurPoint();
        //    point.X = (inputPoint.X - pictureBox1.Width / 2);
        //    point.Y = -(inputPoint.Y - pictureBox1.Height / 2);
        //    return point;
        //}

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen OurPen = new Pen(Color.Black, 1);
            Line line1 = new Line(WorldToScreen(new OurPoint(0, -300)), WorldToScreen(new OurPoint(0, 300)));
            Line line2 = new Line(WorldToScreen(new OurPoint(-300, 0)), WorldToScreen(new OurPoint(300, 0)));
            e.Graphics.DrawLine(OurPen, line1.pointStart.X, line1.pointStart.Y, line1.pointEnd.X, line1.pointEnd.Y);
            e.Graphics.DrawLine(OurPen, line2.pointStart.X, line2.pointStart.Y, line2.pointEnd.X, line2.pointEnd.Y);
            if (draw)
            {
                foreach (AbstractObject ob in ListOfObjects)
                {
                    ob.Draw(this, e);
                }
            }
            else
            {
                foreach (AbstractObject ob in bufferListAbstract)
                {
                    ob.Draw(this, e);
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < bufferListAbstract.Count; i++)
            {
                if (bufferListAbstract[i].GetType() == typeof(Poliline))
                {
                    Poliline buffer = new Poliline();
                    buffer = (Poliline)bufferListAbstract[i];
                    buffer.ToReturn();                    
                }
                for (int k = 0; k < 3; k++)
                {
                    bufferListAbstract.RemoveAt(0);
                }
                draw = true;
            }
            pictureBox1.Invalidate();       
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            functionMode = 1;
            MakeChoice();            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            functionMode = 2;
            MakeChoice();           
        }

        public void MakeChoice()
        {
            for (int i = 0; i < ListOfObjects.Count; i++)
            {
                if (ListOfObjects[i].GetType() == typeof(Poliline))
                {
                    Poliline buffer = new Poliline();
                    Poliline bufferFinal = new Poliline();
                    buffer = (Poliline)ListOfObjects[i];
                    for (int j = 0; j < buffer.listOfPoints.Count; j++)
                    {
                        bufferFinal.ourArrays.AddRow(new OurPoint(buffer.listOfPoints[j].X, buffer.listOfPoints[j].Y));
                        bufferFinal.listOfPoints.Add(new OurPoint(buffer.listOfPoints[j].X, buffer.listOfPoints[j].Y));
                        bufferFinal.StartPointX = buffer.listOfPoints[j].X;
                        bufferFinal.StartPointY = buffer.listOfPoints[j].Y;
                    }
                    draw = false;
                    switch(functionMode)
                    {
                        case 1:
                            {
                                bufferFinal.comeBackArray = bufferFinal.ourArrays.ToCopy();
                                bufferFinal.Increase();
                                bufferFinal.Move(-80, -150);
                                bufferListAbstract.Add(bufferFinal);
                                break;
                            }
                        case 2:
                            {
                                bufferFinal.comeBackArray = bufferFinal.ourArrays.ToCopy();
                                bufferFinal.Move(300, -150);
                                bufferListAbstract.Add(bufferFinal);                                
                                break;
                            }
                        case 3:
                            {
                                bufferFinal.comeBackArray = bufferFinal.ourArrays.ToCopy();
                                bufferFinal.Rotate(45);
                                bufferFinal.Move(-150, 280);
                                bufferListAbstract.Add(bufferFinal);
                                break;
                            }
                    }
                    if (bufferListAbstract.Count >= 4)
                    {
                        for (int k = 0; k < 3; k++)
                        {
                            bufferListAbstract.RemoveAt(0);
                        }
                    }
                }
                if (ListOfObjects[i].GetType() == typeof(Circle))
                {
                    Circle buffer = new Circle();
                    buffer = (Circle)ListOfObjects[i];
                    Circle bufferFinal = new Circle(new OurPoint(buffer.Center.X, buffer.Center.Y), buffer.Radius, buffer.Angle1, buffer.Angle2);                  
                    draw = false;
                    switch (functionMode)
                    {
                        case 1:
                            {
                                bufferFinal.Increase();
                                bufferListAbstract.Add(bufferFinal);
                                break;
                            }
                        case 2:
                            {
                                bufferFinal.Move(300, -150);
                                bufferListAbstract.Add(bufferFinal);
                                break;
                            }
                        case 3:
                            {
                                bufferFinal.Rotate(45);
                                bufferFinal.Move(35, -10);
                                bufferListAbstract.Add(bufferFinal);
                                break;
                            }
                    }
                }
                pictureBox1.Invalidate();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            functionMode = 3;
            MakeChoice();
        }

        public void MakeAllOperations()
        {
            for (int i = 0; i < ListOfObjects.Count; i++)
            {
                if (ListOfObjects[i].GetType() == typeof(Poliline))
                {
                    Poliline buffer = new Poliline();
                    Poliline bufferFinal = new Poliline();
                    buffer = (Poliline)ListOfObjects[i];
                    for (int j = 0; j < buffer.listOfPoints.Count; j++)
                    {
                        bufferFinal.ourArrays.AddRow(new OurPoint(buffer.listOfPoints[j].X, buffer.listOfPoints[j].Y));
                        bufferFinal.listOfPoints.Add(new OurPoint(buffer.listOfPoints[j].X, buffer.listOfPoints[j].Y));
                        bufferFinal.StartPointX = buffer.listOfPoints[j].X;
                        bufferFinal.StartPointY = buffer.listOfPoints[j].Y;
                    }
                    draw = false;
                    bufferFinal.comeBackArray = bufferFinal.ourArrays.ToCopy();
                    bufferFinal.Increase();
                    bufferFinal.Move(200, -300);
                    bufferFinal.Rotate(45);
                    bufferFinal.Move(100, 440);
                    bufferListAbstract.Add(bufferFinal);
                }
                if (ListOfObjects[i].GetType() == typeof(Circle))
                {
                    Circle buffer = new Circle();
                    buffer = (Circle)ListOfObjects[i];
                    Circle bufferFinal = new Circle(new OurPoint(buffer.Center.X, buffer.Center.Y), buffer.Radius, buffer.Angle1, buffer.Angle2);
                    bufferFinal.Increase();
                    bufferFinal.Move(310, -180);
                    bufferListAbstract.Add(bufferFinal);
                    draw = false;
                }
            }
            if (bufferListAbstract.Count >= 4)
            {
                for (int i = 0; i < 3; i++)
                {
                    bufferListAbstract.RemoveAt(0);                   
                }
            }
            pictureBox1.Invalidate();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            MakeAllOperations();
        }
    }
}
