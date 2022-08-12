using System;

namespace BuilderDP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Director director = new Director();
            Builder builder1 = new AdultPackage();
            Builder builder2 = new ChildPackage();
            director.Construct(builder1);
            Product product = builder1.GetProduct();
            Console.WriteLine("Adult Package");
            product.Show();
            director.Construct(builder2);
            product = builder2.GetProduct();
            Console.WriteLine("Child Package");
            product.Show();

            Console.ReadLine();
        }
    }
}




