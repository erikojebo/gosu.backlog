namespace Gosu.Backlog.Models.Excel
{
    public class BacklogColumnHeader
    {
        public readonly string Title;
        public readonly int ColumnIndex;

        public BacklogColumnHeader(string title, int columnIndex)
        {
            Title = title;
            ColumnIndex = columnIndex;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}