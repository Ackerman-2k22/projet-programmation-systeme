using Microsoft.Xna.Framework;

namespace RestaurantManager
{
    public class Coordinate
    {
        public Vector2 Position { get; set; }

        public Coordinate(float x, float y)
        {
            Position = new Vector2(x, y);
        }

        public Coordinate(Vector2 position)
        {
            Position = position;
        }
    }
}