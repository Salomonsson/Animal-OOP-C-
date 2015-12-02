using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1
{

    [Serializable]
    public class Recipe
    {

        //name of a food item
        private string m_name;
        //List<string> list = new List<string>();
        private int IDm = 0;

        

        //List of ingredients
        private List<string> m_ingredients = new List<string>();
        //private ListManager<string> m_ingredients = new ListManager<string>();
        //private List<string> m_ingredients;

        public Recipe()
        {
            //m_ingredients = new ListManager<string>();
        }


        /// <summary>
        /// Name of the food.
        /// </summary>
        /// <value>Name of the food to be set.</value>
        /// <returns>Return the name of the food.</returns>
        /// <remarks></remarks>
        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }



        //Property related to m_ingredients
        public List<string> Ingredients
        {
            get { return m_ingredients; }
            set { m_ingredients = value; }
        }


        /// <summary>
        /// Override ToString function - let it return a string made up of
        /// the name and ingredients
        /// </summary>
        /// <returns>The object in printable format</returns>
        public override string ToString()
        {
            string recipe_rslt = Name + " - ";

            foreach (string s in this.Ingredients)
            {
                recipe_rslt += s + ", ";
            }
            return recipe_rslt;
        }

    }
}
