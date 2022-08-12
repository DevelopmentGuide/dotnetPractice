using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solid_Principles
{
    class PhoneOrderRepair : IOrder
    {
        public void ProcessAccessoryRepair(string accessoryType)
        {
            Console.WriteLine(string.Format("{0} repair accepted!", accessoryType));
        }

        public void ProcessOrder(string modelName)
        {
            Console.WriteLine(string.Format("{0} order accepted!", modelName));
        }

        public void ProcessPhoneRepair(string modelName)
        {
            Console.WriteLine(string.Format("{0} repair accepted!", modelName));
        }
    }
}
