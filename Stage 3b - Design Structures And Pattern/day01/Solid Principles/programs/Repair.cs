using System;

namespace Solid_Principles
{
    public class Repair : IRepair
    {
        public void ProcessAccessoryRepair(string accessoryType)
        {
            Console.WriteLine($"{accessoryType} repair accepted");
        }

        public void ProcessPhoneRepair(string modelName)
        {
            Console.WriteLine($"{modelName} repair accepted!");
        }
    }
}
