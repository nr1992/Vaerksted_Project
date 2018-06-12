using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Autovaerksted
{
    class Delete
    {
        public static void DeleteCustomer(int i)
        {
            DeleteCars(i);


            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd; connection.Close();

            cmd = new SqlCommand("DELETE FROM Kunder WHere KundeId=@i", connection);
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

        public static void DeleteCars(int i)
        {
            var connection = new SqlConnection("Server=.\\MSSQL_SCHOOLPRAC;Database=Autovaerksted; Integrated Security = True");
            SqlCommand cmd; connection.Close();
            cmd = new SqlCommand("DELETE FROM Biler WHere KundeId=@i", connection);
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
