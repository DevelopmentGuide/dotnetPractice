namespace MediatorDP
{
    public interface IChatMediator
    {
        void AddUser(IUser user);
        void SendMessage(IUser user, string msg);
    }
}
