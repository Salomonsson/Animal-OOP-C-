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
    public partial class FormAddStaff : Form
    {
        private Staff m_staff;
        protected string name;


        // public Recipe testMatreceot = null;
        //public Recipe testMatreceot = new Recipe();
        public StaffManager staffMngr = null;

        public FormAddStaff()
        {
            InitializeComponent();
            if (m_staff == null)
            {
                m_staff = new Staff();
            }

            staffMngr = new StaffManager();

            //Instantiate som test-value
            textBoxNameStaff.Text = "APU";
            textBoxStaffQualification.Text = "Chief";
        }

        public Staff Staff
        {
            get { return m_staff; }
            //set { m_staff = value; }
        }


        private void button4_Click(object sender, EventArgs e)
        {

            //Denna fungera inte, har testat lite olika ting, uhm... Challenge accepted..
            if (this.m_staff == null)
            {
                MessageBox.Show("Går det igenom?");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void buttonStaffQualitication_Click(object sender, EventArgs e)
        {
             listBox1.Items.Clear();
             
             textBoxStaffQualification.Focus();

            bool validInput = false;
            //Check valid nA
            CheckValidName(out validInput);

           

            if (validInput == true)
            {
                m_staff.Name = textBoxNameStaff.Text;
                m_staff.Skills.Add(textBoxStaffQualification.Text);
                
                foreach (var item in m_staff.Skills)
                {
                    listBox1.Items.Add(item);
                }

            }

            textBoxStaffQualification.Text = "";
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
            string input = textBoxNameStaff.Text;


            int checkForNumber = 0;

            bool boolValue = int.TryParse(textBoxNameStaff.Text, out checkForNumber);
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
