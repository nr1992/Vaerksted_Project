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
        private const string ConnectionString = "Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True";

        #region AddCustomer
        public static void AddCustomer(string Firstname, string Lastname, string CustomerAddress, int ZipCode, string Email, string Mobile)
        {
            //using sørger for at rydde op efter sig selv, når den ryger ud af using{}
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
        #endregion

        #region DeleteCustomer
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
        #endregion

        #region ShowCustomerData
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
        #endregion

        #region SearchCustomerData
        public static int ShowCustomerData(string searchString)
        {
            //Opbyg sql query
            string cmdStr = $"select * from Customers where Firstname like '%{searchString}%' or Lastname like '%{searchString}%'" +
                $" or CustomerAddress like '%{searchString}%' or ZipCode like '%{searchString}%' or Email like '%{searchString}%'" +
                $" or Mobile like '%{searchString}%'";

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
        #endregion

        #region SearchCustomerCarData
        public static int ShowCustomerCarData(string searchString)
        {
            //Opbyg sql query
            string cmdStr = $"SELECT c.CustomerId, Firstname, Lastname, ZipCode, Email, Mobile, c.CreateDate " +
                $"FROM customers c JOIN Cars ca ON ca.CustomerId = c.CustomerId WHERE ca.RegNr like '%{searchString}%' " + 
                $"or ca.Brand like '%{searchString}%' or ca.Model like '%{searchString}%' or ca.CarYear like '%{searchString}%' or ca.EngineType like '%{searchString}%' or ca.Model like '%{searchString}%' " +
                $"or c.Firstname like '%{searchString}%' or c.Lastname like '%{searchString}%' " +
                $"ORDER BY Lastname";

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
                        while (reader.Read())
                        {
                            PrintRow(reader);
                            Cars.ShowCustomerCars((int)reader.GetValue(0));
                            count++;
                        }

                        return count;
                    }
                }
            }
        }
        #endregion

        private static void PrintRow(SqlDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                Console.WriteLine($"{reader.GetName(i)}: {reader.GetValue(i)}");
            }
            Console.WriteLine();
        }
    }
}
