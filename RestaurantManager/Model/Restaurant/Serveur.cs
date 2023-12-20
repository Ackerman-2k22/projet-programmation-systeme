namespace RestaurantManager;

public class Serveur
{
    private Table[] tables;
    private int maxPlates;
    public Coordinate Position { get; set; }

    public Serveur(string name, string position, float salary, string section, int maxPlates)
    {
        tables = new Table[0];
        this.maxPlates = maxPlates;
    }

    public void addTable(Table table)
    {
        // Ajouter une table
    }

    public void removeTable(Table table)
    {
        // Supprimer une table
    }

    public void serveClient(Client client)
    {
        // Servir un client
    }

    public void collectPlates()
    {
        // Collecter les assiettes
    }

    public void serveBread(Table table)
    {
        // Servir du pain
    }

    public void serveWater(Table table)
    {
        // Servir de l'eau
    }
    

    public void clearTable(Table table)
    {
        // Nettoyer une table
    }  
}