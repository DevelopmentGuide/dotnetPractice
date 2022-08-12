using System;

namespace MediatorDP
{
    public class BasicUser : IUser
    {
        private IChatMediator _chatMediator;
        public string Name { get; set; }

        public BasicUser(IChatMediator chatMediator, string name)
        {
            _chatMediator = chatMediator;
            Name = name;
        }

        public void ReceiveMessage(IUser user, string msg)
        {
            Console.WriteLine($"Message Send by {user.Name} to {Name} : {msg}");
        }

        public void SendMessage(string msg)
        {
            _chatMediator.SendMessage(this, msg);
        }
    }

}
