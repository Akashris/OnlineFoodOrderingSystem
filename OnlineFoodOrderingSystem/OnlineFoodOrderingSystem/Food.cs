namespace OnlineFoodOrderingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;


    public class Food
    {
        public List<string> GetFood(String restaurantName)
        {
            String userRestaurant = restaurantName;
            List<string> name = new List<string>();
            string Connection = OnlineFoodOrderingSystem.ConnectionClass.GetConnection();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT FOOD_NAME FROM [FoodOrder].[dbo].[Food] WHERE RESTAURANT_NAME= '" + userRestaurant + "'ORDER BY FOOD_NAME", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\n\t\t\tThe MENU \n");
            while (reader.Read())
            {
                name.Add(reader.GetString(0));
            }
            reader.Close();
            conn.Close();
            return name;
        }

        public static int FoodPrice(string userRestaurant, List<string> userFoodOrders, int totalPrice)
        {

            string Connection = OnlineFoodOrderingSystem.ConnectionClass.GetConnection();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT FOOD_PRICE FROM [FoodOrder].[dbo].[Food] WHERE RESTAURANT_NAME='" + userRestaurant + "' AND FOOD_NAME='" + userFoodOrders[userFoodOrders.Count - 1] + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            int foodPrice = reader.GetInt32(0);
            reader.Close();
            conn.Close();
            return foodPrice;
        }
        public static int CalculateTotalPrice(int foodPrice, int totalPrice)
        {
            totalPrice = totalPrice + foodPrice;
            return totalPrice;
        }

        public static int CalculateReduceFoodPrice(string userRestaurant, List<string> userFoodOrders, int totalPrice)
        {
            int tempPrice = 0;
            string Connection = OnlineFoodOrderingSystem.ConnectionClass.GetConnection();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            foreach (var result in userFoodOrders)
            {
                SqlCommand cmd = new SqlCommand("SELECT FOOD_PRICE FROM [FoodOrder].[dbo].[Food] WHERE RESTAURANT_NAME='" + userRestaurant + "' AND FOOD_NAME='" + result + "'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                tempPrice = tempPrice + reader.GetInt32(0);
                reader.Close();

            }
            conn.Close();
            return tempPrice;
        }

        public static int ReduceFoodPrice(int tempPrice, int totalPrice)
        {
            int deletePrice = totalPrice - tempPrice;
            totalPrice = totalPrice - deletePrice;
            return totalPrice;
        }
    }
}
