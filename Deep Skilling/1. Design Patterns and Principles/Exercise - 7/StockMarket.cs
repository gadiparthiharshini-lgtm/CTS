using System.Collections.Generic;

namespace ObserverPatternExample
{
    public class StockMarket : IStock
    {
        private readonly List<IObserver> observers = new();

        private string stockName = "";
        private double price;

        public void Register(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Deregister(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void SetStock(string name, double newPrice)
        {
            stockName = name;
            price = newPrice;
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update(stockName, price);
            }
        }
    }
}