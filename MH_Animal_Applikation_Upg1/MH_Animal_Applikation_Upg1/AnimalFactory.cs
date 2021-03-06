﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MH_Animal_Applikation_Upg1.Animals;

namespace MH_Animal_Applikation_Upg1
{
    [Serializable]
    class AnimalFactory
    {
        /// <summary>
        /// Decides which class to instantiate.
        /// </summary>
        public static Animal GetMammal(string type)
        {
            Animal obj = null;
            switch (type)
            {
                case "Dog":
                    obj = new Dog();
                    break;
                case "Cat":
                    obj = new Cat();
                    break;
                default:
                    break;
            }
            return obj;
        }

        public static Animal GetInsect(string type)
        {
            Animal obj = null;
            switch (type)
            {
                case "Kookaburra":
                    obj = new Kookaburra();
                    break;
                case "Owl":
                    obj = new Owl();
                    break;
                default:
                    break;
            }
            return obj;
        }
    }
}
