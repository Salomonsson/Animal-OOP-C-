using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MH_Animal_Applikation_Upg1.Animals;
using System.Text.RegularExpressions;

namespace MH_Animal_Applikation_Upg1
{
    public partial class Form1 : Form
    {
        //Cheat counter. 
       // public int testCounter = 1;

        //Instantiate animalmanager. 
        private AnimalManager animalMngr = null;  //ref variable declared
        //Food schedule instans behövs inte, den instnsieras i animal klassen? men egentligen inte. uhm.
       // FoodSchedule instanceFoodSchedule = new FoodSchedule();

        //ListManager<AnimalManager> animalMngr = null;
        //public Recipe testMatreceot = null;

        //public Recipe testMatreceot = new Recipe();
        public RecipeManager rcpMngr = new RecipeManager();
        public StaffManager stfMngr = new StaffManager();
        

        public Form1()
        {
            InitializeComponent();

            //Initializations
            InitializeGUI();

            //rcpMngr = new RecipeManager();
            //AnimalManager
            animalMngr = new AnimalManager();
            //instanceFoodSchedule = new FoodSchedule();
            //animalMngr = new ListManager<AnimalManager>();
           
          
        }


        //private string xmlFileName = Application.StartupPath + "\\TestPerson.xml"; //(file for testing xml
        //private string fileName = Application.StartupPath + "\\TestPerson.dat"; //file at Application directory



