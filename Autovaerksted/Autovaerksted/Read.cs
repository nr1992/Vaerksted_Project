using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Autovaerksted
{
    class Read
    {
        public static void ShowCustomerData()
        {
            SqlConnection connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            {
                connection.Open(); using (SqlCommand command = new SqlCommand("SELECT * FROM Kunder", connection))
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
                connection.Open(); using (SqlCommand command = new SqlCommand("select k.kundeid, k.fornavn + ' ' + efternavn as 'Navn', b.Maerke , b.model, b.aargang from kunder AS k join KunderBilerRelation AS kbr ON k.kundeid = kbr.kundeid join biler b ON b.regnr = kbr.regnr", connection))
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
