namespace ObserverDP
{
    public class Message
    {
        private string _messageContent;
        public Message(string message)
        {
            _messageContent = message;
        }
        public string getMessageContent()
        {
            return _messageContent;
        }
    }
}
