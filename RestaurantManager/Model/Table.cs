using System;

namespace RestaurantManager
{
    public class Table : IDisposable
    {
        //public bool _occupied;
        private RestaurantModel _restaurantModel;
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
            if (!Occupied)
            {
                Occupied = true;
//                _restaurantModel.NotifyTableOccupied(this);
            }
        }

        public void ReleaseTable()
        {
            if (Occupied)
            {
                Occupied = false;
                _restaurantModel.NotifyTableReleased(this);
            }
        }

        public void Dispose()
        {
            ReleaseTable();
        }
    }
}
