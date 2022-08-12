namespace MediatorDP
{
    public interface IUser
    {
        public string Name { get; set; }
        void ReceiveMessage(IUser user, string msg);
        void SendMessage(string msg);
    }
}
