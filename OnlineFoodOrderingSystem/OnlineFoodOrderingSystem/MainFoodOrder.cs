using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Configuration;
using OnlineFoodOrderingSystem;

namespace OnlineFoodOrderingSystem
{
    class MainFoodOrder
    {
        public static void ViewCart(string UserLocation, string UserRestaurant, List<string> User_FoodOrders, int _Total_Price)
        {
            List<string> Duplicate_User_FoodOrders = User_FoodOrders.ToList();
            Console.WriteLine("\t\t\t\t\t         ___/^");
            Console.WriteLine("\t\t\t\t\t        |__/  - Your Cart");
            Console.WriteLine("\t\t\t\t\t        O O");
            Console.WriteLine("\n\t\t\t\t\t-----------------------------------");
            Console.WriteLine("\t\t\t\t\t Restaurant Name : {0}", UserRestaurant);
            Console.WriteLine("\t\t\t\t\t Location        : {0}", UserLocation);

            Console.WriteLine("\t\t\t\t\t You Have Ordered The Following:-\n");
            int Count, IndexNumber = 1;

            if (Duplicate_User_FoodOrders.Count == 1)
            {
                Console.Write("\t\t\t\t\t {0}. {1}\t\t", IndexNumber++, Duplicate_User_FoodOrders[0]);
                Console.Write("x{0}\n", Duplicate_User_FoodOrders.Count);
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
                    Console.Write("\t\t\t\t\t {0}. {1}\t\t", IndexNumber++, Duplicate_User_FoodOrders[LoopIndex]);
                    Console.Write("x{0}\n",Count);
                }
            }
            Console.WriteLine("\n\t\t\t\t\t Amount To Pay   : {0} /- RS\n", _Total_Price);
            Console.WriteLine("\t\t\t\t\t\tTHANKS FOR ORDERING");
            Console.WriteLine("\n\t\t\t\t\t-----------------------------------");
        }

