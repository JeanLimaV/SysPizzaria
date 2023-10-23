using FluentValidation.Results;
using SysPizzaria.Application.Interfaces;

namespace SysPizzaria.Application.Notifications;

public class Notificator : INotificator
{
    private bool _notFoundResource;
    private readonly List<Notification> _notifications;

    public Notificator()
    {
        _notifications = new List<Notification>();
    }

    public void Handle(Notification notification)
    {
        if (_notFoundResource)
            throw new InvalidOperationException("Cannot call Handle when there are NotFoundResouce!");

        _notifications.Add(notification);
    }

    public void Handle(List<ValidationFailure> failures)
    {
        failures
            .ForEach(err => Handle(new Notification(err.ErrorMessage)));
    }

    public void HandleNotFoundResource()
    {
        if (HasNotification)
            throw new InvalidOperationException("Cannot call HandleNotFoundResource when there are notifications!");

        _notFoundResource = true;
    }

    public IEnumerable<Notification> GetNotifications() => _notifications;

    public bool HasNotification  => _notifications.Any();

    public bool IsNotFoundResource => _notFoundResource;
}