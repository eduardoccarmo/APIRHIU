namespace APIRHIU.Core.Message
{
    public abstract class Mensagem
    {
        public string MessageType { get; protected set; }
        public Guid IdMensagem { get; private set; }

        protected Mensagem()
        {
            IdMensagem = Guid.NewGuid();
            MessageType = GetType().Name;
        }
    }
}
