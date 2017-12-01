using System;
using System.Collections;

namespace NotificationMartinFowler.Domain.Notifications
{
    public class Notification
    {
        public IList Errors => new ArrayList();
        public bool HasErrors => 0 != Errors.Count;

        public bool IncludesError(Error error)
        {
            try
            {
                Errors.Add(error);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}