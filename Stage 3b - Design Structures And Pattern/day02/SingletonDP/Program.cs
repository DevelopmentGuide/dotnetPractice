using System;

namespace SingletonDP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program Start! \n");
            DBConn instance1 = DBConn.getInstance();
            DBConn instance2 = DBConn.getInstance();
            if (instance1 == instance2)
                Console.WriteLine("Same Instance");
            Console.WriteLine($"instance1 hash value {instance1.GetHashCode()}");
            Console.WriteLine($"instance2 hash value {instance2.GetHashCode()}");
            Console.ReadLine();
        }
    }
}
