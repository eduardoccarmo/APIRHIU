using MediatR;

namespace APIRHIU.Core.Message.CommomMessage
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private List<DomainNotification> _domainNotifications;

        public DomainNotificationHandler()
        {
            _domainNotifications = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notification, CancellationToken cancellationToken)
        {
            _domainNotifications.Add(notification);
            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> ObterNotificacoes()
        {
            return _domainNotifications;
        }

        public virtual bool TemNotificacao()
        {
            return _domainNotifications.Any();
        }

        public void Dispose()
        {
            _domainNotifications = new List<DomainNotification>();
        }
    }
}
