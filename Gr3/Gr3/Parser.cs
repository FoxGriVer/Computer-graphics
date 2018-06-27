using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;


namespace Gr3
{
    class Parser
    {
        public void SaveInFile(string path, List<AbstractObject> objects)
        {
            DataContractJsonSerializer ourJsonSerializer = new DataContractJsonSerializer(typeof(List<AbstractObject>));
            FileStream st = new FileStream(@path, FileMode.OpenOrCreate);
            using (FileStream fs = new FileStream(@path , FileMode.OpenOrCreate))
            {
                ourJsonSerializer.WriteObject(fs, objects);
            }
        }
    }
}
