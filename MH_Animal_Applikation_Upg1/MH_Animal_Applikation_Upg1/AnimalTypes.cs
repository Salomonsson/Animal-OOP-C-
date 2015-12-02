using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH_Animal_Applikation_Upg1
{
    [Serializable]
    class AnimalTypes
    {


        public enum MammalsType
        {
            Dog,
            Cat
        }

        public enum AnimalType
        {
            Mammals,
            Bird
        }

        public enum AllAnimalTypes
        {
            Dog,
            Cat,
            Kookaburra,
            Owl
        }

        public enum BirdType
        {
            Kookaburra,
            Owl
        }

        public enum Gender
        {
            Male,
            Female,
            Unknown
        }
    }
}
