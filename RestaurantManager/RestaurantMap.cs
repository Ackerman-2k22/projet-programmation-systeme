using System.Collections.Generic;

namespace RestaurantManager
{
    public class RestaurantMap
    {
        public List<Square> Squares { get; private set; }

        public RestaurantMap()
        {
            Squares = new List<Square>();
        }

        public void AddSquare(Square square)
        {
            Squares.Add(square);
        }

        public void RemoveSquare(Square square)
        {
            Squares.Remove(square);
        }
    }
}