using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH_Animal_Applikation_Upg1.Animals;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Windows.Forms;



namespace MH_Animal_Applikation_Upg1
{


    [Serializable]
    public class ListManager<T> : IListManager<T>
    { // : IListManager<T>

        private List<T> m_list;
        //private static List<T> m_list;
        

        /// <summary>
        /// Instantiate constrctor
        /// </summary>
        public ListManager()
         {
             m_list = new List<T>();
            
         }


        /// <summary>
        /// Add new objekt(type) to list
        /// </summary>
        /// <param name="obj">income type</param>
        /// <returns></returns>
        public bool Add(T obj)
        {
            if (obj != null)
            {
                m_list.Add(obj);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove object by index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool DeleteAt(int index)
        {
            if (index != null)
            {
                m_list.RemoveAt(index);
                return true;
            }

            return false;
            //m_list.RemoveAt(index);
        }


        /// <summary>
        /// Convert the list to an array.
        /// </summary>
        /// <returns></returns>
        public string[] ToStringArray()
        {
            
            int setID = 0;
            string[] arr = new string[m_list.Count];

            foreach (T an in m_list)
            {
               
                arr[setID++] = an.ToString();
            }
            return arr;
        }

        /// <summary>
        /// Return a list.
        /// </summary>
        /// <returns></returns>
        public List<string> ToStringList()
        {
            List<string> lst = new List<string>();

            foreach (T an in m_list)
            {
                lst.Add(an.ToString());
            }
            //return new List<T>();
            return lst;
            //return m_list;
        }


        /// <summary>
        /// Get index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public T GetAt(int index)
        {
            return m_list[index];
        }


         /// <summary>
         /// Read only property to get nr of elemnts in list
         /// </summary>
        public int Count
        {
           get { return m_list.Count; }
        }


        public void Reset()
        {
            m_list.Clear();
        }


        /// <summary>
        /// BinarySerialize serialize to file by the function SAVE in the class SerializeBin.
        /// 
        /// </summary>
        /// <param name="fileName">Path of location for file</param>
        /// <returns>Boolean if path is empty or not.</returns>
        public bool BinarySerialize(string fileName)
        {
            bool bok;
            bok = false;

            if (fileName != null)
            {
                SerializeBin.Save<List<T>>(m_list, fileName);
                bok = true;
            }
            return bok;
        }



        /// <summary>
        /// BinaryDeSerialize uses the static function OPEN of class SerializeBin.
        /// Boolean value is set if listmanager is null or not.
        /// </summary>
        /// <param name="fileName">path link, where to get file</param>
        /// <returns>return boolean</returns>
        public bool BinaryDeSerialize(string fileName)
        {
            bool bok;
            bok = false;

            m_list = SerializeBin.Open<List<T>>(fileName);

            if (m_list != null)
            {
                bok = true;
            }

            return bok;

        }


        /// <summary>
        /// Serialize any income to XML
        /// </summary>
        /// <param name="fileName">Path to file</param>
        /// <returns>boolean true if filename is active</returns>
        public bool XMLSerialize(string fileName)
        {
            bool bok = false;

            if (fileName != null)
            {
                XMLSerialization.SerializeToFile<List<T>>(fileName, m_list);
                bok = true;
            }

            return bok;   
        }


        /// <summary>
        /// XMLDeserialize deserialize on from the XMLSerialization class.
        /// </summary>
        /// <param name="filePath">Path of file.</param>
        public void XMLDeserialize(string filePath)
        {
            m_list = XMLSerialization.DeserializeFromFile<List<T>>(filePath);
                
        }

    }
}




//CODE

///SERIALIZE XML
//using (Stream stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
//{

//    XmlSerializer xmlFormat = new XmlSerializer(m_list.GetType());

//    xmlFormat.Serialize(stream, m_list);
//    return bok = true;
//} 

//DESERIALIZE XML
//XmlSerializer xs = new XmlSerializer(m_list.GetType());
//using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
//{
//m_list = (List<T>)xs.Deserialize(fs);
//}

// --- serialize binary
//Save the list to the specified filename
//using (Stream stream = File.Open(fileName, FileMode.Create, FileAccess.Write))
//{
//    BinaryFormatter bin = new BinaryFormatter();
//    bin.Serialize(stream, m_list);
//}

// --- DESERIALIZE binary
//Load the list from the specified filename
//using (Stream stream = File.Open(fileName, FileMode.Open))
//{
//    BinaryFormatter bin = new BinaryFormatter();
//    m_list = (List<T>)bin.Deserialize(stream);
//}

//}
//catch (Exception ex)
//{

//    //throw ex.FileName + " -" + ex.Message;
//    //throw new System.ArgumentException("something är fel");
//    throw ex;
//}



//public T[] ToStringArray()
//{
//    //Convert List to Array
//    T[] array1 = m_list.ToArray();
//    string strOut;

//    //Displaying the Array Value.
//    foreach (T s in array1)
//    {
//        strOut = String.Format("  ID:{0} }   ", s);
//    }
//    //string strOut = strOut.ToUpper();
//    return strOut;
//}


//public List<T> GetList()
//{
//    return m_list;
//}


//public T[] superRtn()
//{
//    T[] s = m_list.ToArray();

//    return s;
//}

//public T[] superRtn()
//{
//    //Convert List to Array
//    T[] array1 = m_list.ToArray();
//    string strOut;

//    //Displaying the Array Value.
//    foreach (T s in array1)
//    {
//        strOut = String.Format("  ID:{0} }   ", s);
//    }
//    //string strOut = strOut.ToUpper();
//    return strOut;
//}
//public override string ToString()
// {
//    T[] array1 = m_list.ToArray();

//     StringBuilder textOut = new StringBuilder();
//     //textOut.Append("ThisID").Append(" (");
//     textOut.Append(IDTEST).Append(". (");

//     foreach (T s in array1)
//     {
//         IDTEST++;
//         textOut.Append(s).Append(", ");
//     }

//     textOut.Append(")");
//     //remove the last comma 
//     return textOut.ToString().Remove(textOut.ToString().LastIndexOf(","), 1);
// }




//12-01
//public bool BinarySerialize(string filePath)
//{
//    bool bOK = true;
//    FileStream fileObj = null;
//    try
//    {
//        //Steps in serializing an object
//        fileObj = new FileStream(filePath, FileMode.Create);
//        BinaryFormatter binFormatter = new BinaryFormatter();
//        binFormatter.Serialize(fileObj, m_list.GetType());
//    }
//    catch //no parameter - catch avoids exception throwing but no action is taken here 
//    {
//        bOK = false;
//    }
//    finally
//    {
//        if (fileObj != null)
//            fileObj.Close();

//    }
//    return bOK;
//}