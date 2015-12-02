using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH_Animal_Applikation_Upg1.Animals;
using System.Collections;

namespace MH_Animal_Applikation_Upg1
{
    public class AnimalManager : ListManager<Animal>
    {


        private int setID = 0;

        //Konstruktor - skapa objekten som ingår som variabler 
        /// <summary>
        /// Default constructor - create the Animal list
        /// </summary>
        public AnimalManager()
        {
           
        }

        /// <summary>
        /// Add the animal object to listmanagaer. And use listmanagars full potential
        /// </summary>
        /// <param name="an">type of object</param>
        public void AddAnimal(Animal an)
        {
            an.Id = setID++;
            this.Add(an);
        }

    }
}





//
/// <summary>
/// Get one element from list
/// 
/// Two ways:
/// 1. Return the element directly (the reference returned)
/// 
/// return estatList[index];  - Dangerous as any later change will also
/// affect my list
/// 2. return a (deep copy) element
/// </summary>
/// <param name="index"></param>
/// <returns></returns>
//public Animal GetElementAtPosition(int index)
//{

//    //We choose to return a copy, why do we need type casting when copying?
//    if (IsIndexValid(index))
//    {

//        if (m_list[index] is Dog)
//            return new Dog((Dog)m_list[index]);
//        if (m_list[index] is Cat)
//            return new Cat((Cat)m_list[index]);
//        if (m_list[index] is Kookaburra)
//            return new Kookaburra((Kookaburra)m_list[index]);
//        if (m_list[index] is Owl)
//            return new Owl((Owl)m_list[index]);
//        //if (animalArrayList[index] is Bee)
//        //    return new Bee((Bee)animalArrayList[index]);
//        else
//            return null;
//    }
//    else
//        return null;
//}


/// <summary>
/// A list shall not be able to be indexed out of bounds.
/// This method can be used from different places to ensure 
/// correct indexing.
/// </summary>
/// <param name="index"></param>
/// <returns></returns>
//public bool IsIndexValid(int index)
//{
//    return ((index >= 0) && (index < m_list.Count));
//}