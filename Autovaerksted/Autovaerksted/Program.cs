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

                string UserChoice = Console.ReadLine();

                switch (UserChoice)
                {
                    case "1":
                        Menu.AddCustomerMenu();
                        break;

                    case "2":
                        Menu.DeleteCustomerMenu();
                        break;

                    default:
                        Console.WriteLine("Forkert, ugyldigt valg");
                        Console.ReadKey();
                        continue;
                }
            }


            //Console.WriteLine("Indtast det KundeId som skal slettes");
            //int i = int.Parse(Console.ReadLine());

            //delete.deletecustomer(i);

            //Read.ShowCustomerCars();


            //string Brand = Console.ReadLine();
            //string Model = Console.ReadLine();
            //string CarYear = Console.ReadLine();
            //int Miles = int.Parse(Console.ReadLine());
            //string EngineType = Console.ReadLine();
            //int CustomerId = int.Parse(Console.ReadLine());

            //Cars.AddCar(Brand, Model, CarYear, Miles, EngineType, CustomerId);

        }
    }
}
