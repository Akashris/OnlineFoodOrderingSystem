using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineFoodOrderingSystem
{
    class Payment
    {
        public List<string> PaymentMethod()
        {
            List<string> Payment_Type = new List<string>() { "Online Payment", "Cash On Delivery" };
            Console.WriteLine("\nPlease Choose Your Payment Method");
            int index = 1;
            foreach (var result in Payment_Type)
            {
                Console.WriteLine("\n{0}.{1}", index++, result);
            }
            return Payment_Type;
        }
        public string get_PaymentMethod(List<string>Payment_Type, int User_Payment_input)
        {
            return Payment_Type[User_Payment_input - 1];
        }
        
    }
}
