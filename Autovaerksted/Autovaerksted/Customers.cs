using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Autovaerksted
{
    class Customers
    {
        //constant kan ikke ændres og giver bedre performance end variabler fordi værdien ikke skal hentes fra memory, men er hard-coded
        private const string ConnectionString = "Server=.\\UV_SERVER_JHC;Database=Autovaerksted; Integrated Security = True";

        public static void AddCustomer(string Firstname, string Lastname, string CustomerAddress, int ZipCode, string Email, string Mobile)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd;
                connection.Open();
                cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Customers (Firstname, Lastname, CustomerAddress, ZipCode, Email, Mobile, CreateDate) values ('" + Firstname + "', '" + Lastname + "', '" + CustomerAddress + "', '" + ZipCode + "', '" + Email + "', '" + Mobile + "', GETDATE())";
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Tilføjede :  \nFornavn:{Firstname} -Efternavn:{Lastname} -Adresse:{CustomerAddress} -Postnr:{ZipCode} -Email:{Email} -Mobilnr:{Mobile}\ntil kunde databasen\n");
            }
        }
        
        public static void DeleteCustomer(int customerId)
        {
            Cars.DeleteCars(customerId);

            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd; connection.Close();

            cmd = new SqlCommand("DELETE FROM Customers WHere CustomerId=@i", connection);
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int); cmd.Parameters["@i"].Value = customerId;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public static void ShowCustomerData()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT * FROM Customers", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PrintRow(reader);
                        }
                    }
                }
            }
        }

        public static int ShowCustomerData(string searchString)
        {
            //Opbyg sql query
            string cmdStr = $"select * from Customers where Firstname like '%{searchString}%' or Lastname like '%{searchString}%'" +
                $" or CustomerAddress like '%{searchString}%' or ZipCode like '%{searchString}%' or Email like '%{searchString}%'" +
                $"or Mobile like '%{searchString}%'";

            //Når man forlader using-blokken rydder den op efter sig selv ved at kalde sin Dispose() metode -> connection.Dispose()
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(cmdStr, connection))
                {
                    //Eksekver sql query
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        //Loop igennem hver række og tæl hvor mange der er
                        int count = 0;
                        while(reader.Read())
                        {
                            PrintRow(reader);
                            count++;
                        }

                        return count;
                    }
                }
            }
        }

        private static void PrintRow(SqlDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine(reader.GetValue(i));
            }
            Console.WriteLine();
        }

        public static void ShowCustomerCars()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
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
