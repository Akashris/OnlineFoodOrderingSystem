using System;
using System.Collections.Generic;
// System.Data.SqlClient;
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
            int actual = OnlineFoodOrderingSystem.Food.AddFoodPrice(UserRestaurant, User_FoodOrders, _Total_Price);
            Assert.AreEqual(expected, actual);
        }
    }
}
