namespace Gosu.Backlog.Models
{
    public class ErrorModel
    {
        public readonly string ErrorMessage;

        public ErrorModel() : this("An error occurred :(")
        {
        }

        public ErrorModel(string message)
        {
            ErrorMessage = message;
        }
    }
}