        public static void ExitSystem()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t    () ()");
            Console.WriteLine("\t\t\t\t\t     .-. ");
            Console.WriteLine("\t\t\t\t\t    '   '");
            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t Sorry Your Cart Is Empty");
        }

        public static void Main(string[] args)
        {

            Console.WriteLine("\n");
            Console.WriteLine("\t\t\t\t\t **** WELCOME TO TOMATO :)  ****\n");
            Console.WriteLine("\n");
            CustomerDetails customer = new CustomerDetails();
            List<CustomerDetails> customerDetail_List = new List<CustomerDetails>();
            Console.Write("\tUSERNAME :  ");
            String Customer_Name;           
            Customer_Name = Console.ReadLine();
            customer.SetName(Customer_Name);
            Console.WriteLine("\n");

            Location loc = new Location();
            List<string> Location_name = loc.GetLocation();
            loc.DisplayLocation(Location_name);
            int User_Location_input = OnlineFoodOrderingSystem.UserInput.UserInputValidation(Location_name.Count()); 
            
            var re_order="yes";
            while (re_order == "yes")
            {
                List<string> Restaurant_Name = OnlineFoodOrderingSystem.Restaurant.ChooseRestaurant(Location_name[User_Location_input-1]);
                List<string> Food_Name = new List<string>();
                int User_Restaurant_input = OnlineFoodOrderingSystem.UserInput.UserInputValidation(Restaurant_Name.Count());
                int _Total_Price = 0;
                List<string> User_FoodOrders = new List<string>();
                List<string> Delete_UserOrders = new List<string>();
                var yesOrNo = "yes";
                while (yesOrNo == "yes")
                {
                    while (yesOrNo == "yes")
                    {
                        Food_Name= OnlineFoodOrderingSystem.Ordering.DisplayOrderItems(Restaurant_Name[User_Restaurant_input - 1], User_FoodOrders, _Total_Price);
                        int User_Food_input = OnlineFoodOrderingSystem.UserInput.UserInputValidation(Food_Name.Count());
                        User_FoodOrders = OnlineFoodOrderingSystem.Ordering.AddOrderItems(Food_Name[User_Food_input-1],User_FoodOrders);

                        
                        int Food_Price = OnlineFoodOrderingSystem.Food.FoodPrice(Restaurant_Name[User_Restaurant_input - 1], User_FoodOrders, _Total_Price);
                        _Total_Price = OnlineFoodOrderingSystem.Food.CalculateTotalPrice(Food_Price, _Total_Price);

                        ViewCart(Location_name[User_Location_input - 1], Restaurant_Name[User_Restaurant_input - 1], User_FoodOrders, _Total_Price);
                        Console.Write("\n\tDo You Wish To Order More - YES (OR) NO ?  ");

                        yesOrNo = Convert.ToString(Console.ReadLine());
                        yesOrNo = yesOrNo.ToLower();

                    }

                    ViewCart(Location_name[User_Location_input - 1], Restaurant_Name[User_Restaurant_input - 1], User_FoodOrders, _Total_Price);

                    Console.Write("\n\tDo You Want To Delete Items From Your Cart?   YES (OR) NO  ");
                    yesOrNo = Convert.ToString(Console.ReadLine());
                    yesOrNo = yesOrNo.ToLower();

                    while (yesOrNo == "yes")
                    {
                        Delete_UserOrders = OnlineFoodOrderingSystem.Ordering.DisplayDeleteOrderItems(Location_name[User_Location_input - 1], Restaurant_Name[User_Restaurant_input - 1], User_FoodOrders, _Total_Price);
                        int Item_Delete_Index = OnlineFoodOrderingSystem.UserInput.UserInputValidation(Delete_UserOrders.Count());
                        User_FoodOrders = OnlineFoodOrderingSystem.Ordering.RemoveOrderItems(User_FoodOrders, Delete_UserOrders[Item_Delete_Index-1]);


                        int Temp_Price = OnlineFoodOrderingSystem.Food.CalculateReduceFoodPrice(Restaurant_Name[User_Restaurant_input - 1], User_FoodOrders, _Total_Price);
                        _Total_Price = OnlineFoodOrderingSystem.Food.ReduceFoodPrice(Temp_Price, _Total_Price);
                        if (_Total_Price > 0)
                        {
                            ViewCart(Location_name[User_Location_input - 1], Restaurant_Name[User_Restaurant_input - 1], User_FoodOrders, _Total_Price);
                            Console.Write("\n\tDo You Want To Alter Your Cart Again?   YES (OR) NO  ");
                            yesOrNo = Convert.ToString(Console.ReadLine());
                        }
                        else
                        {
                            ExitSystem();
                            goto OrderAgain;
                        }
                    }
                    Console.Write("\n\tDo You Wish To Add Items?  YES (OR) NO  ");
                    yesOrNo = Convert.ToString(Console.ReadLine());
                }
                Payment paymentObject = new Payment();
                List<string> Payment_Type = paymentObject.PaymentMethod();

                int User_Payment_input = OnlineFoodOrderingSystem.UserInput.UserInputValidation(Payment_Type.Count());
                string UserPaymentMethod = paymentObject.get_PaymentMethod(Payment_Type,User_Payment_input);
                Console.WriteLine("\n");
                Console.WriteLine("\t\t\t\t\t    ()  ()");
                Console.WriteLine("\t\t\t\t\t    .    .  Thank You For Using TOMATO ");
                Console.WriteLine("\t\t\t\t\t     '..'");
  
                int User_Feedback = -1;
                while (User_Feedback <= 0 || User_Feedback > 10)
                {
                    try
                    {
                        Console.Write("\n\t\t\t\tPlease Enter Your Feedback Out Of 10- \t");
                        User_Feedback = Convert.ToInt32(Console.ReadLine());
                        if (User_Feedback <= 0)
                        {
                            Console.WriteLine("\n\tEnter a Positive or Non Zero Input");
                        }
                        if (User_Feedback > 10)
                        {
                            Console.WriteLine("\n\tEnter The Correct Option");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nEnter a Valid Input");
                    }
                }

                customer.SetFeedback(User_Feedback);
                customerDetail_List.Add(customer);
                customer.Add_Customer_Details_In_Database(customerDetail_List, Location_name[User_Location_input - 1], Restaurant_Name[User_Restaurant_input - 1], User_FoodOrders, _Total_Price, UserPaymentMethod);
                Console.WriteLine("\n\t\t\t\t\tPress Any Key To Continue");
                Console.ReadKey();
                OrderAgain:
                {
                    Console.WriteLine("\nDo You Wish To Place A New Order ?  YES (or) NO");
                    re_order = Console.ReadLine();
                    re_order.ToLower();
                }
            }
            Console.WriteLine("\t\t\t\t\t    ()  ()");
            Console.WriteLine("\t\t\t\t\t    .    .  Thank You For Using TOMATO ");
            Console.WriteLine("\t\t\t\t\t     '..'");
        }
        
    }
}
        