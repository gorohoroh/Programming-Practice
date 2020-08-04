using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    class SharedCar
    {
        public string Model { get; }
        public SharedCar(string model) => Model = model;
    }
    
    class CarsharingCustomer : IObserver<SharedCar>
    {
        public string Name { get; }
        public CarsharingCustomer(string name) => Name = name;
        public void OnCompleted() => throw new NotImplementedException();
        public void OnError(Exception error) => throw new NotImplementedException();
        public void OnNext(SharedCar value) => Console.WriteLine($"Hey {Name}, there's a new car available for you: {value.Model}");
    }
    
    class CarsharingPool : IObservable<SharedCar>
    {
        public List<IObserver<SharedCar>> Observers { get; }
        public List<SharedCar> AvailableCars { get; }

        public CarsharingPool()
        {
            Observers = new List<IObserver<SharedCar>>();
            AvailableCars = new List<SharedCar>();
        }

        public IDisposable Subscribe(IObserver<SharedCar> observer)
        {
            if (!Observers.Contains(observer)) Observers.Add(observer);
            return new Unsubscriber<SharedCar>(Observers, observer);
        }

        private void Notify(SharedCar sharedCar)
        {
            foreach(var observer in Observers)
            {
                observer.OnNext(sharedCar);
            }
        }

        public void AddCar(SharedCar sharedCar)
        {
            AvailableCars.Add(sharedCar);
            Notify(sharedCar);
        }

    }

    internal class Unsubscriber<SharedCar> : IDisposable
    {
        public List<IObserver<SharedCar>> Observers { get; }
        public IObserver<SharedCar> Observer { get; }

        internal Unsubscriber(List<IObserver<SharedCar>> observers, IObserver<SharedCar> observer)
        {
            Observers = observers;
            Observer = observer;
        }

        public void Dispose()
        {
            if (Observers.Contains(Observer)) Observers.Remove(Observer);
        }
    }
}