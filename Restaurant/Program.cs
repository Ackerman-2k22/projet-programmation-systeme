using System;
namespace Restaurant
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            RestaurantMap restaurantMap = new RestaurantMap();
            Square square1 = new Square();
            Square square2 = new Square();
            
            restaurantMap.AddSquare(square1);
            restaurantMap.AddSquare(square2);

            Row row1 = new Row();
            Row row2 = new Row();
            
            square1.AddRow(row1);
            square2.AddRow(row2);

            Coordinate table1Position = new Coordinate(1.0f, 2.0f);
            Table table1 = new Table(4, table1Position);

            Coordinate table2Position = new Coordinate(3.0f, 4.0f);
            Table table2 = new Table(8, table2Position);
            
            row1.AddTable(table1);
            row2.AddTable(table2);

            Coordinate position = table1.Position;
            Console.WriteLine("Position de la table 1 : X=" +position.X + ", Y=" +position.Y);

            Coordinate newPosition = new Coordinate(2.0f, 3.0f);
            table1.Position = newPosition;

            position = table1.Position;
            
            Console.WriteLine("Nouvelle position de la table 1 : X=" +position.X+"et Y="+position.Y);
            Console.WriteLine("La capacité de la table 1 est : "+table1.Capacity+" et celle de la table 2 est : "+table2.Capacity);
        }
    }
}