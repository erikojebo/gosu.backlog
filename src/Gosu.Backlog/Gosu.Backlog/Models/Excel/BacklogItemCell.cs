namespace Gosu.Backlog.Models.Excel
{
    public class BacklogItemCell
    {
        private readonly object _value;

        public BacklogItemCell(object value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return (_value ?? string.Empty).ToString();
        }
    }
}