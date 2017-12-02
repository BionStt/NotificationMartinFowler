namespace NotificationMartinFowler.Domain.Notifications
{
    public class Error
    {
        private readonly string _message;
        public Error(string message)
        {
            _message = message;
        }

        public override string ToString()
        {
            return _message;
        }
    }
}