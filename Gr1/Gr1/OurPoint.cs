using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gr1
{
    [Serializable]
    public class OurPoint : AbstractObject
    {
        public int X { get; set; }
        public int Y { get; set; }

        public OurPoint()
        {

        }

        public OurPoint(int x, int y )
        {
            X = x;
            Y = y;
        }

        public OurPoint (float x, float y)
        {
            X = (int)x;
            Y = (int)y;
        }

        public override void Draw(object sender, PaintEventArgs e)
        {
        }
    }
}
