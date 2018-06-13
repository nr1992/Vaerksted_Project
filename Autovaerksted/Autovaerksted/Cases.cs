using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Autovaerksted
{
    class Cases
    {
        //Der mangler en editor. Hvad skal den kunne?

        public static void AddCase(int CaseNr, DateTime StartDate, DateTime EndDate, string RegNr)
        {
            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand(); cmd.CommandText = "INSERT INTO Cases(CaseNr, StartDate, EndDate, RegNr) values('" + CaseNr + "', '" + StartDate + "', '" + EndDate + "', '" + RegNr + "');";
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Tilføjede {CaseNr} {StartDate} {EndDate} {RegNr} til kunde databasen");
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

        public static void DeleteCase(int i)
        {
            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd; connection.Close();
            cmd = new SqlCommand("DELETE FROM Cases WHERE CaseNr=@i", connection);
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
