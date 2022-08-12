namespace ObserverDP
{
    public interface ISubject
    {
        void attach(IObserver observer);
        void detach(IObserver observer);
        void notify(Message message);
    }
}
