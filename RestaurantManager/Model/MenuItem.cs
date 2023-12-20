namespace RestaurantManager;

public class MenuItem
{
    private string name;
    private float price;

    public MenuItem(string name, float price)
    {
        this.name = name;
        this.price = price;
    }

    public string getName()
    {
        return name;
    }

    public float getPrice()
    {
        return price;
    }
}