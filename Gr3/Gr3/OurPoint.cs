using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Gr3
{
    [DataContract]
    public class OurPoint : AbstractObject
    {
        [DataMember]
        public int X { get; set; }
        [DataMember]
        public int Y { get; set; }

        public OurPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
