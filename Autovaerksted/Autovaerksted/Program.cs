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
            //Console.WriteLine("Indtast det KundeId som skal slettes");
            //int i = int.Parse(Console.ReadLine());

            //delete.deletecustomer(i);

            //Read.ShowCustomerCars();

            string Firstname = Console.ReadLine();
            string Lastname = Console.ReadLine();
            string CustomerAddress = Console.ReadLine();
            int ZipCode = int.Parse(Console.ReadLine());
            string Email = Console.ReadLine();
            string Mobile = Console.ReadLine();
            Customers.AddCustomer(Firstname, Lastname, CustomerAddress, ZipCode, Email, Mobile);

            //string Brand = Console.ReadLine();
            //string Model = Console.ReadLine();
            //string CarYear = Console.ReadLine();
            //int Miles = int.Parse(Console.ReadLine());
            //string EngineType = Console.ReadLine();
            //int CustomerId = int.Parse(Console.ReadLine());

            //Cars.AddCar(Brand, Model, CarYear, Miles, EngineType, CustomerId);



            Console.ReadKey();
        }
    }
}
