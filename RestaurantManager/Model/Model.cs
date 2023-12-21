using System.Collections.Generic;
using System.Xml.Schema;
using Microsoft.Xna.Framework;
using RestaurantManager.Cuisine;

namespace RestaurantManager;

public class Model
{
    public ChefDeRang ChefDeRang { get; set; }
    public MaitreDHotel MaitreDHotel { get; set; }
    public Client Client { get; set; }
    public Groupe Groupe { get; set; }
    public ChefDeCuisine ChefDeCuisine { get; set; }
    public ChefDePartie ChefDePartie { get; set; }
    public Serveur Serveur { get; set; }
    public Plongeur Plongeur { get; set; }
    public List<Table> Tables { get; set; }
    public Vector2 _chefDeRangPosition;
    public Vector2 _chefDeRangPosition2;
    public Vector2 _maitreDHotelPosition;
    public List<Client> AllClients { get; set; }
    public Vector2 _clientPosition;
    public Vector2 _groupePosition;
    
    public Vector2 _serveurPosition;
    public Vector2 _comptoirPosition;
    public Vector2 _commisDeSallePosition;
    public Vector2 _chefDePartiePosition;
    public Vector2 _chefDeCuisinePosition;
    public Vector2 _commisDeCuisinePosition;
    public Vector2 _plongeurPosition;
    public Vector2 _restaurantPosition;
    public Vector2 _tablePosition;
    public bool IsClientHandled { get; set; }
    public bool IsClientArrived { get; set; }
    public bool IsChefDeRangHandle { get; set; }
    public bool IsMenuCommunicationDone { get; set; }
    public bool IsRecipeCommunicationDone { get; set; }
    public bool IsPreparationCompleted { get; set; }
    public bool IsDishDeliveryDone { get; set; }
    public bool IsDishServedToClient { get; set; }

    public Model()
    {
        Client = new Client("Ackerman","client","calm",1);
        Groupe = new Groupe("Levi","groupe","rushed",7);
        //ChefDeRang = new ChefDeRang("Samuel");
        ChefDeCuisine chefDeCuisine = ChefDeCuisine.GetInstance("Jeannot");
        ChefDePartie = new ChefDePartie("Yoann","",22,"");
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
        ChefDeRang = new ChefDeRang("Yann");
        MaitreDHotel maitreDHotel = MaitreDHotel.GetInstance("Jean");
        Tables = new List<Table>()
        {
            new Table(10, new Coordinate(730, 415)),
            new Table(5, new Coordinate(730, 183)),
            new Table(1, new Coordinate(323, 443)),
            new Table(2, new Coordinate(323, 152))
        };
    }
    
}