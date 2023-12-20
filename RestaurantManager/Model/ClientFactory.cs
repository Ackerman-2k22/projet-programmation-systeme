using System;

namespace RestaurantManager;

public class ClientFactory
{
    public static IClient CreateClient(string type, string mood, string strategy, int numberOfPeople)
    {
        switch (type)
        {
            case "calm":
                return new CalmClient();
            case "loud":
                return new LoudClient();
            case "rushed":
                return new RushedClient();
            default:
                throw new ArgumentException("Invalid client type.");
        }
    }
}