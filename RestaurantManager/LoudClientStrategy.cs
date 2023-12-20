using System;

namespace RestaurantManager;

public class LoudClientStrategy : IClientStrategy
{
    public void Execute(Client client)
    {
        Console.WriteLine($"Loud client {client.Name} is shouting and demanding attention.");
    }
}