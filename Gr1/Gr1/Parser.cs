using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Gr1
{
    class Parser
    {
        public void SaveInFile(string path, List<AbstractObject> objects)
        {
            XmlSerializer OurSerializer = new XmlSerializer(typeof(List<AbstractObject>));
            TextWriter tw = new StreamWriter(@path);
            OurSerializer.Serialize(tw, objects);
            tw.Close();
        }

        public List<AbstractObject> ReadFromFile(string path)
        {
            List<AbstractObject> objects = new List<AbstractObject>();
            XmlSerializer OurSerializer = new XmlSerializer(typeof(List<AbstractObject>));
            StreamReader or = new StreamReader(@path);
            objects = (List<AbstractObject>)OurSerializer.Deserialize(or);
            return objects;
        }


    }
}
