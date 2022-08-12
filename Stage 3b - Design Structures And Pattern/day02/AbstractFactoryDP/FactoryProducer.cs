using System;

namespace AbstractFactoryDP
{
    public class FactoryProducer
    {
        public static AbstractFactory GetFactory(string type)
        {
            switch (type)
            {
                case "Mercedes":
                    return new MercedesFactory();
                case "Audi":
                    return new AudiFactory();
                default:
                    throw new ApplicationException($"{type} Car type is invalid");
            }
        }
    }
}
