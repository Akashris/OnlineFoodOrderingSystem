namespace OnlineFoodOrderingSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class Ordering
    {
        public static List<string> DisplayOrderItems(string userRestaurant, List<string> userFoodOrders, int totalPrice)
        {
            Food foodObj = new Food();
            List<string> foodName = foodObj.GetFood(userRestaurant);

            int foodCount = 1;
            foreach (var result in foodName)
            {
                Console.WriteLine("{0}.) {1}", foodCount, result);
                foodCount++;
            }
            return foodName;
        }

        public static List<string> AddOrderItems(string userFood, List<string> userFoodOrders)
        {
            userFoodOrders.Add(userFood);

            return userFoodOrders;
        }

        public static List<string> DisplayDeleteOrderItems(string userLocation, string userRestaurant, List<string> userFoodOrders, int totalPrice)
        {

            Console.WriteLine("\n");
            Console.WriteLine("Your Food Items Are");

            List<string> duplicateUserFoodOrders = userFoodOrders.ToList();
            int count, indexNumber = 1;

            if (duplicateUserFoodOrders.Count == 1)
            {
                Console.WriteLine(" {0}. {1}\t x{2}", indexNumber++, duplicateUserFoodOrders[0], duplicateUserFoodOrders.Count);
            }
            else
            {
                for (int loopIndex = 0; loopIndex < duplicateUserFoodOrders.Count; loopIndex++)
                {
                    count = 1;

                    for (int traverseIndex = loopIndex + 1; traverseIndex < duplicateUserFoodOrders.Count; traverseIndex++)
                    {
                        if (duplicateUserFoodOrders[loopIndex] == duplicateUserFoodOrders[traverseIndex])
                        {
                            count = count + 1;
                            duplicateUserFoodOrders.RemoveAt(traverseIndex);
                            traverseIndex = loopIndex;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.WriteLine(" {0}. {1}\t x{2}", indexNumber++, duplicateUserFoodOrders[loopIndex], count);
                }
            }
            return duplicateUserFoodOrders;
        }

        public static List<string> RemoveOrderItems(List<string> userFoodOrders, string deleteFood)
        {
            userFoodOrders.Remove(deleteFood);
            Console.WriteLine("\t\t\t\t\t Item Removed SUCESSFULLY");
            Console.WriteLine("\nYour Cart Is");
            return userFoodOrders;
        }

    }
}
