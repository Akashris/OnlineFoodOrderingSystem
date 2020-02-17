using System;
using System.Collections.Generic;s
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OnlineFoodOrderingSystem;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
       public void TestMethod1()
        {
            string UserRestaurant="RED BOX";
            List<string> User_FoodOrders=new List<string>() {  "VEG FRIED RICE" };
            int _Total_Price=0, expected=180;
            int actual = OnlineFoodOrderingSystem.Food.FoodPrice(UserRestaurant, User_FoodOrders, _Total_Price);
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod2()
        {
            string UserFood = "PANEER BRIYANI";
            List<string> User_FoodOrders = new List<string>();
            List<string> expected = new List<string>() { "PANEER BRIYANI" };
            List<string> actual = new List<string>();
            actual = OnlineFoodOrderingSystem.Ordering.AddOrderItems(UserFood, User_FoodOrders);
            CollectionAssert.AreEqual(expected, actual);
        }
        public void TestMethod3()
        {
            string UserFood = "VEG FRIED RICE";
            List<string> User_FoodOrders = new List<string>() { "PANEER BRIYANI", "VEG FRIED RICE" };
            List<string> expected = new List<string>() { "PANEER BRIYANI"};
            List<string> actual = new List<string>();
            actual = OnlineFoodOrderingSystem.Ordering.RemoveOrderItems(User_FoodOrders,UserFood);
            CollectionAssert.AreEqual(expected, actual);
        }
        public void TestMethod4()
        {
            List<string> Payment_Type = new List<string>() { "Online Payment", "Cash On Delivery" };
            string expected = "Online Payment";
            Payment obj = new Payment();
            string actual = obj.get_PaymentMethod(Payment_Type, 1);
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod5()
        {
            List<string> Payment_Type = new List<string>() { "Online Payment", "Cash On Delivery" };
            string expected = "Cash On Delivery";
            Payment obj = new Payment();
            string actual = obj.get_PaymentMethod(Payment_Type, 21);
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod6()
        {  
            int _Total_Price = 100, Food_Price = 180;
            int expected = 280;
            int actual = OnlineFoodOrderingSystem.Food.CalculateTotalPrice(Food_Price, _Total_Price);
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod7()
        {
            int _Total_Price = 100, Temp_price = 80;
            int expected = 20;
            int actual = OnlineFoodOrderingSystem.Food.ReduceFoodPrice(Temp_price, _Total_Price);
            Assert.AreEqual(expected, actual);
        }
    }
}
