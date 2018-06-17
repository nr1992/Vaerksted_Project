using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Autovaerksted
{
    class Cases
    {
        //constant kan ikke ændres og giver bedre performance end variabler fordi værdien ikke skal hentes fra memory, men er hard-coded
        private const string ConnectionString = "Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True";

        #region AddCase
        public static void AddCase(int CaseNr, DateTime StartDate, DateTime EndDate, string RegNr)
        {
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd;
            connection.Open();
            cmd = connection.CreateCommand(); cmd.CommandText = "INSERT INTO Cases(CaseNr, StartDate, EndDate, RegNr) values('" + CaseNr + "', '" + StartDate + "', '" + EndDate + "', '" + RegNr + "');";
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Tilføjede {CaseNr} {StartDate} {EndDate} {RegNr} til kunde databasen");
            Console.ReadKey();
        }
        #endregion

        #region DeleteCases
        public static void DeleteCases(string regNr)
        {
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd; connection.Close();
            cmd = new SqlCommand("DELETE FROM Cases WHERE RegNr=@i", connection);
            cmd.Parameters.Add("@i", System.Data.SqlDbType.VarChar); cmd.Parameters["@i"].Value = regNr;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        #endregion
    }
}
