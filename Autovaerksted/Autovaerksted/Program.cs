using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace Autovaerksted
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                //Slet teskt fra forrige menu
                Console.Clear();

                Console.WriteLine("Velkommen til Autoværkstedet!");
                Console.WriteLine("Hvad vil du gøre?\n");
                Console.WriteLine("1. Tilføj Kunde");
                Console.WriteLine("2. Slet Kunde");
                Console.WriteLine("3. Tilføj Bil");

                string UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "1":
                        Menu.AddCustomerMenu();
                        break;

                    case "2":
                        Menu.DeleteCustomerMenu();
                        break;

                    case "3":
                        Menu.AddCarMenu();
                        break;

                    default:
                        Console.WriteLine("Forkert, ugyldigt valg");
                        Console.ReadKey();
                        continue;
                }
            }

        }
    }
}
