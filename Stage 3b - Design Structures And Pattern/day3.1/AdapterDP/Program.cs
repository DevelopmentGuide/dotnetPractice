using System;

namespace AdapterDP
{
    public class Program
    {
        static void Main(string[] args)
        {
            IMovable buggati = new BuggatiVeyron();
            IMovableAdapter adapter = new MovableAdapterImpl(buggati);
            Console.WriteLine(adapter.getSpeed());
            Console.WriteLine(adapter.getPrice());
            Console.ReadLine();
        }
    }

    public class BuggatiVeyron : IMovable
    {
        public double getSpeed()
        {
            Console.WriteLine("Enter speed in MPH: ");
            int gSpeed = Convert.ToInt32(Console.ReadLine());
            return gSpeed;
        }
        public double getPrice()
        {
            Console.WriteLine("Enter Price in USD: ");
            int gPrice = Convert.ToInt32(Console.ReadLine());
            return gPrice;
        }
    }

    public class MovableAdapterImpl : IMovableAdapter
    {
        private IMovable _luxuryCars;

        public MovableAdapterImpl(IMovable luxuryCars)
        {
            _luxuryCars = luxuryCars;
        }

        public double getPrice()
        {
            return convertUSDToEuro(_luxuryCars.getPrice());
        }

        public double getSpeed()
        {
            return convertMPHToKMPH(_luxuryCars.getSpeed());
        }

        private double convertMPHToKMPH(double mph)
        {
            return mph * 1.60934;
        }
        private double convertUSDToEuro(double usd)
        {
            return usd * 0.84;
        }
    }
}
