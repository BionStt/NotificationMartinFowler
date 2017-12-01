using NotificationsMartinFowler.Domain.Dto;
using NotificationsMartinFowler.Domain.Notifications;

namespace NotificationsMartinFowler.Domain.Commands
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