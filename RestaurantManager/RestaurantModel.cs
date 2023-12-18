namespace RestaurantManager
{
    public class RestaurantModel
    {
        public RestaurantMap Map { get; private set; }

        public RestaurantModel()
        {
            Map = new RestaurantMap();
        }
    }
}