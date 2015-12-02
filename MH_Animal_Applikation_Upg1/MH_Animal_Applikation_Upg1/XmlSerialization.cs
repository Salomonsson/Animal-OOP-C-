using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using MH_Animal_Applikation_Upg1.Animals;

namespace MH_Animal_Applikation_Upg1
{
 /// <summary>
    /// This class contains methods for xml serialization of any 
    /// type of objects.
    /// </summary>
    /// <remarks></remarks>
    public static class XMLSerialization
    {
        /// <summary>
        /// A generic method that can be used to serialize any type of object.
        /// The type of object is defined at method call by the client object
        /// </summary>
        public static void SerializeToFile<T>(string filePath, T obj)
        {
            //bool bok = true;
            using (Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {

                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));

                xmlFormat.Serialize(stream, obj);
                
            } 
        }




        /// <summary>
        /// Deserialize any xml file serialized  using this method.
        /// </summary>
        public static T DeserializeFromFile<T>(string filePath)
        {

            XmlSerializer xs = new XmlSerializer(typeof(T));
            object obj = null;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                obj = (T)xs.Deserialize(fs);
            }

            return (T)obj;

        }
    }

}



////DeserializeFromFile
//XmlSerializer serializer = new XmlSerializer(typeof(T));
//object obj = null;
////to be returned with data

//TextReader reader = null;

//try
//{
//    reader = new StreamReader(filePath);
//    obj = (T)serializer.Deserialize(reader);
//}
//catch
//{

//}
//finally
//{
//    if (reader != null)
//    {
//        reader.Close();
//    }
//}
//return (T)obj;





/////SERIALIZE
//XmlSerializer serializer = new XmlSerializer(typeof(T));
//TextWriter writer = new StreamWriter(filePath);
//try
//{
//    serializer.Serialize(writer, obj);
//}
//catch
//{
//    //bok = false;
//}
//finally
//{
//    if (writer != null)

//        writer.Close();
//}

//using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
//{

//    XmlSerializer xmlFormat = new XmlSerializer(m_list.GetType());

//    xmlFormat.Serialize(stream, m_list);
//    return bok = true;
//} 

//return bok;