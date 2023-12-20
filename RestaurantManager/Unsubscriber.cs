using System;
using System.Collections.Generic;

namespace RestaurantManager;

public class Unsubscriber<Table> : IDisposable
{
    private List<IObserver<Table>> _observers;
    private IObserver<Table> _observer;

    public Unsubscriber(List<IObserver<Table>> observers, IObserver<Table> observer)
    {
        _observers = observers;
        _observer = observer;
    }

    public void Dispose()
    {
        if (_observers.Contains(_observer))
        {
            _observers.Remove(_observer);
        }
    }
}
