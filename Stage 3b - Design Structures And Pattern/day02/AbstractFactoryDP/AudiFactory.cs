using AbstractFactoryDP.HeadLight;
using AbstractFactoryDP.Tire;

namespace AbstractFactoryDP
{
    public class AudiFactory : AbstractFactory
    {
        public override IHeadLight makeHeadLight()
        {
            return new AudiHeadLight();
        }

        public override ITire makeTire()
        {
            return new AudiTire();
        }
    }
}
