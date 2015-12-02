using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MH_Animal_Applikation_Upg1
{
    public partial class RecipeForm : Form
    {

        private Recipe m_recipe;
        protected string name;


       // public Recipe testMatreceot = null;
        //public Recipe testMatreceot = new Recipe();
        public RecipeManager rcpMngr = null;


        public RecipeForm()
        {
            InitializeComponent();
            if (m_recipe == null)
            {
                m_recipe = new Recipe();
            }

            rcpMngr = new RecipeManager();

            //Instantiate som test value
            textBoxNameFood.Text = "Pankaka";
            textBoxNameIngred.Text = "2 Ägg";
        }

        public Recipe Recepie
        {
            get {return m_recipe;}
            set { m_recipe = value; }
        }

        private void buttonAddIngredient_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBoxNameIngred.Focus();

            bool validInput = false;
            //Check valid nA
            CheckValidName(out validInput);



            if (validInput == true)
            {
                m_recipe.Name = textBoxNameFood.Text;
                m_recipe.Ingredients.Add(textBoxNameIngred.Text);


                if (m_recipe.Name != null)
                {
                    //Add to the recepie Manager
                     rcpMngr.Add(m_recipe);
                }

                //foreach (string item in rcpMngr.ToStringList())
                //{
                //    listBox1.Items.Add(item);
                //}
                foreach (var item in m_recipe.Ingredients)
                {
                    //Listbox 1 meta information about object
                    listBox1.Items.Add(item);
                }
            }

            textBoxNameIngred.Text = "";
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {

            //Denna fungera inte, har testat lite olika ting
            if (this.m_recipe == null)
            {
                MessageBox.Show("Går det igenom?");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
            //MessageBox.Show("Går det igenom?");
            //if (String.IsNullOrEmpty(textBoxNameFood.Text))
            //{
            //    this.Close();
            //}
            //this.DialogResult = DialogResult.OK;
            
        }



        /// <summary>
        /// Check the if the input string for name is valid. 
        /// Multiple checking with -
        /// -TrimFunction
        /// -Regex library, search special characters
        /// -NullOrEmpty
        /// -Bool if textbox value is integer, then false
        /// -IsNullOrWhiteSpace, for empty spaces
        /// </summary>
        /// <param name="successtest"></param>
        /// <returns></returns>
        private string CheckValidName(out bool successtest)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            string name = "";
            string input = textBoxNameFood.Text;


            int checkForNumber = 0;

            bool boolValue = int.TryParse(textBoxNameFood.Text, out checkForNumber);
            //Check if the string is empty or null || income is integer.....
            if (String.IsNullOrEmpty(input) || boolValue)
            {
                successtest = false;
                MessageBox.Show("Objektet måste ha ett namn. INGA SIFFROR!");
            }
            //check the regex for special charachters, || just spaces not aloud.
            else if (!regexItem.IsMatch(input) || string.IsNullOrWhiteSpace(input))
            {
                successtest = false;
                MessageBox.Show("No special characters or empty spaces!");
            }
            else
            {
                //Set true
                name = input.TrimStart();
                successtest = true;
                //return name;
            }

            //successtest = false;
            //return name;
            return name;
        }


    }
}
