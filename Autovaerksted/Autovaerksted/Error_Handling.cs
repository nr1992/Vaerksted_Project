using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autovaerksted
{
    public class Error_Handling
    {
        //add handler for letters only input
        public static string getStringInput(int minCharacters, int maxCharacters, bool OnlyLetters)
        {
            //object that takes input from the keyboard
            string StringToTest = "";

            bool inputNotGood = true;

            while (inputNotGood)
            {
                //reads line from keyboard and puts in "StringToTest"

                StringToTest = Console.ReadLine(); //Kan efterlades blank (fix?)


                if (StringToTest.Length <= maxCharacters && StringToTest.Length >= minCharacters)
                {
                    //input still good
                    inputNotGood = false;
                }

                if (StringToTest.All(Char.IsLetter) == OnlyLetters)
                {
                    inputNotGood = false;
                }

                else
                {
                    Console.Write("Fejl. Prøv igen: ");
                    inputNotGood = true;
                }
            }
            return StringToTest;


        }
        //add handler for numbers only input
        public static string getNumberInput(int minCharacters, int maxCharacters, bool OnlyNumbers)
        {
            //object that takes input from the keyboard
            string StringToTest = "";

            bool inputNotGood = true;

            while (inputNotGood)
            {
                //reads line from keyboard and puts in "StringToTest"

                StringToTest = Console.ReadLine(); //Kan efterlades blank (fix?)


                if (StringToTest.Length <= maxCharacters && StringToTest.Length >= minCharacters)
                {
                    //input still good
                    inputNotGood = false;
                }

                if (StringToTest.All(Char.IsNumber) == OnlyNumbers)
                {
                    inputNotGood = false;
                }

                else
                {
                    Console.Write("Fejl. Prøv igen: ");
                    inputNotGood = true;
                }
            }
            return StringToTest;
            //add handler for mixed input?

        }
    }
}
