using System.Collections.Generic;

namespace Gosu.Backlog.Models.Excel
{
    public class BacklogItemRow
    {
        public IList<BacklogItemCell> Cells = new List<BacklogItemCell>();

        public void Add(object value)
        {
            Cells.Add(new BacklogItemCell(value));
        }
    }
}