using System;

namespace AbstractFactoryDP.Tire
{
    public class MercedesTire : ITire
    {
        public void GetTire()
        {
            Console.WriteLine("Mercedes Tire");
        }
    }
}
