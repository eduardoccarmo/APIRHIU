using MediatR;

namespace APIRHIU.Core.Message.CommomMessage
{
    public class DomainNotification : Mensagem, INotification
    {
        public DomainNotification(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; private set; } = string.Empty;
        public string Value { get; private set; } = string.Empty;
    }
}
