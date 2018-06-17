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
                Console.WriteLine("2. Tilføj Biler");
                Console.WriteLine("3. Slet Kunde");
                Console.WriteLine("4. Slet Bil");
                Console.WriteLine("5. Opdater Bil");
                Console.WriteLine("6. Vis Kundeoversigt");
                Console.WriteLine("7. Vis Bil");



                string UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "1":
                        Menu.AddCustomerMenu();
                        break;

                    case "2":
                        Menu.AddCarMenu();
                        break;

                    case "3":
                        Menu.DeleteCustomerMenu();
                        break;

                    case "4":
                        Menu.DeleteCarMenu();
                        break;

                    case "5":
                        Menu.UpdateCarMenu();
                        break;

                    case "6":
                        Menu.ShowCustomerMenu();
                        break;

                    case "7":
                        Menu.ShowCarMenu();
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
