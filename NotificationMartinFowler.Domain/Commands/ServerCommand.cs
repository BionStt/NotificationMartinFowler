using NotificationMartinFowler.Domain.Dto;
using NotificationMartinFowler.Domain.Notifications;

namespace NotificationMartinFowler.Domain.Commands
{
    public class ServerCommand
    {
        public ServerCommand(DataTransferObject dataTransferObject)
        {
            DartaTransferObject = dataTransferObject;
        }

        protected DataTransferObject DartaTransferObject;
        protected Notification Notification => DartaTransferObject.Notification;
    }
}