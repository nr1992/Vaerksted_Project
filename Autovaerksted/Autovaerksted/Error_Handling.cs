﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Autovaerksted
{
    public class Error_Handling
    {
        //Handler for letters only input
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
        //Handler for numbers only input
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

        public static string getAddressInput(int minCharacters, int maxCharacters)
        {
            //object that takes input from the keyboard
            string StringToTest = "";

            bool inputNotGood = true;

            string pattern = @"^([A-Za-z0-9,. ])+$";
            Regex Address = new Regex(pattern);

            while (inputNotGood)
            {
                //reads line from keyboard and puts in "StringToTest"

                StringToTest = Console.ReadLine();

                if (StringToTest.Length <= maxCharacters && StringToTest.Length >= minCharacters)
                {
                    //input still good
                    inputNotGood = false;
                }

                if (Address.IsMatch(StringToTest))
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

        public static string getEmailInput(int minCharacters, int maxCharacters)
        {
            //object that takes input from the keyboard
            string StringToTest = "";

            bool inputNotGood = true;

            string pattern = @"^([A-Za-z0-9.!#$%&'*+-/=?^_`{|}~@])+$";
            Regex Address = new Regex(pattern);

            while (inputNotGood)
            {
                //reads line from keyboard and puts in "StringToTest"

                StringToTest = Console.ReadLine();

                if (StringToTest.Length <= maxCharacters && StringToTest.Length >= minCharacters)
                {
                    //input still good
                    inputNotGood = false;
                }

                if (Address.IsMatch(StringToTest))
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
    }
}