namespace ObserverPatternExample
{
    public interface IStock
    {
        void Register(IObserver observer);
        void Deregister(IObserver observer);
        void NotifyObservers();
    }
}