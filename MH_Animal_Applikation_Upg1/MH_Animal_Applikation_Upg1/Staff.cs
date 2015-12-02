using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1
{
     [Serializable]
    public class Staff
    {

         //name of a staffs
        private string s_name;
        public string result;
        //List of skills
        private List<string> s_skills = new List<string>();
        //public ListManager<string> s_skills;

        public Staff()
        {
            //s_skills = new ListManager<string>();
        }


        /// <summary>
        /// Name of the Employed.
        /// </summary>
        /// <value>Name of the empleeyy to be set.</value>
        /// <returns>Return the name of the Employeer.</returns>
        /// <remarks></remarks>
        public string Name
        {
            get { return s_name; }
            set { s_name = value; }
        }



        //Property
        //public List<string> Skills
        //{
        //    get { return s_skills; }
        //    set { s_skills = value; }
        //}
        public List<string> Skills
        {
            get { return s_skills; }
            set { s_skills = value; }
        }



        /// <summary>
        /// Override ToString function - let it return a string made up of
        /// the name and ingredients
        /// </summary>
        /// <returns>The object in printable format</returns>
        public override string ToString()
        {
            string staff_rslt = Name + " ";
            foreach (string s in this.Skills)
            {

                staff_rslt += s + ", ";
            }

            return staff_rslt;
        }

    }
}
