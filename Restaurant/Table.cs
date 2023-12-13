namespace Restaurant
{
    public class Table
    {
        public int Capacity { get; private set; }
        public bool Occupied { get; private set; }
        public Coordinate Position { get; set; }

        public Table(int capacity, Coordinate position)
        {
            Capacity = capacity;
            Position = position;
            Occupied = false;
        }

        public void OccupyTable()
        {
            Occupied = true;
        }

        public void ReleaseTable()
        {
            Occupied = false;
        }
    }
}