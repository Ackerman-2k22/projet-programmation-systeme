using System;

namespace RestaurantManager
{
    public class ChefDeRang : IObserver<Table>
    {
        private IDisposable _unsubscriber;
        private bool _hasAssignedTable;
        private CommisDeSalle commis;
        public Table assignedTable;
        //public Table AssignedTable { get; private set; }
        public string Name { get; private set; }
        public Coordinate Position { get; set; }
        public Table CurrentTable => assignedTable;

        public ChefDeRang(string name)
        {
            Name = name;
            assignedTable = null;
            Position = new Coordinate(415, 210);
            this.commis = commis;
            _hasAssignedTable = false;
        }

        /*public void AssignTable(Table table)
        {
            assignedTable = table;
        }*/

        public void MoveToTable()
        {
            if (assignedTable != null)
            {
                Console.WriteLine("Chef de rang {0} moves to table {1}.", Name, assignedTable.Position);
            }
            else
            {
                Console.WriteLine("Chef de rang {0} has no assigned table.", Name);
            }
        }

        public void ServeTable()
        {
            if (assignedTable != null)
            {
                Console.WriteLine("Chef de rang {0} serves table {1}.", Name, assignedTable.Position);
            }
            else
            {
                Console.WriteLine("Chef de rang {0} is not assigned to a table.", Name);
            }
        }

        public void AssignTask(Table table)
        {
            assignedTable = table;
        }

        public CommisDeSalle getCommis()
        {
            return commis;
        }

        public void presentMenu(Client client)
        {
            // Présenter le menu
        }

        public void takeOrder(Client client, Order order)
        {
            // Prendre une commande
        }

        public void serveOrder(Order order)
        {
            // Servir une commande
        }

        public void clearTable(Table table)
        {
            // Nettoyer une table
        }

        public bool HasAssignedTable()
        {
            return assignedTable != null;
        }

        public void ClearAssignedTable()
        {
            assignedTable = null;
        }

        public void Subscribe(RestaurantModel restaurantModel)
        {
            _unsubscriber = restaurantModel.Subscribe(this);
        }

        public void Unsubscribe()
        {
            _unsubscriber.Dispose();
        }
        public void OnNext(Table table)
        {
            if (!_hasAssignedTable && !table.Occupied)
            {
                AssignTable(table);
            }
        }

        // Méthode pour attribuer une table au chef de rang
        public void AssignTable(Table table)
        {
            // Logique d'attribution de la table au chef de rang
            _hasAssignedTable = true;
        }
        public void OnCompleted()
        {
            // Ne fait rien pour l'instant
        }

        public void OnError(Exception error)
        {
            // Ne fait rien pour l'instant
        }
    }
}
    