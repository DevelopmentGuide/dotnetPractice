using System;

namespace AbstractFactoryDP.HeadLight
{
    public class AudiHeadLight : IHeadLight
    {
        public void GetHeadLight()
        {
            Console.WriteLine("Audi HeadLight");
        }
    }
}
