using System;

namespace RestaurantManager
{
    public class ChefDeRang
    {
        public string Name { get; private set; }
        public Coordinate Position { get; set; }
        public Table CurrentTable { get; private set; }
    public ChefDeRang(string name)
    {
        Name = name;
        CurrentTable = null;
        Position = new Coordinate(0, 0);
    }

    public void MoveToTable(Table table)
    {
        if (CurrentTable != null)
        {
            Console.WriteLine("Chef de rng {0} se déplace de la table {1} à la table {2}.",Name,CurrentTable.Position, table.Position);
        }
        else
        {
            Console.WriteLine("Chef de rang {0} se déplace de la table {1}.", Name, table.Position);
        }

        CurrentTable = table;
    }

    public void ServeTable()
    {
        if (CurrentTable != null)
        {
            Console.WriteLine("Chef de rang {0} sert la table {1}.", Name, CurrentTable.Position);
        }
        else
        {
            Console.WriteLine("Chef de rang {0} n'est pas à une table", Name);
        }
    }
    }
}
    