using NotificationMartinFowler.Domain.Notifications;

namespace NotificationMartinFowler.Domain.Dto
{
    public class DataTransferObject
    {
        public Notification Notification { get; set; } = new Notification();
    }
}