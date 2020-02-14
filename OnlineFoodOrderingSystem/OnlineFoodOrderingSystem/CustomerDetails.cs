using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem
{
    class CustomerDetails
    {
        public string Customer_Name;
        public int Customer_Feedback;

        public void SetName(string CustomerName)
        {
            Customer_Name = CustomerName;
        }
        public string getName()
        {
            return Customer_Name;
        }
        public void SetFeedback(int CustomerFeedback)
        {
            Customer_Feedback = CustomerFeedback;
        }

        public int getFeedback()
        {
            return Customer_Feedback;
        }

        public void Add_Customer_Details_In_Database(List<CustomerDetails> customerDetail_List, string LocationName, string UserRestaurant, List<string> User_FoodOrders, int _Total_Price, string UserPaymentMethod)
        {
            string Connection = OnlineFoodOrderingSystem.Location.GetConnection();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customer_Details (CUSTOMER_NAME,CUSTOMER_FEEDBACK,LOCATION_NAME,RESTAURANT_NAME,FOOD_NAME,FOOD_PRICE,PAYMENT_METHOD) VALUES('" + getName()+ "','" + getFeedback() + "','" + LocationName+ "','"+UserRestaurant+ "','"+string.Join(",",User_FoodOrders)+ "'," + _Total_Price+ ",'" + UserPaymentMethod + "')", conn);
            int i = cmd.ExecuteNonQuery();
            while (i!=0)
            {
                Console.WriteLine("\n\t\t\t\t\tORDER PLACED SUCESSFULLY");
                break;
            }
            conn.Close();
 
        }
    }
}