        /// <summary>
        /// Prepare the form before display
        /// Initiate input controls with default values
        /// Remove design values from output controls (label1 ex.)
        /// </summary>
        private void InitializeGUI()
        {
            //Clear output controls
            textBoxName.Text = "Beijo";
            textBoxAge.Text = "12";
            textBoxNoTeeth.Text = "20";
            textBoxTailLength.Text = "15,8";

            listBoxGender.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.Gender)));
            //set male as default
            listBoxGender.SelectedIndex = (int)AnimalTypes.Gender.Male;
            listBoxCategories.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.AnimalType)));
            listBoxCategories.SelectedIndex = (int)AnimalTypes.MammalsType.Dog;
            
        }



        #region Validation REGION
        /// <summary>
        /// Validation of Tail-length, Age, Number of teeths, speed of bird and Name of the object. 
        /// </summary>
        /// 
        

        /// <summary>
        /// Four methods to check valid income data. Integer for Age and Teeth. Double for Tail-length and Speed.
        /// </summary>
        /// <param name="success">Success =  user input is valid.</param>
        /// <returns>state of object which is true.</returns>
        private double CheckTailLength(out bool success)
        {
            double tailLength = 0;

            success = double.TryParse(textBoxTailLength.Text, out tailLength);


            if (!success || tailLength < 0)
            {
                MessageBox.Show("The entered tail length is not valid!");
                success = false;
            }


            return tailLength;
        }
        private int CheckAge(out bool success)
        {
            int age = 0;

            success = int.TryParse(textBoxAge.Text, out age);


            if (!success || (age <= 0))
            {
                success = false;
                MessageBox.Show("The entered age is not valid, the input must be an integer!");
                
            }

            return age;
        }
        private int CheckTeeth(out bool success)
        {
            int teeth = 0;
            success = int.TryParse(textBoxNoTeeth.Text, out teeth);

            if (teeth < 0 || !success)
            {
                MessageBox.Show("The entered teeth is not valid!");
                success = false;
            }

            return teeth;
        }
        private double CheckSpeed(out bool success)
        {
            double speed = 0;
            success = double.TryParse(textBoxSpeed.Text, out speed);

            if (speed < 0 || !success)
            {
                MessageBox.Show("The entered speed of the bird is not valid!");
                success = false;
            }

            return speed;
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
            string input = textBoxName.Text;
                

            int checkForNumber = 0;

            bool boolValue = int.TryParse(textBoxName.Text, out checkForNumber);
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
            }
                    
        //Wont work. uhm?
           // name = input.TrimStart();

            return name;


                //int checkForNumber = 0;
                //bool boolValue = int.TryParse(textBoxName.Text, out checkForNumber);
                ////Check if the string is empty or null.....
                //if (String.IsNullOrEmpty(textBoxName.Text) || boolValue)
                //{ 
                //    validInput = false;
                //    MessageBox.Show("Objektet måste ha ett namn. INGA SIFFROR!");
                //}


                //var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

                //if (!regexItem.IsMatch(input))
                //{
                //    validInput = false;
                //    MessageBox.Show("No special characters!");
                //}


                //int checkForNumber = 0;
                //bool boolValue = int.TryParse(textBoxName.Text, out checkForNumber);
                ////Check if the string is empty or null.....
                //if (String.IsNullOrEmpty(textBoxName.Text) || boolValue)
                //{
                //    validInput = false;
                //    MessageBox.Show("Objektet måste ha ett namn. INGA SIFFROR!");
                //}
        }

        #endregion



        private void AddAnimalBtn_Click(object sender, EventArgs e)
        {
            //Update Food schema listan.
            listBoxFood.Items.Clear();


            //boolValue, just for checking. 
            bool validInput = false;
            bool validAge = false;

            //Check valid nA
            CheckValidName(out validInput);
            CheckAge(out validAge);


            if (validAge && validInput)  //If all common data (in variable estate) is OK
            {
                //Check if valid input for teeth textbox
                bool validNrTeeth = false;

                switch ((AnimalTypes.AnimalType)listBoxCategories.SelectedIndex)
                {
                    case AnimalTypes.AnimalType.Mammals:
                        {
                            //Check if the input is valid or not!
                            bool validTail = false;
                            CheckTeeth(out validNrTeeth);
                            CheckTailLength(out validTail);

                            //If number of teeth and tail length is valid.Then create object
                            if (validNrTeeth && validTail)
                            {
                                AnimalTypes.MammalsType mammalObj = (AnimalTypes.MammalsType)Enum.Parse(typeof(AnimalTypes.MammalsType), listBoxAnimalObject.Text);
                                Animal instanceAnimal = AnimalFactory.GetMammal(mammalObj.ToString());

                                
                                //Late Binding                                
                                instanceAnimal.Name = textBoxName.Text;
                                //The id is set in the manager class.
                                //instanceAnimal.Id = animalMngr.Count;
                                instanceAnimal.Age = int.Parse(textBoxAge.Text);
                                instanceAnimal.Gender = listBoxGender.Text;

                                //Vilket är bäst??
                                instanceAnimal.teeth = int.Parse(textBoxNoTeeth.Text);
                                //instanceAnimal.teeth = CheckTeeth(out validNrTeeth);

                                instanceAnimal.tail = double.Parse(textBoxTailLength.Text);
                                //animalMngr.Add(instanceAnimal);
                                //Add the object to list animalmanager, which in function adds to listmanager.
                                animalMngr.AddAnimal(instanceAnimal);


                                //Set the label for which type of animal eater to nothing
                                label14.Text = "";

                                //..Use the converted choosen enum objekt. IN THE SAME TIME ADD IT TO LIST ARRAY!
                                //This means less code. 
                                //animalMngr.Add(AnimalFactory.GetMammal(mammalObj.ToString(), animalObject));

                            }
              

                            break;
                        }
                    case AnimalTypes.AnimalType.Bird:
                        {
                            bool validSpeed = false;
                            
                            //Add speed to object.
                            CheckSpeed(out validSpeed);
                            CheckTeeth(out validNrTeeth);

                            //If number of teeth and tail length is valid.Then create object
                            if (validNrTeeth && validSpeed)
                            {
                                //--Get choosen value from enum. And convert it
                                AnimalTypes.BirdType insectObj = (AnimalTypes.BirdType)Enum.Parse(typeof(AnimalTypes.BirdType), listBoxAnimalObject.Text);
                                Animal instanceAnimal = AnimalFactory.GetInsect(insectObj.ToString());

                                //Late binding
                                instanceAnimal.Name = textBoxName.Text;
                                //The id is set in the manager class.
                                //instanceAnimal.Id = animalMngr.Count;
                                instanceAnimal.Age = int.Parse(textBoxAge.Text);
                                instanceAnimal.Gender = listBoxGender.Text;

                                
                                instanceAnimal.teeth = int.Parse(textBoxNoTeeth.Text);
                                //instanceAnimal.teeth = CheckTeeth(out validNrTeeth);

                                instanceAnimal.speed = double.Parse(textBoxSpeed.Text);
                               
                                //animalMngr.Add(instanceAnimal);
                                animalMngr.AddAnimal(instanceAnimal);

                                //Set the label for which type of animal eater to nothing
                                label14.Text = "";
                            }
                            break;
                        }
                }


                lstResults.Items.Clear();
                //Then Update the GUI
                //UpdateResults();

                //Denna fungerar ypperligt! MEN jag gillar inte loop här! 
                //Add the created animal to list. 
                // this means, just updating GUI
                foreach (string item in animalMngr.ToStringArray())
                {
                    lstResults.Items.Add(item);
                }


            }
        }


        /// <summary>
        /// Reset result list and fill in with new values
        /// </summary>
        private void UpdateResults()
        {
           lstResults.Items.Clear();  //Erase current list
           listBoxMetaInfo.Items.Clear(); //Erase current MetaInfo list (Recept and staffs)
           
            //Loop out current Animals in the animal list.
           foreach (var item in animalMngr.ToStringList())
           {
               lstResults.Items.Add(item);
           }

           
           listBoxMetaInfo.Items.Add("Food Recepi");
           //Loop out current recepts in the rcpMngr list.
           foreach (var item in rcpMngr.ToStringArray())
           {
               //Loop out the converted array
               listBoxMetaInfo.Items.Add(item);
           }

           listBoxMetaInfo.Items.Add(" - - - - - - - ");

           //Loop out current staffs in the staff list.
           listBoxMetaInfo.Items.Add("Staffs");
           foreach (var item in stfMngr.ToStringArray())
           {
               //Loop thourgh the converted array in listmanager
               listBoxMetaInfo.Items.Add(item);
           }  
        }



        //Not in use
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }










        /// <summary>
        /// listbox for animal categories.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxCategories_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listBoxCategories.SelectedIndex == (int)AnimalTypes.AnimalType.Mammals)
            {

                textBoxTailLength.Text = "12,35";
                textBoxTailLength.ReadOnly = false;
                textBoxSpeed.ReadOnly = true;
                textBoxSpeed.Text = null;

                listBoxAnimalObject.Items.Clear();
                // Fill the combobox with values from enum
                listBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.MammalsType)));
                //Make this readonly
                //Make cat as default.
                listBoxAnimalObject.SelectedIndex = (int)AnimalTypes.MammalsType.Cat; 
            }
            if (listBoxCategories.SelectedIndex == (int)AnimalTypes.AnimalType.Bird)
            {
                textBoxTailLength.Text = null;
                textBoxTailLength.ReadOnly = true;
                textBoxSpeed.ReadOnly = false;
                textBoxSpeed.Text = "2,8";

                //Clear the listbox
                listBoxAnimalObject.Items.Clear();
                //cmbTyp.Items.AddRange(Enum.GetNames(typeof(EstateTypes.InsectsType)));
                listBoxAnimalObject.Items.AddRange(Enum.GetNames(typeof(AnimalTypes.BirdType)));
                //Make Kookaburra as default.
                listBoxAnimalObject.SelectedIndex = (int)AnimalTypes.BirdType.Kookaburra; 
            }
        }










        #region Not In Use
        private void textBoxTailLength_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewFoodSchedule_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxFood_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion








        /// <summary>
        /// Selected animal in animal list has different food schedules. 
        /// Food schedule is choosen by object type
        /// </summary>
        private void lstResults_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstResults.SelectedIndex >= 0) // skall ju endast göra något OM något djur är markerat, är inget markerat är index -1
            {

                listBoxFood.Items.Clear();
                    //Get animal from AnimalManager, get the species of selected item
                string getAnimal = animalMngr.GetAt(lstResults.SelectedIndex).GetSpecies();
           
                    //Get the type of the Animal
                AnimalTypes.AllAnimalTypes getObj = (AnimalTypes.AllAnimalTypes)Enum.Parse(typeof(AnimalTypes.AllAnimalTypes), getAnimal);
                 //listBoxFood.Items.Add(mammalObj); //Bra testare.

                Animal AnimalObj = null;
                switch ((AnimalTypes.AllAnimalTypes)getObj)
                {
                    case AnimalTypes.AllAnimalTypes.Cat:
                        AnimalObj = AnimalFactory.GetMammal(getObj.ToString());
                            break;

                    case AnimalTypes.AllAnimalTypes.Dog:
                            AnimalObj = AnimalFactory.GetMammal(getObj.ToString());
                            break;

                    case AnimalTypes.AllAnimalTypes.Kookaburra:
                            AnimalObj = AnimalFactory.GetInsect(getObj.ToString());
                            break;

                    case AnimalTypes.AllAnimalTypes.Owl:
                            AnimalObj = AnimalFactory.GetInsect(getObj.ToString());
                            break;  
                    }

            
                string strOut = String.Format("  Matschema för: {0}", AnimalObj.GetSpecies());
                listBoxFood.Items.Add(strOut);
                foreach (string obj in AnimalObj.GetFoodschedule().GetList())
                {
                    listBoxFood.Items.Add(obj); // överför strängarna till listan
                }

                  //label14.Text = animalMngr.GetElementAtPosition(lstResults.SelectedIndex).IsGoodFor(); // överför eatertype till label (döp om till lblEaterType)
                 label14.Text = animalMngr.GetAt(lstResults.SelectedIndex).IsGoodFor();
            }
        }







        #region Add staff and recipes REGION
        private void buttonAddStaff_Click(object sender, EventArgs e)
        {
            FormAddStaff formStaff = new FormAddStaff();

            if (formStaff.ShowDialog() == DialogResult.OK)
            {
                listBoxMetaInfo.Items.Clear();
                //Staff personal = staffMngr.GetAt(0);
                stfMngr.Add(formStaff.Staff);

                UpdateResults();

            }
        }

        private void buttonAddFood_Click(object sender, EventArgs e)
        {
            RecipeForm formRecipe = new RecipeForm();
            if (formRecipe.ShowDialog() == DialogResult.OK)
            {
                //Add to listManager
                rcpMngr.Add(formRecipe.Recepie);
                //Update the meta info box
                UpdateResults();
            }
        }

        #endregion








        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (lstResults.SelectedIndex >= 0) // skall ju endast göra något OM något djur är markerat, är inget markerat är index -1
            {
                //Get id as a local variables.
                string getName = animalMngr.GetAt(lstResults.SelectedIndex).Name;
                string getGender = animalMngr.GetAt(lstResults.SelectedIndex).Gender;
                string getAnimal = animalMngr.GetAt(lstResults.SelectedIndex).GetSpecies();

                DialogResult result2 = MessageBox.Show("Vill du ta bort följande objekt?? " +
                    Environment.NewLine + "Namn:" + getName + " Kön:" + getGender + " Typ av Djur:" + getAnimal,
                "Delete",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question);

                if (result2 == DialogResult.Yes)
                {
                    //remove from listManager.
                    animalMngr.DeleteAt(lstResults.SelectedIndex);

                    //If animal is deleted, then update the result list of animals.
                    UpdateResults();

                }
                else if (result2 == DialogResult.No)
                {
                    //do something else
                }

            }
        }










        #region XML SECTION
        /// <summary>
        /// mnyFileExportXML == Serialisering
        /// </summary>
        private void mnyFileExportXML_Click(object sender, EventArgs e)
        {
            //Local or global??
            string xmlFileStaff = Application.StartupPath + "\\Staff.xml";
            string xmlFileRecipe = Application.StartupPath + "\\Recipe.xml";

            //txt msg 
            string strMessage = string.Format("{0} NÅGOT BLEV FEL. ERROR. ", xmlFileRecipe);

            //Instantiate XML serializer for staff and recept.
            if (rcpMngr.XMLSerialize(xmlFileRecipe) && stfMngr.XMLSerialize(xmlFileStaff))
            {
                strMessage = string.Format("Du har lagrat staff och recept till fil.");
            }

            MessageBox.Show(strMessage);
        }



        /// <summary>
        /// mnuFileImportXML_Click == Deserialisering
        /// </summary>
        private void mnuFileImportXML_Click(object sender, EventArgs e)
        {

            //filepath
            string xmlFileStaff = Application.StartupPath + "\\Staff.xml";
            string xmlFileRecipe = Application.StartupPath + "\\Recipe.xml";

            //Deserialisera staff från fil (hämta från fil)
            stfMngr.XMLDeserialize(xmlFileStaff);
            rcpMngr.XMLDeserialize(xmlFileRecipe);

            //Update the meta info box
            UpdateResults();
        }

        #endregion  //END  -  XML SECTION








        public string definedPath;//This defined path which is already in use/selected
        /// <summary>
        /// OPEN FILE.
        /// Open selected file. 
        /// 
        /// Remember: public variable definedPatg contains the path for file, if its empty then open 
        /// and select new file.
        /// </summary>
        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1 = new OpenFileDialog();
            //public OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = @"C:\";
            openFileDialog1.Title = "Browse Text Files";

            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            openFileDialog1.DefaultExt = "txt";
            openFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;



            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //MessageBox.Show(openFileDialog1.FileName);
                //DeSerrialize Binary
                try
                {
                    bool checker;
                    //animalMngr.BinaryDeSerialize("test.bin");
                    checker = animalMngr.BinaryDeSerialize(openFileDialog1.FileName);

                    //MessageBox.Show(checker.ToString());

                    if (checker != true)
                    {
                        MessageBox.Show("Filen laddades inte.");
                    }
                    UpdateResults();

                    definedPath = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }
            }
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    System.IO.StreamReader sr = new
            //       System.IO.StreamReader(openFileDialog1.FileName);
            //    MessageBox.Show(sr.ReadToEnd());
            //    sr.Close();
            //}
        }









        /// <summary>
        /// Menu Save File AS..
        /// Override selected new item. 
        /// </summary>
        private void mnuFileSaveAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = @"C:\";
            saveFileDialog1.Title = "Save text Files";
            saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;


            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    bool checker;
                    //select path for binary serialize by save file dialog.
                    checker = animalMngr.BinarySerialize(saveFileDialog1.FileName);
                    if (checker != false)
                    {
                       // MessageBox.Show(checker.ToString());
                        MessageBox.Show("Du har sparat ner til fil.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());

                }

            }
        }

        
        /// <summary>
        /// Menu save file, 
        /// If user has already set value to variable definedPath, then save to some location. 
        /// else save to new dialog.
        /// //public string saveLink = Application.StartupPath + definedPath;
        /// </summary>
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            //If path is already seleected, then save to the same path.
            if (definedPath != null)
            {
                MessageBox.Show("{0} Du har sparat till fil:-> " + definedPath);
                animalMngr.BinarySerialize(definedPath);
            }
            else
            {
                 MessageBox.Show("Path is missing, select new path to save file.");

                 SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                 saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                 saveFileDialog1.FilterIndex = 2;
                 saveFileDialog1.RestoreDirectory = true;

                 if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                 {
                     try
                     {
                         MessageBox.Show(saveFileDialog1.FileName);
                         animalMngr.BinarySerialize(saveFileDialog1.FileName);
                     }
                     catch (Exception ex)
                     {
                         MessageBox.Show(ex.ToString());

                     }


                 }

            }

        }//END Method - mnuFileSave_Click




    }// END - public partial class Form1 : Form
}//END - Namespace




















