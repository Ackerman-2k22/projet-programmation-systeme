namespace RestaurantManager;


public class Groupe
{

    private IClientStrategy clientStrategy;
    private string nom;
    private string strategy;
    private string mood;
    private float billAmount;
    public string Name {get; set; }
    public int NumberOfPeople { get; set; }
    public Coordinate Position { get; set; }

    public Groupe(string nom, string strategy, string mood, int numberOfPeople)
    {
        this.nom = nom;
        this.strategy = strategy;
        Position = new Coordinate(920, 730);
        NumberOfPeople = numberOfPeople;
        this.billAmount = billAmount;
        switch (mood)
        {
            case "calm":
                clientStrategy = new CalmClientStrategy();
                break;
            case "loud":
                clientStrategy = new LoudClientStrategy();
                break;
            case "rushed":
                clientStrategy = new RushedClientStrategy();
                break;
            default:
                clientStrategy = new CalmClientStrategy();
                break;
        }
    }

    public string Nom()
    {
        return nom;
    }

    public string getStrategy()
    {
        return strategy;
    }

    public string getMood()
    {
        return mood;
    }

    public float getBillAmount()
    {
        return billAmount;
    }

    public void requestWater()
    {
        // Demander de l'eau
    }

    public void requestBread()
    {
        // Demander du pain
    }
    

    public void requestMenu()
    {
        // Demander le menu
    }

    public void placeOrder(Order order)
    {
        // Passer une commande
    }

    public void requestBill()
    {
        // Demander l'addition
    }

}