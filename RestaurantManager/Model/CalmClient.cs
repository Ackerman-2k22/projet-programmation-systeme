using System;

namespace RestaurantManager;

public class CalmClient : IClient
{
    public void RequestWater()
    {
        Console.WriteLine("Calm client requests water.");
    }

    public void RequestBread()
    {
        Console.WriteLine("Calm client requests bread.");
    }

    public void RequestMenu()
    {
        Console.WriteLine("Calm client requests the menu.");
    }

    public void PlaceOrder(Order order)
    {
        Console.WriteLine("Calm client places an order.");
    }

    public void RequestBill()
    {
        Console.WriteLine("Calm client requests the bill.");
    }
    public string GetMood()
    {
        return "calm";
    }

    public string GetStrategy()
    {
        return "default";
    }

    public int GetNumberOfPeople()
    {
        return 1;
    }
}