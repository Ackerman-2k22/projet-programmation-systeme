namespace RestaurantManager;

public class Order
{
    private Client client;
    private MenuItem[] items;

    public Order(Client client, MenuItem[] items)
    {
        this.client = client;
        this.items = items;
    }

    public Client getClient()
    {
        return client;
    }

    public MenuItem[] getItems()
    {
        return items;
    }
}