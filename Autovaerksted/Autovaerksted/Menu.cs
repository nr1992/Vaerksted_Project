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
                string Firstname = Console.ReadLine();

                Console.Write("Efternavn: ");
                string Lastname = Console.ReadLine();

                Console.Write("Adresse: ");
                string CustomerAddress = Console.ReadLine();

                Console.Write("Postnr: ");
                int ZipCode = int.Parse(Console.ReadLine());

                Console.Write("Email : ");
                string Email = Console.ReadLine();

                Console.Write("Mobil nummer: ");
                string Mobile = Console.ReadLine();

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
                string RegNr = Console.ReadLine();

                Console.Write("Mærke: ");
                string Brand = Console.ReadLine();

                Console.Write("Model: ");
                string Model = Console.ReadLine();

                Console.Write("Årgang: ");
                string CarYear = Console.ReadLine();

                Console.Write("Km: ");
                int Miles = int.Parse(Console.ReadLine());

                Console.Write("Brændstoftype : ");
                string EngineType = Console.ReadLine();

                Console.Write("Kundenummer: ");
                int CustomerId = int.Parse(Console.ReadLine());

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
                            string newReg = Console.ReadLine();

                            Cars.UpdateCar(oldReg, column, newReg);
                            break;

                        case UpdateCarColumn.CustomerId:
                            Console.WriteLine("Indtast regnr:");
                            string regnr = Console.ReadLine();

                            Console.WriteLine("Indtast nye kundenummer:");
                            string newCustomerId = Console.ReadLine();

                            Cars.UpdateCar(regnr, column, newCustomerId);
                            break;

                        case UpdateCarColumn.EngineType:
                            Console.WriteLine("Indtast regnr:");
                            regnr = Console.ReadLine();

                            Console.WriteLine("Indtast nye Brændstoftype");
                            string newCarEngineType = Console.ReadLine();

                            Cars.UpdateCar(regnr, column, newCarEngineType);

                            break;

                        case UpdateCarColumn.Km:
                            Console.WriteLine("Indtast regnr:");
                            regnr = Console.ReadLine();

                            Console.WriteLine("Indtast nye km");
                            string newCarKm = Console.ReadLine();

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
