using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem
{
    public class Food
    {
        public List<string> GetFood(String RestaurantName)
        {
            String UserRestaurant = RestaurantName;
            List<string> Name = new List<string>();
            string Connection = OnlineFoodOrderingSystem.Location.GetConnection();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT FOOD_NAME FROM [FoodOrder].[dbo].[Food] WHERE RESTAURANT_NAME= '" + UserRestaurant + "'ORDER BY FOOD_NAME", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            Console.WriteLine("\n\t\t\tThe MENU \n");
            while (reader.Read())
            {
                Name.Add(reader.GetString(0));
            }
            reader.Close();
            conn.Close();
            return Name;
        }

        public static int AddFoodPrice(string UserRestaurant, List<string> User_FoodOrders, int _Total_Price)
        {

            string Connection = OnlineFoodOrderingSystem.Location.GetConnection();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT FOOD_PRICE FROM [FoodOrder].[dbo].[Food] WHERE RESTAURANT_NAME='" + UserRestaurant + "' AND FOOD_NAME='" + User_FoodOrders[User_FoodOrders.Count - 1] + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            _Total_Price = _Total_Price + reader.GetInt32(0);
            reader.Close();
            conn.Close();
            return _Total_Price;
        }

        public static int ReduceFoodPrice(string UserRestaurant, List<string> User_FoodOrders, int _Total_Price)
        {
            int _Delete_Price, Temp_Price = 0;
            string Connection = OnlineFoodOrderingSystem.Location.GetConnection();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            foreach (var result in User_FoodOrders)
            {
                SqlCommand cmd = new SqlCommand("SELECT FOOD_PRICE FROM [FoodOrder].[dbo].[Food] WHERE RESTAURANT_NAME='" + UserRestaurant + "' AND FOOD_NAME='" + result + "'", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Temp_Price = Temp_Price + reader.GetInt32(0);
                reader.Close();
            }
            _Delete_Price = _Total_Price - Temp_Price;
            _Total_Price = _Total_Price - _Delete_Price;
            conn.Close();
            return _Total_Price;
        }
    }
}