// SOME CODE IS HARD TO LET GO OFF. BEAUTY WILL BE MISSED.

/// <summary>
/// Hämata data från GUI, fyll i ett lokalt object av animal
/// för att senare skickas till animalMngr
/// </summary>
/// <param name="animalObj"></param>
/// <returns></returns>
//private bool UserInput(out Animal animalObj)
//{
//    //Create a local Animal instance for filling in input
//    animalObj = new Animal();
//    //Animal te = null;

//    //Animal objects is saved to an arraylist, here is one of the few times i tried to loop out
//    //each objekt for counting them. This without success. 
//    //foreach (var item in animalMngr.animalArrayList)
//    //{
//    //   testCounter++;

//    //}


//    //<>Here is plenty more tries to get the count of object correct. this still fails since it starts
//    //with 0, my testCounter gives correct results but it's ugly coding, -> DISLIKE!
//    //animalObj.id = animalMngr.objCount;
//    //animalObj.id = testCounter++;  //Works perfectly, but beautiful code is what i want. 
//    //animalObj.id = testCounter;
//    animalObj.Id = animalMngr.ElementCount;
//    //animalMngr.countId(animalMngr.animalArrayList);
//    //animalObj.id = animalMngr.countId(animalMngr.animalArrayList);
//    //animalObj.id = animalMngr.ElementCount;


