using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace RestaurantManager;

public class Model
{
    public ChefDeRang ChefDeRang { get; set; }
    public List<Table> Tables { get; set; }
    public Vector2 _chefDeRangPosition;
    public Vector2 _tablePosition;

    public Model()
    {
        ChefDeRang = new ChefDeRang("John");
        Tables = new List<Table>()
        {
            new Table(4, new Coordinate(50, 100)),
            new Table(4, new Coordinate(150, 300)),
            new Table(4, new Coordinate(650, 200)),
            new Table(2, new Coordinate(700, 400))
        };
    }
}