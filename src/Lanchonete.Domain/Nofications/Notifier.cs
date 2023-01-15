using Lanchonete.Domain.Interfaces;

namespace Lanchonete.Domain;

public class Notifier : INotifier
{

    private IList<Nofication> _notifications;

    public Notifier()
    {
        _notifications = new List<Nofication>();
    }

    public IList<Nofication> GetNotifications()
        => _notifications;

    public void Handle(Nofication nofication)
    {
        _notifications.Add(nofication);
    }

    public bool HasNotification()
        => _notifications.Any();
}
