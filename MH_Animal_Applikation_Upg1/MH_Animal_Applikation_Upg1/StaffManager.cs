using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1
{
     //[Serializable]
    public class StaffManager : ListManager<Staff>
    {
        //public int IDTEST = 1;
         //[Serializable]
        public StaffManager()
        {

        }

        /// <summary>
        ///Format a string with values from this estate.
        ///Note that data for the address object is fetched from the
        ///address-object belonging to this estate.
        /// </summary>
        /// <returns>The formatted string.</returns>
        //public override string ToString()
        //{
        //    string strOut = String.Format("  ID:{0}, Namn: {1}, Ålder:{2}, Kön: {3}   ", Id, Name, Age, Gender);

        //    strOut = strOut.ToUpper();
        //    return strOut;
        //}
    }
}
