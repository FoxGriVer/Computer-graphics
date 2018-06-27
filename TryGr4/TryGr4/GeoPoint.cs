using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryGr4
{
    public class GeoPoint
    {
        public double[] coord = new double[4];

        public GeoPoint(double x, double y, double z, double h)
        {
            coord[0] = x;
            coord[1] = y;
            coord[2] = z;
            coord[3] = h;
        }
    }
}
