using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Autovaerksted
{
    class Cars
    {
        //constant kan ikke ændres og giver bedre performance end variabler fordi værdien ikke skal hentes fra memory, men er hard-coded
        private const string ConnectionString = "Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True";

        #region AddCar
        public static void AddCar(string RegNr, string Brand, string Model, string CarYear, int Miles, string EngineType, int CustomerId)
        {
            var connection = new SqlConnection(ConnectionString);
            SqlCommand cmd;
            connection.Open();
            cmd = connection.CreateCommand(); cmd.CommandText = "INSERT INTO Cars(RegNr,Brand, Model, CarYear, Miles, EngineType, CustomerId, CreateDate) values('" + RegNr + "', '" + Brand + "', '" + Model + "', '" + CarYear + "', '" + Miles + "', '" + EngineType + "', '" + CustomerId + "', GETDATE());";
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Tilføjede : \nRegnr:{RegNr} -Mærke :{Brand} -Model :{Model} -Årgang :{CarYear} -Km :{Miles} -Brændstoftype :{EngineType} -Kundenr :{CustomerId} til bil databasen");
        }
        #endregion

        #region DeleteCars
        public static void DeleteCars(int customerId)
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand($"select RegNr from Cars where CustomerId = '{customerId}'", connection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                //For hver af kundens biler, skal vi slette alle cases
                while (reader.Read())
                {
                    //Hiv column nr 0 (RegNr) ud fra nuværende row
                    Cases.DeleteCases(reader.GetValue(0).ToString());
                }
            }


            cmd = new SqlCommand("DELETE FROM Cars WHere CustomerId=@i", connection);
            cmd.Parameters.Add("@i", System.Data.SqlDbType.Int); cmd.Parameters["@i"].Value = customerId;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        #endregion

        #region DeleteCar
        public static void DeleteCar(string Regnr)
        {
            //Tjekker om der er nogle cases på den specifike RegNr
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            SqlCommand cmd = new SqlCommand($"select c.RegNr from Cars AS c join Customers k ON k.CustomerId = c.CustomerId WHERE RegNr = '{Regnr}'", connection);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    //Hiv column nr 0 (RegNr) ud fra nuværende row
                    Cases.DeleteCases(reader.GetValue(0).ToString());
                }
            }


            cmd = new SqlCommand("DELETE FROM Cars WHere RegNr=@i", connection);
            cmd.Parameters.Add("@i", System.Data.SqlDbType.VarChar); cmd.Parameters["@i"].Value = Regnr;
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        #endregion

        #region UpdateCar

        public static void UpdateCar(string regNr, UpdateCarColumn column, string newValue)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command;

                switch(column)
                {
                    #region UpdateCarReg
                    case UpdateCarColumn.RegNr:
                        try
                        {
                            //Deaktiver checket på FK constraint
                            command = new SqlCommand("alter table Cases nocheck constraint Regnr_FK", connection);
                            command.ExecuteNonQuery();

                            command = new SqlCommand($"update Cars set RegNr = '{newValue}' where RegNr = '{regNr}'", connection);

                            //Tjek om bilens regnr blev ændret
                            if (command.ExecuteNonQuery() > 0)
                            {
                                command = new SqlCommand($"update Cases set RegNr = '{newValue}' where RegNr = '{regNr}'", connection);
                                command.ExecuteNonQuery();
                            }
                        }
                        catch { Console.WriteLine("Der opstod en fejl, og regnr blev ikke opdateret!"); }

                        //Aktiver checket på Regnr_FK igen
                        command = new SqlCommand("alter table Cases check constraint Regnr_FK", connection);
                        command.ExecuteNonQuery();

                        break;
                    #endregion

                    #region UpdatecarCustomerId
                    case UpdateCarColumn.CustomerId:
                        try
                        {
                            command = new SqlCommand($"update Cars set CustomerId = '{newValue}' where RegNr = '{regNr}'", connection);

                            //Tjek antal rows påvirket af query
                            if (command.ExecuteNonQuery() > 0)
                            {
                                Console.WriteLine("Kundenummer opdateret");
                            }
                            else
                            {
                                Console.WriteLine("Der findes ingen biler med dette regnr");
                            }
                        }
                        //Her rammer vi bl.a. hvis kundenummeret ikke findes
                        catch { Console.WriteLine("Der opstod en fejl, og kundenummeret blev ikke opdateret!"); }

                        break;
                    #endregion

                    #region UpdateCarEngineType
                    case UpdateCarColumn.EngineType:
                        try
                        {
                            command = new SqlCommand($"update Cars set EngineType = '{newValue}' where RegNr = '{regNr}'", connection);

                            //Tjek antal rows påvirket af query
                            if (command.ExecuteNonQuery() > 0)
                            {
                                Console.WriteLine("Brændstoftype opdateret");
                            }
                            else
                            {
                                Console.WriteLine("Der findes ingen biler med dette regnr");
                            }
                        }
                        catch { Console.WriteLine("Der opstod en fejl, og brændstoftypen blev ikke opdateret!"); }
                        break;
                    #endregion

                    #region UpdateCarKm
                    case UpdateCarColumn.Km:
                        try
                        {
                            command = new SqlCommand($"update Cars set Miles = '{newValue}' where RegNr = '{regNr}'", connection);

                            //Tjek antal rows påvirket af query
                            if (command.ExecuteNonQuery() > 0)
                            {
                                Console.WriteLine("Brændstoftype opdateret");
                            }
                            else
                            {
                                Console.WriteLine("Der findes ingen biler med dette regnr");
                            }
                        }
                        catch { Console.WriteLine("Der opstod en fejl, og Km blev ikke opdateret!"); }
                        break;
                        #endregion
                }
            }
        }

        #endregion

        #region ShowCustomerCars
        public static void ShowCustomerCars(int customerId)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand($"select * from cars where CustomerId = {customerId}", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                PrintRow(reader);
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }
        #endregion

        #region SearchCarData
        public static int ShowCarData(string searchString)
        {
            //Opbyg sql query
            string cmdStr = $"select * from Cars where RegNr like '%{searchString}%' or Brand like '%{searchString}%'" +
                $" or Model like '%{searchString}%' or CarYear like '%{searchString}%' or EngineType like '%{searchString}%'" +
                $"or CustomerId like '%{searchString}%'";

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
