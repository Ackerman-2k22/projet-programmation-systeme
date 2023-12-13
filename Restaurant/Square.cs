using System.Collections.Generic;

namespace Restaurant
{
    public class Square
    {
        public List<Row> Rows { get; private set; }

        public Square()
        {
            Rows = new List<Row>();
        }

        public void AddRow(Row row)
        {
            Rows.Add(row);
        }

        public void RemoveRow(Row row)
        {
            Rows.Remove(row);
        }
    }
}