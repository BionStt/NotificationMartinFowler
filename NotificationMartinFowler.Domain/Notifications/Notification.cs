using System.Collections.Generic;

namespace NotificationMartinFowler.Domain.Notifications
{
    public class Notification
    {
        public Notification()
        {
            Errors = new List<Error>();
        }

        public List<Error> Errors { get; set; }
        public bool HasErrors => 0 != Errors.Count;

        public bool IncludesError(Error error)
        {
            return Errors.Contains(error);
        }
    }
}