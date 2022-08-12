using System;

namespace MediatorDP
{
    public class PremiumUser : IUser
    {
        private IChatMediator _chatMediator;
        public string Name { get; set; }

        public PremiumUser(IChatMediator chatMediator, string name)
        {
            _chatMediator = chatMediator;
            Name = name;
        }

        public void ReceiveMessage(IUser user, string msg)
        {
            Console.WriteLine($"Message send by {user.Name} to {Name}: {msg}");
        }

        public void SendMessage(string msg)
        {
            _chatMediator.SendMessage(this, msg);
        }
    }

}
