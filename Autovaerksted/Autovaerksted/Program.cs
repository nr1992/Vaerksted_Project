using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Autovaerksted
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read.ShowCustomerData();


            //Console.WriteLine("Indtast det KundeId som skal slettes");
            //int i = int.Parse(Console.ReadLine());

            //Delete.DeleteCustomer(i);

            //Read.ShowCustomerCars();

            string Fornavn = Console.ReadLine();
            string Efternavn = Console.ReadLine();
            string Adresse = Console.ReadLine();
            int PostNr = int.Parse(Console.ReadLine());
            string Email = Console.ReadLine();
            string Mobil = Console.ReadLine();

            Create.AddKunde(Fornavn, Efternavn, Adresse, PostNr, Email, Mobil);

            string Maerke = Console.ReadLine();
            string Model = Console.ReadLine();
            string Aargang = Console.ReadLine();
            int Km = int.Parse(Console.ReadLine());
            string Braendstoftype = Console.ReadLine();
            string KundeId = Console.ReadLine();

            Create.AddKunde(Maerke, Model, Aargang, Km, Braendstoftype, KundeId);


            Console.ReadKey();
        }
    }
}
