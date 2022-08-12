using System;

namespace FacadeDP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ShapeMaker shapeMaker = new ShapeMaker();
            shapeMaker.DrawCircle();
            shapeMaker.DrawSquare();
            shapeMaker.DrawRectangle();
            Console.ReadLine();
        }
    }
}
