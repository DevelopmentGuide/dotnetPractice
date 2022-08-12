using System;

namespace ObserverDP
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MessageSubscriberOne s1 = new MessageSubscriberOne();
            MessageSubscriberTwo s2 = new MessageSubscriberTwo();
            MessageSubscriberThree s3 = new MessageSubscriberThree();
            Subject subject = new Subject();
            subject.attach(s1);
            subject.attach(s2);
            subject.State = 2;
            subject.attach(s3);
            Console.WriteLine();
            subject.detach(s2);
            subject.State = 3;
            Console.ReadLine();
        }
    }






}
