namespace SysPizzaria.Application.Notifications;

public class Notification
{
    public string Message { get; private set; }

    public Notification(string message)
    {
        Message = message;
    }
}