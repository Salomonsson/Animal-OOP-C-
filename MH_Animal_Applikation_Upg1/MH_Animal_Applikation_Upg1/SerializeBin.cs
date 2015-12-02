using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH_Animal_Applikation_Upg1.Animals;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MH_Animal_Applikation_Upg1
{
    [Serializable]
    public class SerializeBin
    {

        public static void Save<T>(T obj, string file)
        {
            using (Stream stream = File.Open(file, FileMode.Create, FileAccess.Write))
            {
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(stream, obj);
            }

        }

        public static T Open<T>(string file)
        {
            object obj;
            using (Stream stream = File.Open(file, FileMode.Open))
            {
                BinaryFormatter bin = new BinaryFormatter();
                obj = (T)bin.Deserialize(stream);
            }
            return (T)obj;
        }




    }
}
