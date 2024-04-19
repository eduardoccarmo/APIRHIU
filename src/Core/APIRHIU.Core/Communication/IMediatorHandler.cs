using APIRHIU.Core.Message;
using APIRHIU.Core.Message.CommomMessage;

namespace APIRHIU.Core.Communication
{
    public interface IMediatorHandler
    {
        Task<bool> EnviarComando<T>(T comando) where T : Command;
        Task PublicarNotificacao<T>(T notificacao) where T : DomainNotification;
    }
}
