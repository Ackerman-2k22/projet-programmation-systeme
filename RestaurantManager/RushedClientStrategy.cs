using System;

namespace RestaurantManager;

public class RushedClientStrategy : IClientStrategy
{
    public void Execute(Client client)
    {
        Console.WriteLine($"Rushed client {client.Name} is in a hurry and wants quick service.");
    }
}