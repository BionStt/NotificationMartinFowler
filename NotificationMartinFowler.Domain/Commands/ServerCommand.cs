using NotificationMartinFowler.Domain.Dto;
using NotificationMartinFowler.Domain.Notifications;

namespace NotificationMartinFowler.Domain.Commands
{
    public class ServerCommand
    {
        public ServerCommand(DataTransferObject data)
        {
            Data = data;
        }

        protected DataTransferObject Data { get; }
        public Notification Notification => Data.Notification;
    }
}