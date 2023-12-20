using System;
using System.Collections.Generic;
using RestaurantManager;

public class RestaurantModel : IObservable<Table>
{
    private List<Table> _tables;
    private List<IObserver<Table>> _observers;

    public RestaurantModel()
    {
        _tables = new List<Table>();
        _observers = new List<IObserver<Table>>();
    }

    // Méthode pour ajouter une table au restaurant
    public void AddTable(Table table)
    {
        _tables.Add(table);
    }

    // Méthode pour supprimer une table du restaurant
    public void RemoveTable(Table table)
    {
        _tables.Remove(table);
    }

    // Méthode pour notifier les observateurs qu'une table a été occupée
    public void NotifyTableOccupied(Table table)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(table);
        }
    }

    // Méthode pour notifier les observateurs qu'une table a été libérée
    public void NotifyTableReleased(Table table)
    {
        foreach (var observer in _observers)
        {
            observer.OnNext(table);
        }
    }

    // Méthode pour s'abonner en tant qu'observateur
    public IDisposable Subscribe(IObserver<Table> observer)
    {
        if (!_observers.Contains(observer))
        {
            _observers.Add(observer);
        }

        return new Unsubscriber<Table>(_observers, observer);
    }
}