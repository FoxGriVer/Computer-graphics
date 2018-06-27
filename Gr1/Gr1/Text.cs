using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Xml.Serialization;


namespace Gr1
{
    [Serializable]
    public class Text: AbstractObject
    {
        public string TextBox { get; set; }
        public OurPoint Pozition { get; set; }
        public string Font { get; set; }
        public int Size { get; set; }

        public Text()
        {

        }

        public Text(string text, OurPoint point, string font = "Arial", int size = 8, string color = "Red")
        {
            TextBox = text;
            Pozition = point;
            Font = font;
            Size = size;
            Color = color;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
            Color clr = System.Drawing.Color.FromName(Color);            
            SolidBrush brush = new SolidBrush(clr);
            Font ourFont = new System.Drawing.Font(Font, Size);
            e.Graphics.DrawString(TextBox, ourFont, brush, Pozition.X,Pozition.Y);
        }
    }
}
