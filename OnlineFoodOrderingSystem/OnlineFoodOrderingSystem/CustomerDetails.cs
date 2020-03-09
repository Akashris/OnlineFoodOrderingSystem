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
        public string customer_Name;
        public int customer_Feedback;

        public void SetName(string customerName)
        {
            customer_Name = customerName;
        }
        public string getName()
        {
            return customer_Name;
        }
        public void SetFeedback(int customerFeedback)
        {
            customer_Feedback = customerFeedback;
        }

        public int getFeedback()
        {
            return customer_Feedback;
        }

        public void AddCustomerDetailsInDatabase(List<CustomerDetails> customerDetailList, string locationName, string userRestaurant, List<string> userFoodOrders, int totalPrice, string userPaymentMethod)
        {
            string Connection = OnlineFoodOrderingSystem.Location.GetConnection();
            SqlConnection conn = new SqlConnection(Connection);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Customer_Details (CUSTOMER_NAME,CUSTOMER_FEEDBACK,LOCATION_NAME,RESTAURANT_NAME,FOOD_NAME,FOOD_PRICE,PAYMENT_METHOD) VALUES('" + getName()+ "','" + getFeedback() + "','" + locationName + "','"+userRestaurant+ "','"+string.Join(",",userFoodOrders)+ "'," + totalPrice+ ",'" + userPaymentMethod + "')", conn);
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
