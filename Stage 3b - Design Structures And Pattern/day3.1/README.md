# Objectives

### Demonstrate the applicability of observer pattern

Publisher-subscriber model, Implementation of broadcast communication between related objects

Analyze and implement the following design patterns thru real life problems

Implement all these problems thru a Console application

### Observer


In the below scenario there is a Message Publisher of type subject and three subscribers of type Observer. Publisher publishes message periodically to all the subscribed or attached observers and they will print the updated message to the console.

#### Subject and ConcreteSubject

```csharp
Subject.java
public interface Subject
{
public void attach(Observer o);
public void detach(Observer o);
public void notifyUpdate(Message m);
}

MessagePublisher.java
import java.util.ArrayList;
import java.util.List;
public class MessagePublisher implements Subject {
private List<Observer> observers = new ArrayList<>();
@Override
public void attach(Observer o) {
observers.add(o);
}

@Override
public void detach(Observer o) { observers.remove(o); } @Override public void notifyUpdate(Message m) { for(Observer o: observers) { o.update(m); } } }
Observer and ConcreteObservers
Observer.java
public interface Observer
{
public void update(Message m);
}

MessageSubscriberOne.java
public class MessageSubscriberOne implements Observer
{
@Override
public void update(Message m) {
System.out.println("MessageSubscriberOne :: " + m.getMessageContent());
}
}

MessageSubscriberTwo.java
public class MessageSubscriberTwo implements Observer
{
@Override
public void update(Message m) {
System.out.println("MessageSubscriberTwo :: " + m.getMessageContent());
}
}
MessageSubscriberThree.java
public class MessageSubscriberThree implements Observer
{
@Override
public void update(Message m) {
System.out.println("MessageSubscriberThree :: " + m.getMessageContent());
}
}
State object This must be an immutable object so that no class can modify it’s content by mistake.
Message.java
public class Message
{
final String messageContent;
public Message (String m) { this.messageContent = m; } public String getMessageContent() { return messageContent; } }
Now test the communication between publisher and subscribers.
Main.java
public class Main
{
public static void main(String[] args)
{
MessageSubscriberOne s1 = new MessageSubscriberOne();
MessageSubscriberTwo s2 = new MessageSubscriberTwo();
MessageSubscriberThree s3 = new MessageSubscriberThree();
MessagePublisher p = new MessagePublisher();
p.attach(s1);
p.attach(s2);
p.notifyUpdate(new Message("First Message")); //s1 and s2 will receive the update
p.detach(s1);
p.attach(s3);
p.notifyUpdate(new Message("Second Message")); //s2 and s3 will receive the update
}
}
```

#### Program output.

```
Console
MessageSubscriberOne :: First Message
MessageSubscriberTwo :: First Message
MessageSubscriberTwo :: Second Message
MessageSubscriberThree :: Second Message
```


#### Exercise

1. Please create all the above classes and test the output as shown above

2. Modify the above code to include a state object in the subject.

3. Implement a public method to change the state of the Subject class

4. Notify all the Subscribers whenever there is change in the state

5. From client do a state change and print the notification message of all the subscribers.

6. Validate the output.