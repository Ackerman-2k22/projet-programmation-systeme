namespace RestaurantManager;

public interface IClient
{
    void RequestWater();
    void RequestBread();
    void RequestMenu();
    void PlaceOrder(Order order);
    void RequestBill();
    string GetMood();
    string GetStrategy();
    int GetNumberOfPeople();
}