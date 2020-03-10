namespace OnlineFoodOrderingSystem
{
    using System;
    using System.Collections.Generic;


    public class Payment
    {
        public List<string> PaymentMethod()
        {
            List<string> paymentType = new List<string>() { "Online Payment", "Cash On Delivery" };
            Console.Write("\n\tPlease Choose Your Payment Method ");
            int index = 1;
            foreach (var result in paymentType)
            {
                Console.WriteLine("\n{0}.{1}", index++, result);
            }
            return paymentType;
        }

        public string get_PaymentMethod(List<string> paymentType, int userPaymentInput)
        {
            return paymentType[userPaymentInput - 1];
        }

    }
}
