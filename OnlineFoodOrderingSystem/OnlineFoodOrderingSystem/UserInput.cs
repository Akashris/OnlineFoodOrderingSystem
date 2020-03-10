namespace OnlineFoodOrderingSystem
{
    using System;


    class UserInput
    {
        public static int UserInputValidation(int myListCount)
        {
            int userInput = -1;
            while (userInput <= 0 || userInput > myListCount)
            {
                try
                {
                    Console.Write("\n\tEnter Your Choice\t");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    if (userInput <= 0)
                    {
                        Console.WriteLine("\n\tEnter a Positive or Non Zero Input");
                    }
                    if (userInput > myListCount)
                    {
                        Console.WriteLine("\n\tEnter The Correct Option");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n\tEnter a Valid Input");
                }
            }
            return userInput;
        }
    }
}
