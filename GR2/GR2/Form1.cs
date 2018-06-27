using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GR2
{
    public partial class Form1 : Form
    {
        private int order0 = 0;
        private int order;
        private int width;
        private int height;
        private Bitmap fractal;
        private Graphics gr;
        RectangleF carpet;


        public Form1()
        {            
            InitializeComponent();
            width = pictureBox1.Width;
            height = pictureBox1.Height;
            fractal = new Bitmap(width, height);
            gr = Graphics.FromImage(fractal);
            carpet = new RectangleF(0, 0, width, height);
        }

        public int GetOrder()
        {
            if (radioButton1.Checked)
            {
                order = 1;
            }
            if (radioButton2.Checked)
            {
                order = 2;
            }
            if (radioButton3.Checked)
            {
                order = 3;
            }
            if (radioButton4.Checked)
            {
                order = 4;
            }
            if (radioButton5.Checked)
            {
                order = 5;
            }
            return order;
        }

        public void Draw5Carpet()
        {
            System.Threading.Thread.Sleep(1000);
            if (pictureBox1.BackgroundImage != null)
            {
                gr.Clear(Color.White);
            }
            order0++;
            DrawCarpet(order0, carpet);
            pictureBox1.BackgroundImage = fractal;
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            order = GetOrder();
            while (order0 != order)
            {
                Draw5Carpet();
            }
            order0 = 0;
        }

        public void DrawCarpet(int order, RectangleF carpet)
        {
            if (order == 0)
            {
                gr.FillRectangle(Brushes.Black, carpet);
            }
            else
            {
                var width = carpet.Width / 3f;
                var height = carpet.Height / 3f;

                var x1 = carpet.Left;
                var x2 = x1 + width;
                var x3 = x1 + 2f * width;

                var y1 = carpet.Top;
                var y2 = y1 + height;
                var y3 = y1 + 2f * height;

                DrawCarpet(order - 1, new RectangleF(x1, y1, width, height));
                DrawCarpet(order - 1, new RectangleF(x2, y1, width, height));
                DrawCarpet(order - 1, new RectangleF(x3, y1, width, height));
                DrawCarpet(order - 1, new RectangleF(x1, y2, width, height)); 
                DrawCarpet(order - 1, new RectangleF(x3, y2, width, height)); 
                DrawCarpet(order - 1, new RectangleF(x1, y3, width, height));
                DrawCarpet(order - 1, new RectangleF(x2, y3, width, height));
                DrawCarpet(order - 1, new RectangleF(x3, y3, width, height));
            }
        }
    }
}
