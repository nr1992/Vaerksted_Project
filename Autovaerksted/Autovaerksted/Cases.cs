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
        public static void AddCase(string RegNr)
        {
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd;
            connection.Open();
            cmd = connection.CreateCommand(); cmd.CommandText = "INSERT INTO Cases(StartDate, RegNr) values( GETDATE(), '" + RegNr + "');";
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Tilføjede {RegNr} til  databasen d. {DateTime.Now}");
            Console.ReadKey();
        }
        #endregion

        #region DeleteCases
        public static void DeleteCases(string CaseNr)
        {
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd; connection.Close();
            cmd = new SqlCommand("DELETE FROM Cases WHERE CaseNr=@i", connection);
            cmd.Parameters.Add("@i", System.Data.SqlDbType.VarChar); cmd.Parameters["@i"].Value = CaseNr;
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        #endregion

        #region SearchCaseData
        public static int ShowCaseData(string searchString)
        {
            //Opbyg sql query
            string cmdStr = $"select * from Case where RegNr like '%{searchString}%' or EndDate like '%{searchString}%'" +
                $" or StartDate like '%{searchString}%' or CaseNr like '%{searchString}%'";

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
                //Kolonnens navn: Kolonnens værdi
                Console.WriteLine($"{reader.GetName(i)}: {reader.GetValue(i)}");
            }
            Console.WriteLine();
        }
    }
}
