using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace Gr3
{
    [DataContract]
    public class Poligon : AbstractObject
    {
        [DataMember]
        public string Text { get; set; }

        public Poligon(string text)
        {
            Text = text;
        }

    }
}
