using AbstractFactoryDP.HeadLight;
using AbstractFactoryDP.Tire;

namespace AbstractFactoryDP
{
    public class MercedesFactory : AbstractFactory
    {
        public override IHeadLight makeHeadLight()
        {
            return new MercedesHeadLight();
        }

        public override ITire makeTire()
        {
            return new MercedesTire();
        }
    }
}