//    //Check the users input if its valid by boolean. False -> not valid, true ->Valid
//    bool validAge = false;
//    //Check valid integer
//    //methods are for checking int value from the textboxes.
//    animalObj.Age = CheckAge(out validAge);
//    animalObj.Gender = listBoxGender.Text;



//    //int checkForNumber = 0;
//    //bool boolValue = int.TryParse(textBoxName.Text, out checkForNumber);
//    ////Check if the string is empty or null.....
//    //if (String.IsNullOrEmpty(textBoxName.Text) || boolValue)
//    //{ 
//    //    validInput = false;
//    //    MessageBox.Show("Objektet måste ha ett namn. INGA SIFFROR!");
//    //}
//    //Get the user input from textboxes

//    //Function of check valid income.
//    //boolValue, just for checking. 
//    bool validInput = false;
//    string boolValue = CheckForInt(out validInput);
//    animalObj.Name = boolValue;

//    //BIG PROBLEM:!
//    // I want my class Mammals and Bird to get data, this without success. I have to have public variables
//    //in my baseclass (Animal), this is bad. Big dislike. 
//    //I also instantiate this ones in the button method. 
//    //::::
//    //((Mammals)animalObj).Teeth = CheckTeeth(out prisOK);
//    //((Mammals)animalObj).Teeth = int.Parse(textBoxNoTeeth.Text);
//    //int x  = CheckTeeth(out prisOK);
//    //((Mammals)animalObj).teeth = x;


//    //return true or false depending on user input. 
//    //If both valid name and age ok, return true


//    return validInput && validAge;
//}