using System;

namespace RestaurantManager
{
    public class ChefDeCuisine
    {
        private static ChefDeCuisine instance;
        private static readonly object lockObject = new object();

        private Model _model;
        public string Name { get; private set; }
        public Coordinate Position { get; set; }

        private ChefDeCuisine(string name)
        {
            Name = name;
            Position = new Coordinate(250, 200);
        }

        public static ChefDeCuisine GetInstance(string name)
        {
            if (instance == null)
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ChefDeCuisine(name);
                    }
                }
            }
            return instance;
        }

        public void AssignTable(Table table, ChefDeRang chefDeRang)
        {
            chefDeRang.AssignTable(table);
        }

        public void ReceiveOrder(Table table)
        {
            // Recevoir une commande de la table
        }

        public void PrepareDish(Table table)
        {
            // Préparer un plat pour la table
        }

        public void ServeDish(Table table)
        {
            // Servir le plat à la table
        }
    }
}