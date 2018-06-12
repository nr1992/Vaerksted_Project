using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Autovaerksted
{
    class Create
    {
        public static void AddKunde(string Fornavn, string Efternavn, string Adresse, int PostNr, string Email, string Mobil)
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

        public static void AddCar(string Maerke, string Model, string Aargang, int Km, string Braendstoftype, int KundeId)
        {
            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand(); cmd.CommandText = "INSERT INTO Kunder(Fornavn, Efternavn, Adresse, PostNr, Email, Mobil) values('" + Maerke + "', '" + Model + "', '" + Aargang + "', '" + Km + "', '" + Braendstoftype + "', '" + KundeId + "');";
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Tilføjede {Maerke} {Model} {Aargang} {Km} {Braendstoftype} {KundeId} til kunde databasen");
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
    }
}
