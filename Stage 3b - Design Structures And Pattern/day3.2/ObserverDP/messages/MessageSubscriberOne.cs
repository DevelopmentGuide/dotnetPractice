using System;

namespace ObserverDP
{
    public class MessageSubscriberOne : IObserver
    {
        public void Update(Message message)
        {
            Console.WriteLine($"Message Subscriber One: {message.getMessageContent()}");
        }
    }
}
