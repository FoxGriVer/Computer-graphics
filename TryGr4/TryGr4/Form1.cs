using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TryGr4
{
    public partial class Form1 : Form
    {
        Workspace myWorkspace = new Workspace();
        Matrix array4x4 = new Matrix();
        public Graphics gr;

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            radioButtonViewX.Checked = true;
            myWorkspace.InitForm(this);
        }        

        public Point MapToScreen(double x, double y)
        {        
            x = pictureBox1.Width * ((x + 50.0) / 100.0);
            y = pictureBox1.Height * (1 - (y + 46.0) / 92.0);
            Point SreenCoord = new Point((int)x, (int)y);

            return SreenCoord;
        }

        public List<TextBox> GetTextBoxes()
        {
            List<TextBox> listOfTextBoxes = new List<TextBox>();
            listOfTextBoxes.Add(textBoxScaleX);
            listOfTextBoxes.Add(textBoxScaleY);
            listOfTextBoxes.Add(textBoxScaleZ);
            listOfTextBoxes.Add(textBoxMoveX);
            listOfTextBoxes.Add(textBoxMoveY);
            listOfTextBoxes.Add(textBoxMoveZ);
            return listOfTextBoxes;
        }

        public List<RadioButton> GetRadioButtons()
        {
            List<RadioButton> listOfCheckBoxes = new List<RadioButton>();
            listOfCheckBoxes.Add(radioButtonViewX);
            listOfCheckBoxes.Add(radioButtonViewY);
            listOfCheckBoxes.Add(radioButtonViewZ);
            listOfCheckBoxes.Add(radioButtonRotateX);
            listOfCheckBoxes.Add(radioButtonRotateY);
            listOfCheckBoxes.Add(radioButtonRotateZ);
            return listOfCheckBoxes;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myWorkspace.scale = true;
            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            gr = e.Graphics;
            Pen OurPen = new Pen(Color.Black, 1);
            Point pointStart1 = MapToScreen(0,-300);
            Point pointStart2 = MapToScreen(0, 300);
            Point pointEnd1 = MapToScreen(-300, 0);
            Point pointEnd2 = MapToScreen(300, 0);
            e.Graphics.DrawLine(OurPen, pointStart1.X, pointStart1.Y, pointStart2.X,pointStart2.Y);
            e.Graphics.DrawLine(OurPen, pointEnd1.X, pointEnd1.Y, pointEnd2.X, pointEnd2.Y);

            InitializeMatrix();
            if (myWorkspace.begin)
            {
                myWorkspace.InitMatrix(array4x4);
            }
            myWorkspace.Draw();
        }

        public void InitializeMatrix()
        {
            array4x4.AddNode(new GeoPoint(0, 0, 0, 1));
            array4x4.AddNode(new GeoPoint(0, 11, 0, 1));
            array4x4.AddNode(new GeoPoint(0, 0, 5, 1));
            array4x4.AddNode(new GeoPoint(0, 0, 0, 1));
            array4x4.AddNode(new GeoPoint(8, 0, 0, 1));
            array4x4.AddNode(new GeoPoint(0, 11, 0, 1));
            array4x4.AddNode(new GeoPoint(8, 0, 5, 1));
            array4x4.AddNode(new GeoPoint(0, 0, 5, 1));
            array4x4.AddNode(new GeoPoint(0, 0, 0, 1));
            array4x4.AddNode(new GeoPoint(8, 0, 0, 1));
            array4x4.AddNode(new GeoPoint(8, 0, 5, 1));
            array4x4.AddNode(new GeoPoint(0, 11, 0, 1));
            array4x4.AddNode(new GeoPoint(8, 0, 0, 1));

        }

        private void buttonStartForm_Click(object sender, EventArgs e)
        {
            myWorkspace.ToComeBack();
            myWorkspace.begin = true;
            pictureBox1.Invalidate();
        }

        private void buttonMove_Click(object sender, EventArgs e)
        {
            myWorkspace.move = true;
            pictureBox1.Invalidate();
        }

        private void buttonRotate_Click(object sender, EventArgs e)
        {
            myWorkspace.rotate = true;
            pictureBox1.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Q)
            {
                myWorkspace.scale = true;
                pictureBox1.Invalidate();
            }
            if (e.KeyData == Keys.W)
            {
                myWorkspace.move = true;
                pictureBox1.Invalidate();
            }
            if (e.KeyData == Keys.E)
            {
                myWorkspace.rotate = true;
                pictureBox1.Invalidate();
            }
            if (e.KeyData == Keys.R)
            {
                myWorkspace.ToComeBack();
                myWorkspace.begin = true;
                pictureBox1.Invalidate();
            }
            if (e.KeyData == Keys.S)
            {
                myWorkspace.scale = true;
                myWorkspace.move = true;
                myWorkspace.rotate = true;
                pictureBox1.Invalidate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myWorkspace.scale = true;
            myWorkspace.move = true;
            myWorkspace.rotate = true;
            pictureBox1.Invalidate();
        }
    }
}
