using System.Collections;

namespace NotificationMartinFowler.Domain.Notifications
{
    public class Notification
    {
        public IList Errors { get; set; } = new ArrayList();

        public bool HasErrors => 0 != Errors.Count;

        public bool IncludesError(Error error)
        {
            return Errors.Contains(error);
        }
    }
}