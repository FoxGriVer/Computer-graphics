using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace Gr1
{
    [XmlInclude(typeof(Line))]
    [XmlInclude(typeof(Poliline))]
    [XmlInclude(typeof(OurPoint))]
    [XmlInclude(typeof(List<OurPoint>))]
    [XmlInclude(typeof(Bizie))]
    [XmlInclude(typeof(Text))]
    [XmlInclude(typeof(Cirlcle))]
    [XmlInclude(typeof(Ellipsis))]
    [XmlInclude(typeof(Polygon))]
    [XmlInclude(typeof(Rectangle))]
    public abstract class AbstractObject
    {
        public int Width { get; set; }
        public string Color { get; set; }

        public abstract void Draw(object sender, PaintEventArgs e);

    }
}
