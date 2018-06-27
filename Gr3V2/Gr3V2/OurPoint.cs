using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gr3V2
{
    [Serializable]
    public class OurPoint : AbstractObject
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float H { get; set; }

        public List<float> listOfCoordinates = new List<float>();

        public OurPoint()
        {

        }

        public OurPoint(float x, float y,  float h = 1)
        {
            X = x;
            listOfCoordinates.Add(X);
            Y = y;
            listOfCoordinates.Add(Y);
            H = h;
            listOfCoordinates.Add(H);
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
        }
    }
}
