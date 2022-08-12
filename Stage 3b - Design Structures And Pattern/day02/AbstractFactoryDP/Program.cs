using AbstractFactoryDP.HeadLight;
using AbstractFactoryDP.Tire;
using System;

namespace AbstractFactoryDP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Enter car(Audi or Mercedes): ");
            string car = Console.ReadLine();
            AbstractFactory factory = FactoryProducer.GetFactory(car);
            ITire tire = factory.makeTire();
            tire.GetTire();
            IHeadLight headlight = factory.makeHeadLight();
            headlight.GetHeadLight();
            Console.ReadLine();
        }
    }
}
