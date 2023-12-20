namespace RestaurantManager;

public class Client
{
    private string nom;
    private string strategy;
    private string mood;
    private float billAmount;
    public string Name {get; set; }
    public int NumberOfPeople { get; set; }
    public Coordinate Position { get; set; }

    public Client(string nom, string strategy, string mood, int numberOfPeople)
    {
        this.nom = nom;
        this.strategy = strategy;
        this.mood = mood;
        Position = new Coordinate(250, 250);
        NumberOfPeople = numberOfPeople;
        this.billAmount = billAmount;
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