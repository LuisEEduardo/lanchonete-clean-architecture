namespace Lanchonete.Domain.Interfaces;

public interface INotifier
{
    bool HasNotification();
    IList<Nofication> GetNotifications();
    void Handle(Nofication nofication);
}
