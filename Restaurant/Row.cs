using System.Collections.Generic;

namespace Restaurant
{
    public class Row
    {
        public List<Table> Tables { get; private set; }
        public Row()
        {
            Tables = new List<Table>();
        }

        public void AddTable(Table table)
        {
            Tables.Add(table);
        }

        public void RemoveTable(Table table)
        {
            Tables.Remove(table);
        }
    }
}