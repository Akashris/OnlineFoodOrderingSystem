using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem
{
    class UserInput
    {
        public static int UserInputValidation(int MyListCount)
        {
            int User_Input = -1;
            while (User_Input <= 0 || User_Input > MyListCount)
            {
                try
                {
                    Console.Write("\nEnter Your Choice\t");
                    User_Input = Convert.ToInt32(Console.ReadLine());
                    if (User_Input <= 0)
                    {
                        Console.WriteLine("\nEnter a Positive or Non Zero Input");
                    }
                    if (User_Input > MyListCount)
                    {
                        Console.WriteLine("\nEnter The Correct Option");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nEnter a Valid Input");
                }
            }
            return User_Input;
        }
    }
}
