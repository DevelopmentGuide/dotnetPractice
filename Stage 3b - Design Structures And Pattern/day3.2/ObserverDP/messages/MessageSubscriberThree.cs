using System;

namespace ObserverDP
{
    public class MessageSubscriberThree : IObserver
    {
        public void Update(Message message)
        {
            Console.WriteLine($"Message Subscriber Three: {message.getMessageContent()}");
        }
    }
}
