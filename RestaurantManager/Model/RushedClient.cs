using System;

namespace RestaurantManager;

public class RushedClient : IClient
{
    public void RequestWater()
    {
        Console.WriteLine("Rushed client quickly asks for water.");
    }

    public void RequestBread()
    {
        Console.WriteLine("Rushed client quickly asks for bread.");
    }

    public void RequestMenu()
    {
        Console.WriteLine("Rushed client wants the menu right away.");
    }

    public void PlaceOrder(Order order)
    {
        Console.WriteLine("Rushed client places a hurried order.");
    }

    public void RequestBill()
    {
        Console.WriteLine("Rushed client urgently requests the bill.");
    }
    public string GetMood()
    {
        return "rushed";
    }

    public string GetStrategy()
    {
        return "quick";
    }

    public int GetNumberOfPeople()
    {
        return 2;
    }

}