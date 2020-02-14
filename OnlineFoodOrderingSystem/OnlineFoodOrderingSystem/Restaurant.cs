using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem
{
    class Restaurant
    {
        public List<string> GetRestaurant(String LocationName)
        {
            String UserLocation = LocationName;
            List<string> Name = new List<string>();
            string Connection = OnlineFoodOrderingSystem.Location.GetConnection();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT RESTAURANT_NAME FROM [FoodOrder].[dbo].[Restaurant] WHERE LOCATION_NAME= '" + UserLocation+"' ORDER BY RATING", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\n\t\t\tAVAILABLE RESTAURANTS");
            while (reader.Read())
            {
                Name.Add(reader.GetString(0));
            }
            reader.Close();
            conn.Close();
            return Name;
        }
        public static List<string> ChooseRestaurant(string UserLocation)
        {
            Restaurant res = new Restaurant();
            List<string> Restaurant_Name = res.GetRestaurant(UserLocation);

            int restaurant_count = 1;
            Console.WriteLine("\n");
            foreach (var result in Restaurant_Name)
            {
                Console.WriteLine("{0}.) {1}", restaurant_count, result);
                restaurant_count++;
            }
            return Restaurant_Name;

        }
    }
}
