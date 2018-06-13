using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Autovaerksted
{
    class Customers
    {
        public static void AddCustomer(string Fornavn, string Efternavn, string Adresse, int PostNr, string Email, string Mobil)
        {
            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand(); cmd.CommandText = "INSERT INTO Kunder(Fornavn, Efternavn, Adresse, PostNr, Email, Mobil) values('" + Fornavn + "', '" + Efternavn + "', '" + Adresse + "', '" + PostNr + "', '" + Email + "', '" + Mobil + "');";
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Tilføjede {Fornavn} {Efternavn} {Adresse} {PostNr} {Email} {Mobil} til kunde databasen");
                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }
        
        public static void DeleteCustomer(int i)
        {
            DeleteCars(i);


            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd; connection.Close();

            cmd = new SqlCommand("DELETE FROM Kunder WHere KundeId=@i", connection);
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int); cmd.Parameters["@i"].Value = i;
            connection.Open();
            int slettet = cmd.ExecuteNonQuery();
            if (slettet > 0)
            {
                Console.WriteLine("Slettet - TRYK enter.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Ikke fundet - TRYK enter"); Console.ReadKey();
            }
            connection.Close();
        }

        public static void ShowCustomerData()
        {
            SqlConnection connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            {
                connection.Open(); using (SqlCommand command = new SqlCommand("SELECT * FROM Kunder", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            { Console.WriteLine(reader.GetValue(i)); }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        public static void ShowCustomerCars()
        {
            SqlConnection connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            {
                connection.Open(); using (SqlCommand command = new SqlCommand("select k.kundeid, k.fornavn + ' ' + efternavn as 'Navn', b.Maerke , b.model, b.aargang from kunder AS k join KunderBilerRelation AS kbr ON k.kundeid = kbr.kundeid join biler b ON b.regnr = kbr.regnr", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            { Console.WriteLine(reader.GetValue(i)); }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

    }
}
