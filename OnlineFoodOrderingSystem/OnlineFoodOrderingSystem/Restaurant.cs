namespace OnlineFoodOrderingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;


    public class Restaurant
    {
        public List<string> GetRestaurant(string locationName)
        {
            string userLocation = locationName;
            List<string> name = new List<string>();
            string Connection = OnlineFoodOrderingSystem.ConnectionClass.GetConnection();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT RESTAURANT_NAME FROM [FoodOrder].[dbo].[Restaurant] WHERE LOCATION_NAME= '" + userLocation + "' ORDER BY RATING", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\n\t\t\tAVAILABLE RESTAURANTS");
            while (reader.Read())
            {
                name.Add(reader.GetString(0));
            }
            reader.Close();
            conn.Close();
            return name;
        }
        public static List<string> ChooseRestaurant(string userLocation)
        {
            Restaurant res = new Restaurant();
            List<string> restaurantName = res.GetRestaurant(userLocation);

            int restaurantCount = 1;
            Console.WriteLine("\n");
            foreach (var result in restaurantName)
            {
                Console.WriteLine("{0}.) {1}", restaurantCount, result);
                restaurantCount++;
            }
            return restaurantName;

        }
    }
}
