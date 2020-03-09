using System;
using System.Collections.Generic;
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
             string userRestaurant="THE BOWL COMPANY";
             List<string> userFoodOrders=new List<string>() {  "VEG FRIED RICE" };
             int totalPrice = 0, expected=180;
             int actual = OnlineFoodOrderingSystem.Food.FoodPrice(userRestaurant, userFoodOrders, totalPrice);
             Assert.AreEqual(expected, actual);
         }
        public void TestMethod2()
        {
            string UserFood = "PANEER BRIYANI";
            List<string> userFoodOrders = new List<string>();
            List<string> expected = new List<string>() { "PANEER BRIYANI" };
            List<string> actual = new List<string>();
            actual = OnlineFoodOrderingSystem.Ordering.AddOrderItems(UserFood, userFoodOrders);
            CollectionAssert.AreEqual(expected, actual);
        }
        public void TestMethod3()
        {
            string userFood = "VEG FRIED RICE";
            List<string> userFoodOrders = new List<string>() { "PANEER BRIYANI", "VEG FRIED RICE" };
            List<string> expected = new List<string>() { "PANEER BRIYANI"};
            List<string> actual = new List<string>();
            actual = OnlineFoodOrderingSystem.Ordering.RemoveOrderItems(userFoodOrders, userFood);
            CollectionAssert.AreEqual(expected, actual);
        }
        public void TestMethod4()
        {
            List<string> paymentType = new List<string>() { "Online Payment", "Cash On Delivery" };
            string expected = "Online Payment";
            Payment obj = new Payment();
            string actual = obj.get_PaymentMethod(paymentType, 1);
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod5()
        {
            List<string> paymentType = new List<string>() { "Online Payment", "Cash On Delivery" };
            string expected = "Cash On Delivery";
            Payment obj = new Payment();
            string actual = obj.get_PaymentMethod(paymentType, 21);
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod6()
        {  
            int totalPrice = 100, foodPrice = 180;
            int expected = 280;
            int actual = OnlineFoodOrderingSystem.Food.CalculateTotalPrice(foodPrice, totalPrice);
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod7()
        {
            int totalPrice = 100, tempPrice = 80;
            int expected = 20;
            int actual = OnlineFoodOrderingSystem.Food.ReduceFoodPrice(tempPrice, totalPrice);
            Assert.AreEqual(expected, actual);
        }
        public void TestMethod8()
        {
            Location loc = new Location();
            List<string> actual = loc.GetLocation();
            List<string> expected = new List<string>() { "KILPAUK", "ANNA NAGAR" };
            CollectionAssert.AreEqual(expected, actual);
        }
        public void TestMethod9()
        {
            Restaurant res = new Restaurant();
            List<string> expected = res.GetRestaurant("KILPAUK");
            List<string> actual = new List<string>() {  "RED BOX","THE BOWL COMPANY", "THICKSHAKE FACTORY","McDONALDS" };
            CollectionAssert.AreEqual(expected, actual);
        }
        public void TestMethod10()
        {
            Restaurant res = new Restaurant();
            List<string> expected = res.GetRestaurant("ANNA NAGAR");
            List<string> actual = new List<string>() { "THE LUNCH BOX", "KFC", "KIM LING", "KEVENTERS" };
            CollectionAssert.AreEqual(expected, actual);
        }
        public void TestMethod11()
        {
            Food foo = new Food();
            List<string> expected = foo.GetFood("THE LUNCH BOX");
            List<string> actual = new List<string>() { "VEG BRIYANI", "PANEER FRIED RICE", "PANEER TIKKA"};
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
