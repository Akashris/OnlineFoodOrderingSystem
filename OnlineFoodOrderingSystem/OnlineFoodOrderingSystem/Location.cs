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
            List<string> Name = new List<string>();
            string connection = GetConnection();
            SqlConnection conn = new SqlConnection(connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT LOCATION_NAME FROM [FoodOrder].[dbo].[Location] ", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {     
                Name.Add(reader.GetString(0));
            }
            reader.Close();
            conn.Close();
            return Name;
        }
        public void DisplayLocation(List<string> Location_name)
        {

            Console.WriteLine("PLease Enter Ur Current Location\n ");

            int location_count = 1;

            foreach (var result in Location_name)
            {
                Console.WriteLine("\t{0}.) {1}", location_count, result);
                location_count++;
            }
        }
    }
}
