using System.Collections.Generic;

namespace MediatorDP
{
    public class ChatMediator : IChatMediator
    {
        private List<IUser> _users;

        public ChatMediator()
        {
            _users = new List<IUser>();
        }

        public void AddUser(IUser user)
        {
            _users.Add(user);
        }

        public void SendMessage(IUser user, string msg)
        {
            foreach (IUser item in _users)
            {
                if (user != item)
                    item.ReceiveMessage(user, msg);
            }
        }
    }
}
