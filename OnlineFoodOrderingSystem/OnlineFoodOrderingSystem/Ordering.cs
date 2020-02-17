using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem
{
    public class Ordering
    {
        public static List<string> DisplayOrderItems(string UserRestaurant, List<string> User_FoodOrders, int _Total_Price)
        {
            Food foodObj = new Food();
            List<string> Food_name = foodObj.GetFood(UserRestaurant);

            int Food_count = 1;
            foreach (var result in Food_name)
            {
                Console.WriteLine("{0}.) {1}", Food_count, result);
                Food_count++;
            }
            return Food_name;
        }

        public static List<string> AddOrderItems(string UserFood, List<string> User_FoodOrders)
        {      
            User_FoodOrders.Add(UserFood);

            return User_FoodOrders;
        }

        public static List<string> DisplayDeleteOrderItems(string UserLocation, string UserRestaurant, List<string> User_FoodOrders, int _Total_Price)
        {

            List<string> Delete_FoodOrders = User_FoodOrders.ToList();
            Console.WriteLine("\n");
            Console.WriteLine("Your Food Items Are");

            List<string> Duplicate_User_FoodOrders = User_FoodOrders.ToList();
            int Count, IndexNumber = 1;

            if (Duplicate_User_FoodOrders.Count == 1)
            {
                Console.WriteLine(" {0}. {1}\t x{2}", IndexNumber++, Duplicate_User_FoodOrders[0], Duplicate_User_FoodOrders.Count);
            }
            else
            {
                for (int LoopIndex = 0; LoopIndex < Duplicate_User_FoodOrders.Count; LoopIndex++)
                {
                    Count = 1;

                    for (int TraverseIndex = LoopIndex + 1; TraverseIndex < Duplicate_User_FoodOrders.Count; TraverseIndex++)
                    {
                        if (Duplicate_User_FoodOrders[LoopIndex] == Duplicate_User_FoodOrders[TraverseIndex])
                        {
                            Count = Count + 1;
                            Duplicate_User_FoodOrders.RemoveAt(TraverseIndex);
                            TraverseIndex = LoopIndex;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    Console.WriteLine(" {0}. {1}\t x{2}", IndexNumber++, Duplicate_User_FoodOrders[LoopIndex], Count);
                }
            }
            return Duplicate_User_FoodOrders;
        }

        public static List<string> RemoveOrderItems(List<string> User_FoodOrders,string deleteFood)
        { 
            User_FoodOrders.Remove(deleteFood);
            Console.WriteLine("\t\t\t\t\t Item Removed SUCESSFULLY");
            Console.WriteLine("\nYour Cart Is");
            return User_FoodOrders;
        }

    }
}
