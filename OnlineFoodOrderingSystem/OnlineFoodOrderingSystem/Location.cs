using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem
{
    public class Location
    {
        public static string GetConnection()
        {
            return @"Data Source=5GWS016;initial catalog=FoodOrder;user id=sa;password=Sql2014";   
        }

        public List<string> GetLocation()
        {
            List<string> name = new List<string>();
            string connection = GetConnection();
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT LOCATION_NAME FROM [FoodOrder].[dbo].[Location] ", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                name.Add(reader.GetString(0));
            }
            reader.Close();
            conn.Close();
            return name;
        }
        public void DisplayLocation(List<string> locationName)
        {
            Console.WriteLine("PLease Enter Ur Current Location\n ");

            int locationCount = 1;

            foreach (var result in locationName)
            {
                Console.WriteLine("\t{0}.) {1}", locationCount, result);
                locationCount++;
            }
        }
    }
}
