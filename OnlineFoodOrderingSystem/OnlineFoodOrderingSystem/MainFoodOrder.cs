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
        public static void ViewCart(string userLocation, string UserRestaurant, List<string> userFoodOrders, int totalPrice)
        {
            List<string> duplicateUserFoodOrders = userFoodOrders.ToList();
            Console.WriteLine("\t\t\t\t\t         ___/^");
            Console.WriteLine("\t\t\t\t\t        |__/  - Your Cart");
            Console.WriteLine("\t\t\t\t\t        O O");
            Console.WriteLine("\n\t\t\t\t\t-----------------------------------");
            Console.WriteLine("\t\t\t\t\t Restaurant Name : {0}", UserRestaurant);
            Console.WriteLine("\t\t\t\t\t Location        : {0}", userLocation);

            Console.WriteLine("\t\t\t\t\t You Have Ordered The Following:-\n");
            int count, indexNumber = 1;

            if (duplicateUserFoodOrders.Count == 1)
            {
                Console.Write("\t\t\t\t\t {0}. {1}\t\t", indexNumber++, duplicateUserFoodOrders[0]);
                Console.Write("x{0}\n", duplicateUserFoodOrders.Count);
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
                    Console.Write("\t\t\t\t\t {0}. {1}\t\t", indexNumber++, duplicateUserFoodOrders[loopIndex]);
                    Console.Write("x{0}\n", count);
                }
            }
            Console.WriteLine("\n\t\t\t\t\t Amount To Pay   : {0} /- RS\n", totalPrice);
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
            List<CustomerDetails> customerDetailList = new List<CustomerDetails>();

            Console.Write("\tUSERNAME :  ");
            String customerName;
            customerName = Console.ReadLine();
            customer.SetName(customerName);

            Console.WriteLine("\n");

            Location loc = new Location();
            List<string> locationName = loc.GetLocation();
            loc.DisplayLocation(locationName);
            int userLocationInput = OnlineFoodOrderingSystem.UserInput.UserInputValidation(locationName.Count()); 
            
            var reOrder="yes";
            while (reOrder == "yes")
            {
                List<string> restaurantName = OnlineFoodOrderingSystem.Restaurant.ChooseRestaurant(locationName[userLocationInput - 1]);
                List<string> foodName = new List<string>();
                int userRestaurantInput = OnlineFoodOrderingSystem.UserInput.UserInputValidation(restaurantName.Count());
                int totalPrice = 0;
                List<string> userFoodOrders = new List<string>();
                List<string> deleteUserOrders = new List<string>();
                int inputCheck;
                string yesOrNo = "yes";
                while (yesOrNo == "yes")
                {
                    while (yesOrNo == "yes")
                    {
                        foodName = OnlineFoodOrderingSystem.Ordering.DisplayOrderItems(restaurantName[userRestaurantInput - 1], userFoodOrders, totalPrice);
                        int User_Food_input = OnlineFoodOrderingSystem.UserInput.UserInputValidation(foodName.Count());
                        userFoodOrders = OnlineFoodOrderingSystem.Ordering.AddOrderItems(foodName[User_Food_input-1], userFoodOrders);

                        
                        int Food_Price = OnlineFoodOrderingSystem.Food.FoodPrice(restaurantName[userRestaurantInput - 1], userFoodOrders, totalPrice);
                        totalPrice = OnlineFoodOrderingSystem.Food.CalculateTotalPrice(Food_Price, totalPrice);

                        ViewCart(locationName[userLocationInput - 1], restaurantName[userRestaurantInput - 1], userFoodOrders, totalPrice);
                        inputCheck = 0;
                        while (inputCheck == 0)
                        {
                            try
                            {
                                Console.Write("\n\tDo You Wish To Order More - YES (OR) NO ?  ");
                                yesOrNo = Console.ReadLine();
                                yesOrNo = yesOrNo.ToLower();
                                if (yesOrNo != "yes"&& yesOrNo != "no")
                                {
                                    Console.WriteLine("\n\t Please Type the Word Yes or No Fully");

                                }
                                else
                                {
                                    inputCheck = 1;
                                }
                            }
                            catch (FormatException)
                            {
                                Console.WriteLine("\n\tEnter a Valid Input");

                            }
                        }

                    }

                    ViewCart(locationName[userLocationInput - 1], restaurantName[userRestaurantInput - 1], userFoodOrders, totalPrice);

                    inputCheck = 0;
                    while (inputCheck == 0)
                    {
                        try
                        {
                            Console.Write("\n\tDo You Want To Delete Items From Your Cart?   YES (OR) NO  ");
                            yesOrNo = Console.ReadLine();
                            yesOrNo = yesOrNo.ToLower();
                            if (yesOrNo != "yes" && yesOrNo != "no")
                            {
                                Console.WriteLine("\n\t Please Type the Word Yes or No Fully");

                            }
                            else
                            {
                                inputCheck = 1;
                            }
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("\n\tEnter a Valid Input");
                            
                        }
                    }

                    

                    while (yesOrNo == "yes")
                    {
                        deleteUserOrders = OnlineFoodOrderingSystem.Ordering.DisplayDeleteOrderItems(locationName[userLocationInput - 1], restaurantName[userRestaurantInput - 1], userFoodOrders, totalPrice);
                        int itemDeleteIndex = OnlineFoodOrderingSystem.UserInput.UserInputValidation(deleteUserOrders.Count());
                        userFoodOrders = OnlineFoodOrderingSystem.Ordering.RemoveOrderItems(userFoodOrders, deleteUserOrders[itemDeleteIndex - 1]);


                        int tempPrice = OnlineFoodOrderingSystem.Food.CalculateReduceFoodPrice(restaurantName[userRestaurantInput - 1], userFoodOrders, totalPrice);
                        totalPrice = OnlineFoodOrderingSystem.Food.ReduceFoodPrice(tempPrice, totalPrice);
                        if (totalPrice > 0)
                        {
                            ViewCart(locationName[userLocationInput - 1], restaurantName[userRestaurantInput - 1], userFoodOrders, totalPrice);


                            inputCheck = 0;
                            while (inputCheck == 0)
                            {
                                try
                                {
                                    Console.Write("\n\tDo You Want To Alter Your Cart Again?   YES (OR) NO  ");
                                    yesOrNo = Console.ReadLine();
                                    yesOrNo = yesOrNo.ToLower();
                                    if (yesOrNo != "yes" && yesOrNo != "no")
                                    {
                                        Console.WriteLine("\n\t Please Type the Word Yes or No Fully");

                                    }
                                    else
                                    {
                                        inputCheck = 1;
                                    }
                                }
                                catch (FormatException)
                                {
                                    Console.WriteLine("\n\tEnter a Valid Input");

                                }
                            }
                        }
                        else
                        {
                            ExitSystem();
                            goto OrderAgain;
                        }
                    }
                    inputCheck = 0;
                    while (inputCheck == 0)
                    {
                        try
                        {
                            Console.Write("\n\tDo You Wish To Add Items?  YES (OR) NO  ");
                            yesOrNo = Console.ReadLine();
                            yesOrNo = yesOrNo.ToLower();
                            if (yesOrNo != "yes" && yesOrNo != "no")
                            {
                                Console.WriteLine("\n\t Please Type the Word Yes or No Fully");

                            }
                            else
                            {
                                inputCheck = 1;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\n\tEnter a Valid Input");

                        }
                    }
                }
                Payment paymentObject = new Payment();
                List<string> paymentType = paymentObject.PaymentMethod();

                int userPaymentInput = OnlineFoodOrderingSystem.UserInput.UserInputValidation(paymentType.Count());
                string userPaymentMethod = paymentObject.get_PaymentMethod(paymentType, userPaymentInput);
                Console.WriteLine("\n");
                Console.WriteLine("\t\t\t\t\t    ()  ()");
                Console.WriteLine("\t\t\t\t\t    .    .  Thank You For Using TOMATO ");
                Console.WriteLine("\t\t\t\t\t     '..'");
  
                int userFeedback = -1;
                while (userFeedback <= 0 || userFeedback > 10)
                {
                    try
                    {
                        Console.Write("\n\t\t\t\tPlease Enter Your Feedback Out Of 10- \t");
                        userFeedback = Convert.ToInt32(Console.ReadLine());
                        if (userFeedback <= 0)
                        {
                            Console.WriteLine("\n\tEnter a Positive or Non Zero Input");
                        }
                        if (userFeedback > 10)
                        {
                            Console.WriteLine("\n\tEnter The Correct Option");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nEnter a Valid Input");
                    }
                }

                customer.SetFeedback(userFeedback);
                customerDetailList.Add(customer);
                customer.AddCustomerDetailsInDatabase(customerDetailList, locationName[userLocationInput - 1], restaurantName[userRestaurantInput - 1], userFoodOrders, totalPrice, userPaymentMethod);
                Console.WriteLine("\n\t\t\t\t\tPress Any Key To Continue");
                Console.ReadKey();
                OrderAgain:
                {
                    inputCheck = 0;
                    while (inputCheck == 0)
                    {
                        try
                        {
                            Console.WriteLine("\nDo You Wish To Place A New Order ?  YES (or) NO");
                            reOrder = Console.ReadLine();
                            reOrder.ToLower();
                            if (reOrder != "yes" && reOrder != "no")
                            {
                                Console.WriteLine("\n\t Please Type the Word Yes or No Fully");

                            }
                            else
                            {
                                inputCheck = 1;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("\n\tEnter a Valid Input");

                        }
                    }
                }
            }
            Console.WriteLine("\t\t\t\t\t    ()  ()");
            Console.WriteLine("\t\t\t\t\t    .    .  Thank You For Using TOMATO ");
            Console.WriteLine("\t\t\t\t\t     '..'");
        }


        
    }
}
        