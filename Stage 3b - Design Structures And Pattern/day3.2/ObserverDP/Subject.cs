using System.Collections.Generic;

namespace ObserverDP
{
    public class Subject : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private int _state = 0;

        public int State
        {
            get
            {
                return _state;
            }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    notify(new Message("State Updated"));
                }
            }
        }
        public void attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void notify(Message message)
        {
            foreach (IObserver item in _observers)
            {
                item.Update(message);
            }
        }
    }
}
