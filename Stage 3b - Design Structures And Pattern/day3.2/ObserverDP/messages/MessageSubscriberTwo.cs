using System;

namespace ObserverDP
{
    public class MessageSubscriberTwo : IObserver
    {
        public void Update(Message message)
        {
            Console.WriteLine($"Message Subscriber Two: {message.getMessageContent()}");
        }
    }
}
