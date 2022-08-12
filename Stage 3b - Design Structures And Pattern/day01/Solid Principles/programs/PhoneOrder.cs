using System;

namespace Solid_Principles
{
    public class PhoneOrder : IOrder
    {
        public void ProcessOrder(string modelName)
        {
            Console.WriteLine($"{modelName} order accepted!");
        }
    }
}
