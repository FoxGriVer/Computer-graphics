using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace Gr3V2
{
    [XmlInclude(typeof(OurPoint))]
    [XmlInclude(typeof(Poliline))]
    [XmlInclude(typeof(Circle))]
    [XmlInclude(typeof(Array3x3))]
    [XmlInclude(typeof(List<OurPoint>))]
    public abstract class AbstractObject
    {
        public abstract void Draw(object sender, PaintEventArgs e);
    }
}
