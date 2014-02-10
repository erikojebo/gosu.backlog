namespace Gosu.Backlog.Models.Excel
{
    public class BacklogColumnHeader
    {
        private readonly string _title;

        public BacklogColumnHeader(string title)
        {
            _title = title;
        }

        public override string ToString()
        {
            return _title;
        }
    }
}