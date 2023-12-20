using System;

namespace RestaurantManager;

public class MaitreDHotel
{
    private static MaitreDHotel instance;
    private static readonly object lockObject = new object();

    private Model _model;
    public string Name { get; private set; }
    public Coordinate Position { get; set; }
    
    public MaitreDHotel(string name)
    {
        Name = name;
        Position = new Coordinate(250, 200);
    }
    public static MaitreDHotel GetInstance(string name)
    {
        if (instance == null)
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new MaitreDHotel(name);
                }
            }
        }
        return instance;
    }
    public void AssignTable(Table table, ChefDeRang chefDeRang)
    {
        chefDeRang.AssignTable(table);
    }

    public void ReceivePayment(Client client)
    {
        // Recevoir un paiement
    }
    

    public void welcomeGuests(int numberOfGuests)
    {
        // Accueillir les invités
    }

    public void processPayment(Client client)
    {
        // Traiter un paiement
    }/*
    public void CallChefDeRang(ChefDeRang chefDeRang)
    {
        Table assignedTable = GetAvailableTable();
        if (assignedTable != null)
        {
            chefDeRang.AssignTable(assignedTable);
            assignedTable.OccupyTable();
            Console.WriteLine("Le chef de rang a été appelé et une table lui a été assignée !");
        }
    }
    private Table GetAvailableTable()
    {
        foreach (Table table in _model.Tables)
        {
            if (!table.Occupied && table.Capacity >= _model.Client.NumberOfPeople)
            {
                return table;
            }
        }
        return null; 
    }*/
}