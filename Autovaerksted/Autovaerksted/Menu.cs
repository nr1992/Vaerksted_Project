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
                string CustomerAddress = Console.ReadLine(); //Skal have en custom errorhandler (bogstaver, tal, mellemrum, tegn)

                Console.Write("Postnr: "); //Crasher hvis der ikke er et input
                int ZipCode = int.Parse(Error_Handling.getNumberInput(4, 4, true));

                Console.Write("Email : "); 
                string Email = Console.ReadLine(); //Skal have en custom errorhandler (bogstaver, tegn, tal)

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
    }
}
