using System;

namespace RestaurantManager;

public class LoudClient : IClient
{
    public void RequestWater()
    {
        Console.WriteLine("Loud client shouts for water.");
    }

    public void RequestBread()
    {
        Console.WriteLine("Loud client shouts for bread.");
    }

    public void RequestMenu()
    {
        Console.WriteLine("Loud client demands the menu.");
    }

    public void PlaceOrder(Order order)
    {
        Console.WriteLine("Loud client places an order with a loud voice.");
    }

    public void RequestBill()
    {
        Console.WriteLine("Loud client demands the bill immediately.");
    }
    public string GetMood()
    {
        return "loud";
    }

    public string GetStrategy()
    {
        return "aggressive";
    }

    public int GetNumberOfPeople()
    {
        return 4;
    }
}