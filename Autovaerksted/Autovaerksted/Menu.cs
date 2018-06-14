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
        
        public static void DeleteCustomerMenu()
        {
            Console.WriteLine("Søg efter den kunde du gerne vil slette!");

            if (Customers.ShowCustomerData(Console.ReadLine()) > 0)
            {
                Console.WriteLine("Vælg derefter hvilken en af kunder du vil slette efter kundenummer!");

                Customers.DeleteCustomer(int.Parse(Console.ReadLine()));
            }
            else
            {
                Console.WriteLine("ingen kunder");
            }
            Console.ReadKey();
        }
    }
}
