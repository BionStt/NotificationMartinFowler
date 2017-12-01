namespace NotificationMartinFowler.Domain.Notifications
{
    public class Error
    {
        public Error(string message)
        {
            Message = message;
        }

        public string Message { get; }
        public override string ToString()
        {
            return Message;
        }
    }
}