using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem
{
    class Ordering
    {
        public static List<string> AddOrderItems(string UserRestaurant, List<string> User_FoodOrders, int _Total_Price)
        {
            Food foodObj = new Food();
            List<string> Food_name = foodObj.GetFood(UserRestaurant);

            int Food_count = 1;
            foreach (var result in Food_name)
            {
                Console.WriteLine("{0}.) {1}", Food_count, result);
                Food_count++;
            }

            int User_Food_input = OnlineFoodOrderingSystem.UserInput.UserInputValidation(Food_name.Count());

            User_FoodOrders.Add(Food_name[User_Food_input - 1]);

            return User_FoodOrders;
        }

        public static List<string> DeleteOrderItems(string UserLocation, string UserRestaurant, List<string> User_FoodOrders, int _Total_Price)
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

            int Item_Delete_Index = OnlineFoodOrderingSystem.UserInput.UserInputValidation(Duplicate_User_FoodOrders.Count());

            User_FoodOrders.Remove(Duplicate_User_FoodOrders[Item_Delete_Index - 1]);
            Console.WriteLine("\t\t\t\t\t Item Removed SUCESSFULLY");
            Console.WriteLine("\nYour Cart Is");

            return User_FoodOrders;
        }

    }
}
