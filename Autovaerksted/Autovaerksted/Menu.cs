using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autovaerksted
{
    static class Menu
    {
        #region AddCustomerMenu
        public static void AddCustomerMenu()
        {
            bool repeat;

            do
            {
                Console.Clear();

                Console.Write("Fornavn: ");
                string Firstname = Error_Handler.getStringInput(1,50,true);

                Console.Write("Efternavn: ");
                string Lastname = Error_Handler.getStringInput(1,50,true);

                Console.Write("Adresse: ");
                string CustomerAddress =  Error_Handler.getMixedInput(1,50, "a-zA-z0-9., ");

                Console.Write("Postnr: ");
                int ZipCode = int.Parse( Error_Handler.getNumberInput(4,4,true));

                Console.Write("Email : ");
                string Email =  Error_Handler.getMixedInput(1,255,"a-zA-Z0-9!#$%&'*+-/=?^_`{|}~.@");

                Console.Write("Mobil nummer: ");
                string Mobile = Error_Handler.getStringInput(8,8,true);

                Console.WriteLine("");
                Customers.AddCustomer(Firstname, Lastname, CustomerAddress, ZipCode, Email, Mobile);


                Console.WriteLine("Tilføj en kunde mere? Tryk 1.");
                Console.WriteLine("Gå tilbage til main menu? - Tryk på en anden knap.");
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                }
            }
            while (repeat);
        }
        #endregion

        #region AddCarMenu
        public static void AddCarMenu()
        {
            bool repeat;

            do
            {
                Console.Clear();

                Console.Write("Regnr: ");
                string RegNr = Error_Handler.getMixedInput(9,9,"A-Z0-9");

                Console.Write("Mærke: ");
                string Brand = Error_Handler.getStringInput(1,50,true);

                Console.Write("Model: ");
                string Model = Error_Handler.getMixedInput(1,50,"a-zA-z0-9");

                Console.Write("Årgang: ");
                string CarYear = Error_Handler.getNumberInput(4,4,true);;

                Console.Write("Km: ");
                int Miles = int.Parse(Error_Handler.getNumberInput(1,255, true));

                Console.Write("Brændstoftype : ");
                string EngineType = Error_Handler.getStringInput(1,6,true);

                Console.Write("Kundenummer: ");
                int CustomerId = int.Parse(Error_Handler.getNumberInput(1,255, true));

                Console.WriteLine("");
                Cars.AddCar(RegNr, Brand, Model, CarYear, Miles, EngineType, CustomerId);



                Console.WriteLine("Tilføj en bil mere? Tryk 1.");
                Console.WriteLine("Gå tilbage til main menu? - Tryk på en anden knap.");
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                }
            }
            while (repeat);
        }
        #endregion

        #region DeleteCustomerMenu
        public static void DeleteCustomerMenu()
        {
            Console.WriteLine("Søg efter den kunde du gerne vil slette!");

            if (Customers.ShowCustomerData(Console.ReadLine()) > 0)
            {
                Console.WriteLine("Vælg derefter hvilken en af kunder du vil slette efter kundenummer!");

                Customers.DeleteCustomer(int.Parse(Console.ReadLine()));

                Console.WriteLine("\n");

            }
            else
            {
                Console.WriteLine("ingen kunder");
            }
            Console.WriteLine("Tryk enter for at gå tilbage til menuen!");
            Console.ReadKey();
        }
        #endregion

        #region DeleteCarMenu
        public static void DeleteCarMenu()
        {
            Console.WriteLine("Søg efter den bil du gerne vil slette!");

            if (Cars.ShowCarData(Console.ReadLine()) > 0)
            {
                Console.WriteLine("Vælg derefter hvilken en af bil du vil slette efter regnr!");

                Cars.DeleteCar((Console.ReadLine()));
            }
            else
            {
                Console.WriteLine("ingen biler");
            }
            Console.WriteLine("Tryk enter for at gå tilbage til menuen!");
            Console.ReadKey();
        }
        #endregion

        #region UpdateCarMenu
        public static void UpdateCarMenu()
        {
            bool repeat;

            do
            {
                Console.Clear();

                Console.WriteLine("Hvilken kolonne vil du opdatere?");
                Console.WriteLine("1. Regnr");
                Console.WriteLine("2. Km");
                Console.WriteLine("3. Brændstof");
                Console.WriteLine("4. Kundenummer");

                try
                {
                    //Oversæt brugerens input til en UpdateCarColumn baseret på numerisk værdi eller navn på enum.    true = ignorer store og små bogstaver
                    UpdateCarColumn column = (UpdateCarColumn)Enum.Parse(typeof(UpdateCarColumn), Console.ReadLine(), true);

                    switch (column)
                    {
                        case UpdateCarColumn.RegNr:
                            Console.WriteLine("Indtast gammelt regnr:");
                            string oldReg = Console.ReadLine();

                            Console.WriteLine("Indtast nyt regnr:");
                            string newReg = Error_Handler.getMixedInput(9 ,9, "A-Z0-9");

                            Cars.UpdateCar(oldReg, column, newReg);
                            break;

                        case UpdateCarColumn.CustomerId:
                            Console.WriteLine("Indtast regnr:");
                            string regnr = Error_Handler.getMixedInput(9,9,"A-Z0-9");

                            Console.WriteLine("Indtast nye kundenummer:");
                            string newCustomerId = Error_Handler.getNumberInput(1,255,true);

                            Cars.UpdateCar(regnr, column, newCustomerId);
                            break;

                        case UpdateCarColumn.EngineType:
                            Console.WriteLine("Indtast regnr:");
                            regnr = Error_Handler.getMixedInput(9,9,"A-Z0-9");

                            Console.WriteLine("Indtast nye Brændstoftype");
                            string newCarEngineType = Error_Handler.getStringInput(1,6,true);

                            Cars.UpdateCar(regnr, column, newCarEngineType);

                            break;

                        case UpdateCarColumn.Km:
                            Console.WriteLine("Indtast regnr:");
                            regnr = Error_Handler.getMixedInput(9,9,"A-Z0-9");

                            Console.WriteLine("Indtast nye km");
                            string newCarKm = Error_Handler.getNumberInput(1,255,true);

                            Cars.UpdateCar(regnr, column, newCarKm);
                            break;

                        default:
                            //Vi kommer kun herned, hvis brugeren har indtastet et tal, vi ikke har lavet en enum til
                            throw new Exception();
                    }
                }
                catch
                {
                    Console.WriteLine("Indtast en gyldig værdi");
                    Console.ReadLine();
                    repeat = true;
                    continue;
                }

                Console.WriteLine("Update en bil mere? Tryk 1.");
                Console.WriteLine("Gå tilbage til main menu? - Tryk på en anden knap.");
                ConsoleKeyInfo keyPressed = Console.ReadKey();
                if (keyPressed.Key == ConsoleKey.D1 || keyPressed.Key == ConsoleKey.NumPad1)
                {
                    repeat = true;
                }
                else
                {
                    repeat = false;
                }
            }
            while (repeat);
        }
        #endregion

        #region ShowCustomerMenu
        public static void ShowCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("Søg efter den kunde du gerne vil se!");
            Console.WriteLine("Det er sorteret efter efternavn.");
            Console.WriteLine("Søgekriterier (Efternavn - Bilens egenskaber)");

            string searchString = Console.ReadLine();
            Console.WriteLine();

            if (Customers.ShowCustomerCarData(searchString) <= 0)
            {
                Console.WriteLine("ingen Kunder");
            }

            Console.WriteLine("Tryk enter for at gå tilbage til menuen!");
            Console.ReadKey();
        }
        #endregion

        #region ShowCarMenu
        public static void ShowCarMenu()
        {
            Console.WriteLine("Søg efter den bil du gerne vil se!");

            if (Cars.ShowCarData(Console.ReadLine()) <= 0)
            {
                Console.WriteLine("ingen biler");
            }
           
            Console.WriteLine("Tryk enter for at gå tilbage til menuen!");
            Console.ReadKey();
        }
        #endregion
    }
}
