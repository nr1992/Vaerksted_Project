using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Autovaerksted
{
    class Cars
    {
        public static void AddCar(string Brand, string Model, string CarYear, int Miles, string EngineType, int CustomerId)
        {
            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand(); cmd.CommandText = "INSERT INTO Cars(Brand, Model, CarYear, Miles, EngineType, CustomerId) values('" + Brand + "', '" + Model + "', '" + CarYear + "', '" + Miles + "', '" + EngineType + "', '" + CustomerId + "');";
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Tilføjede {Brand} {Model} {CarYear} {Miles} {EngineType} {CustomerId} til kunde databasen");
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

        public static void DeleteCars(int i)
        {
            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd; connection.Close();
            cmd = new SqlCommand("DELETE FROM Cars WHere CustomerId=@i", connection);
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
    }
}
