using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autovaerksted
{
    static class Menu
    {
        public static void AddCustomerMenu()
        {
            bool repeat;
            
            do
            {
                Console.Clear();
                
                Console.Write("Fornavn: ");
                string Firstname = Error_Handling.getStringInput(1, 50, true);

                Console.Write("Efternavn: "); 
                string Lastname = Error_Handling.getStringInput(1, 50, true);

                Console.Write("Adresse: ");
                string CustomerAddress = Error_Handling.getMixedInput(1, 50, "[A-Za-z0-9,. ]");

                Console.Write("Postnr: "); 
                int ZipCode = int.Parse(Error_Handling.getNumberInput(4, 4, true));

                Console.Write("Email : ");
                string Email = Error_Handling.getMixedInput(1, 255, "[A-Za-z0-9.!#$%&'*+-/=?^_`{|}~@");

                Console.Write("Mobil nummer: ");
                string Mobile = Error_Handling.getNumberInput(8, 8, true);

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
        
        public static void DeleteCustomerMenu()
        {
            Console.WriteLine("Søg efter den kunde du gerne vil slette!"); //hvad søges der på?

            if (Customers.ShowCustomerData(Console.ReadLine()) > 0)
            {
                Console.WriteLine("Vælg derefter hvilken kunde du vil slette efter kundenummer!");

                Customers.DeleteCustomer(int.Parse(Console.ReadLine())); //crasher hvis der ikke er et input.
            }
            else
            {
                Console.WriteLine("ingen kunder");
            }
            Console.ReadKey();
        }

        public static void AddCarMenu()
        {
            bool repeat;
            
            do
            {
                Console.Clear();

                //RegNr mangler fra al kode. Med vilje?

                Console.Write("Mærke: ");
                string Brand = Error_Handling.getStringInput(1, 50, true);

                Console.Write("Model: ");
                string Model = Error_Handling.getMixedInput(1, 50, "a-zA-Z0-9");

                Console.Write("Produktionsår: ");
                string CarYear = Error_Handling.getNumberInput(4, 4, true);

                Console.Write("Kilometer: ");
                int Miles = int.Parse(Error_Handling.getNumberInput(0, 255, true));

                Console.Write("Brændstofstype : ");
                string EngineType = Error_Handling.getStringInput(0, 6, true);

                Console.Write("Ejer (Kunde ID): ");
                int CustomerId = int.Parse(Error_Handling.getNumberInput(0, 255, true));

                Console.WriteLine("");
                Cars.AddCar(Brand, Model, CarYear, Miles, EngineType, CustomerId);


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

        //SKal rettes til
        public static void DeleteCarMenu()
        {
            Console.WriteLine("Søg efter den bil du gerne vil slette!"); //hvad søges der på?
            
            if (Cars. (Console.ReadLine()) > 0)//create method for carsdata
            {
                Console.WriteLine("Vælg derefter hvilken bil du vil slette efter kundenummer!");

                Cars.DeleteCars(int.Parse(Console.ReadLine())); //crasher hvis der ikke er et input.
            }
            else
            {
                Console.WriteLine("ingen kunder");
            }
            Console.ReadKey();
        }
    }
}
