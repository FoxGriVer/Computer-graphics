using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TryGr4
{
    public class Workspace
    {
        public bool begin = true;
        public bool move = false, rotate = false, scale = false;
        Matrix Nodes = new Matrix();
        Matrix StartMatrix;
        public Matrix SourceNodes = new Matrix();
        int m, k, l;        
        Form1 form;

        public Matrix SaveStartMatrix()
        {
            StartMatrix = Nodes.MakeCopy();
            return StartMatrix;
        }

        public void CheckRadioButtons()
        {
            List<RadioButton> localListOfCheckBoxes = form.GetRadioButtons();
            if (localListOfCheckBoxes[0].Checked)
            { m = 0; k = 1; l = 2; }
            if (localListOfCheckBoxes[1].Checked)
            { m = 1; k = 0; l = 2; }
            if (localListOfCheckBoxes[2].Checked)
            { m = 2; k = 0; l = 1; }
        }

        public void InitForm(Form1 inputForm)
        {
            form = inputForm;
        }

        public void InitMatrix(Matrix inputMatrix)
        {
            Nodes = inputMatrix;
        }

        public void Draw()
        {
            if (!begin)
            {
                if (scale)
                {
                    Nodes = ToScale().MakeCopy();
                    scale = false;
                }
                if (move)
                {
                    Nodes = Move().MakeCopy();
                    move = false;
                }
                if(rotate)
                {
                    Nodes = Rotate().MakeCopy();
                    rotate = false;
                }
            }
            else
            {
                Nodes = SaveStartMatrix();
                begin = false;
            }


            CheckRadioButtons();
            for (int i = 0; i < Nodes.matrix.Count; i++)
            {
                if (i < Nodes.matrix.Count / 2)
                {
                    Point start1 = form.MapToScreen(Nodes.matrix[i].coord[k], Nodes.matrix[i].coord[l]);
                    Point start2 = form.MapToScreen(Nodes.matrix[i + Nodes.matrix.Count / 2].coord[k], Nodes.matrix[i + Nodes.matrix.Count / 2].coord[l]);
                    form.gr.DrawLine(new Pen(Color.Red), form.MapToScreen(Nodes.matrix[i].coord[k], Nodes.matrix[i].coord[l]), form.MapToScreen(Nodes.matrix[i + Nodes.matrix.Count / 2].coord[k], Nodes.matrix[i + Nodes.matrix.Count / 2].coord[l]));

                    if (i != Nodes.matrix.Count / 2 - 1)
                        form.gr.DrawLine(new Pen(Color.Red),form.MapToScreen(Nodes.matrix[i].coord[k], Nodes.matrix[i].coord[l]),form.MapToScreen(Nodes.matrix[i + 1].coord[k], Nodes.matrix[i + 1].coord[l]));
                    else
                        form.gr.DrawLine(new Pen(Color.Red),form.MapToScreen(Nodes.matrix[i].coord[k], Nodes.matrix[i].coord[l]),form.MapToScreen(Nodes.matrix[0].coord[k], Nodes.matrix[0].coord[l]));
                }
                else
                {
                    if (i != Nodes.matrix.Count - 1)
                        form.gr.DrawLine(new Pen(Color.Red),form.MapToScreen(Nodes.matrix[i].coord[k], Nodes.matrix[i].coord[l]),form.MapToScreen(Nodes.matrix[i + 1].coord[k], Nodes.matrix[i + 1].coord[l]));
                    else
                        form.gr.DrawLine(new Pen(Color.Red),form.MapToScreen(Nodes.matrix[i].coord[k], Nodes.matrix[i].coord[l]),form.MapToScreen(Nodes.matrix[Nodes.matrix.Count / 2].coord[k], Nodes.matrix[Nodes.matrix.Count / 2].coord[l]));
                }
            }
        }

        public Matrix Rotate(double inputAngle = 45)
        {
            List<RadioButton> localListOfCheckBoxes = form.GetRadioButtons();

            inputAngle = inputAngle * 3.14 / 180.0;
            Matrix TurnMatrix = new Matrix();

            if (localListOfCheckBoxes[3].Checked)
            {
                TurnMatrix.AddNode(new GeoPoint(1, 0, 0, 0));
                TurnMatrix.AddNode(new GeoPoint(0, Math.Cos(inputAngle), -Math.Sin(inputAngle), 0));
                TurnMatrix.AddNode(new GeoPoint(0, Math.Sin(inputAngle), Math.Cos(inputAngle), 0));
                TurnMatrix.AddNode(new GeoPoint(0, 0, 0, 1));
            }

            if (localListOfCheckBoxes[4].Checked)
            {
                TurnMatrix.AddNode(new GeoPoint(Math.Cos(inputAngle), 0, -Math.Sin(inputAngle), 0));
                TurnMatrix.AddNode(new GeoPoint(0, 1, 0, 0));
                TurnMatrix.AddNode(new GeoPoint(Math.Sin(inputAngle), 0, Math.Cos(inputAngle), 0));
                TurnMatrix.AddNode(new GeoPoint(0, 0, 0, 1));
            }

            if (localListOfCheckBoxes[5].Checked)
            {
                TurnMatrix.AddNode(new GeoPoint(Math.Cos(inputAngle), -Math.Sin(inputAngle), 0, 0));
                TurnMatrix.AddNode(new GeoPoint(Math.Sin(inputAngle), Math.Cos(inputAngle), 0, 0));
                TurnMatrix.AddNode(new GeoPoint(0, 0, 1, 0));
                TurnMatrix.AddNode(new GeoPoint(0, 0, 0, 1));
            }

            Matrix ResultMatrix = Nodes * TurnMatrix;
            return ResultMatrix;

        }

        public Matrix Move()
        {
            Matrix MoveMatrix = new Matrix();
            List<TextBox> checkTextBoxes = form.GetTextBoxes();

            for (int i = 3; i < checkTextBoxes.Count; i++)
            {
                int res;
                bool isInt = Int32.TryParse(checkTextBoxes[i].Text, out res);
                if (!isInt)
                {
                    MessageBox.Show("Введите в поля число");
                    return Nodes;
                }
            }

            int dx_mov = Convert.ToInt32(checkTextBoxes[3].Text);
            int dy_mov = Convert.ToInt32(checkTextBoxes[4].Text);
            int dz_mov = Convert.ToInt32(checkTextBoxes[5].Text);
            MoveMatrix.AddNode(new GeoPoint(1, 0, 0, 0));
            MoveMatrix.AddNode(new GeoPoint(0, 1, 0, 0));
            MoveMatrix.AddNode(new GeoPoint(0, 0, 1, 0));
            MoveMatrix.AddNode(new GeoPoint(dx_mov, dy_mov, dz_mov, 1));
            

            Matrix ResultMatrix = Nodes * MoveMatrix;
            return ResultMatrix;
        }

        public void ToComeBack()
        {
            Nodes = SourceNodes;
        }

        private Matrix ToScale()
        {
            Matrix ScaleMatrix = new Matrix();
            List<TextBox> checkTextBoxes = form.GetTextBoxes();

            for (int i = 0; i < checkTextBoxes.Count - 3; i++)
            {
                int res;
                bool isInt = Int32.TryParse(checkTextBoxes[i].Text, out res);
                if(!isInt)
                {
                    MessageBox.Show("Введите в поля число");
                    return Nodes;
                }
            }

            ScaleMatrix.AddNode(new GeoPoint((double)Convert.ToInt32(checkTextBoxes[0].Text), 0, 0, 0));
            ScaleMatrix.AddNode(new GeoPoint(0, (double)Convert.ToInt32(checkTextBoxes[1].Text), 0, 0));
            ScaleMatrix.AddNode(new GeoPoint(0, 0, (double)Convert.ToInt32(checkTextBoxes[2].Text), 0));
            ScaleMatrix.AddNode(new GeoPoint(0, 0, 0, 1));
            Matrix ResultMatrix = Nodes * ScaleMatrix;
            return ResultMatrix;            
        }
    }
}
