using FluentValidation.Results;
using SysPizzaria.Application.Notifications;

namespace SysPizzaria.Application.Interfaces
{
    public interface INotificator
    {
        void Handle(Notification notification);
        void Handle(List<ValidationFailure> failures);
        void HandleNotFoundResource();
        IEnumerable<Notification> GetNotifications();
        bool HasNotification { get; }
        bool IsNotFoundResource { get; }
    }
}