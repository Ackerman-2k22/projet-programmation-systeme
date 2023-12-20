using System;

namespace RestaurantManager;

public class CalmClientStrategy : IClientStrategy
{
    public void Execute(Client client)
    {
        Console.WriteLine($"Calm client {client.Name} is placing an order calmly.");
    }
}