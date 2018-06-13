using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Autovaerksted
{
    class Customers
    {
        public static void AddCustomer(string Firstname, string Lastname, string CustomerAddress, int ZipCode, string Email, string Mobile, DateTime CreateDate)
        {
            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand(); cmd.CommandText = "INSERT INTO Customers(Firstname, Lastname, CustomerAddress, ZipCode, Email, Mobile, CreateDate) values('" + Firstname + "', '" + Lastname + "', '" + CustomerAddress + "', '" + ZipCode + "', '" + Email + "', '" + Mobile + "', '" + CreateDate + "');";
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Tilføjede {Firstname} {Lastname} {CustomerAddress} {ZipCode} {Email} {Mobile} til kunde databasen");
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
            Cars.DeleteCars(i);


            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd; connection.Close();

            cmd = new SqlCommand("DELETE FROM Customers WHere CustomerId=@i", connection);
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
                connection.Open(); using (SqlCommand command = new SqlCommand("SELECT * FROM Customers", connection))
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
                connection.Open(); using (SqlCommand command = new SqlCommand("select k.CustomerId, k.Firstname + ' ' + Lastname as 'Navn', b.Brand , b.model, b.CarYear from Customers AS k join Cars b ON b.CustomerId = k.CustomerId", connection))
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
