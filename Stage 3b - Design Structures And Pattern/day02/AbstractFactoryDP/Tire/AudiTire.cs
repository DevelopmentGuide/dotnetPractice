using System;

namespace AbstractFactoryDP.Tire
{
    public class AudiTire : ITire
    {
        public void GetTire()
        {
            Console.WriteLine("Audi Tire");
        }
    }
}
