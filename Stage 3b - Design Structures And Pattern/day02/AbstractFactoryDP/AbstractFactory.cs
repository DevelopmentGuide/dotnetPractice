using AbstractFactoryDP.HeadLight;
using AbstractFactoryDP.Tire;
namespace AbstractFactoryDP
{
    public abstract class AbstractFactory
    {
        public abstract IHeadLight makeHeadLight();
        public abstract ITire makeTire();
    }
}
