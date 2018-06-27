using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace Gr3
{
    public partial class Form1 : Form
    {
        public List<AbstractObject> listOfObjects;

        public Form1()
        {
            listOfObjects = new List<AbstractObject>();

            InitializeComponent();
        }

        private void OpenFile_Click(object sender, EventArgs e)
        {
            OurPoint p1 = new OurPoint(5, 6);
            Poligon pol1 = new Poligon("ourText");
            listOfObjects.Add(pol1);
            listOfObjects.Add(p1);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                Parser OurParser = new Parser();
                OurParser.SaveInFile(saveFileDialog.FileName, listOfObjects);
            }
        }
    }
}
