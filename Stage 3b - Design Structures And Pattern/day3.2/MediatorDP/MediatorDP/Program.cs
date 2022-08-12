using System;

namespace MediatorDP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            IChatMediator chatMediator = new ChatMediator();
            IUser user1 = new BasicUser(chatMediator, "Vraj Shah");
            IUser user2 = new PremiumUser(chatMediator, "Komal Shah");
            IUser user3 = new PremiumUser(chatMediator, "Dipika Shah");

            chatMediator.AddUser(user1);
            chatMediator.AddUser(user2);
            chatMediator.AddUser(user3);

            user1.SendMessage("Hello");
            user2.SendMessage("Hi");
            Console.ReadLine();
        }

    }

}
