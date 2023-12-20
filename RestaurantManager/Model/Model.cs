using System.Collections.Generic;
using System.Xml.Schema;
using Microsoft.Xna.Framework;

namespace RestaurantManager;

public class Model
{
    public ChefDeRang ChefDeRang { get; set; }
    public MaitreDHotel MaitreDHotel { get; set; }
    public Client Client { get; set; }
    public List<Table> Tables { get; set; }
    public Vector2 _chefDeRangPosition;
    public Vector2 _maitreDHotelPosition;
    public List<Client> AllClients { get; set; }
    public Vector2 _clientPosition;
    public Vector2 _tablePosition;
    public bool IsClientHandled { get; set; }
    public bool IsClientArrived { get; set; }
    
    public bool IsChefDeRangHandle { get; set; }


    public Model()
    {
        Client = new Client("Ackerman","groupe","calm",10);
        Client calmClient = new Client("John","menu 1" ,"calm", 2);
        calmClient.ExecuteStrategy();

        Client loudClient = new Client("Mike","menu 2" ,"loud", 4);
        loudClient.ExecuteStrategy();

        Client rushedClient = new Client("Sarah", "menu 3","rushed", 1);
        rushedClient.ExecuteStrategy();
        AllClients = new List<Client>(); // Initialisez la liste des clients
        AllClients.Add(new Client("Ackerman", "groupe", "calm", 10)); // Ajoutez le premier client
        AllClients.Add(new Client("John", "menu 1", "calm", 2)); // Ajoutez les autres clients
        AllClients.Add(new Client("Mike", "menu 2", "loud", 4));
        AllClients.Add(new Client("Sarah", "menu 3", "rushed", 1));
        
        
        ChefDeRang = new ChefDeRang("John");
        MaitreDHotel maitreDHotel = MaitreDHotel.GetInstance("Jean");
        Tables = new List<Table>()
        {
            new Table(5, new Coordinate(50, 100)),
            new Table(10, new Coordinate(150, 300)),
            new Table(12, new Coordinate(650, 200)),
            new Table(2, new Coordinate(700, 400))
        };
    }
    
}