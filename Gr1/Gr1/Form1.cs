using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;

namespace Gr1
{
    public partial class Form1 : Form
    {
        public List<AbstractObject> ListOfObjects;

        public Form1()
        {
            ListOfObjects = new List<AbstractObject>();

            InitializeComponent();
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
                pictureBox1.Refresh();

            }
        }

        private void SaveFile_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML file (*.xml)|*.xml";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {               
                Parser OurParser = new Parser();
                OurParser.SaveInFile(saveFileDialog.FileName, ListOfObjects);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            foreach (AbstractObject ob in ListOfObjects)
            {
                ob.Draw(this, e);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "bitmap image (*.bmp)|*.bmp";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics gr = Graphics.FromImage(bitmap))
                {
                    for (int i = 0; i < ListOfObjects.Count; i++)
                    {
                        ListOfObjects[i].Draw(this, new PaintEventArgs(gr, new System.Drawing.Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height)));
                    }
                }
                bitmap.Save(saveFileDialog.FileName);
            }
        }
    }
}
