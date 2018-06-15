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

        public static void DeleteCases(string regNr)
        {
            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd; connection.Close();
            cmd = new SqlCommand("DELETE FROM Cases WHERE RegNr=@i", connection);
            cmd.Parameters.Add("@i", System.Data.SqlDbType.VarChar); cmd.Parameters["@i"].Value = regNr;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
    }
}
