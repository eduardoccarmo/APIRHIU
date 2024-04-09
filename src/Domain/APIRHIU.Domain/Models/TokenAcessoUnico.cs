using APIRHIU.Core.DomainObjects;

namespace APIRHIU.Domain.Models
{
    public class TokenAcessoUnico : Entity
    {
        public string? CodigoTokenAcesso { get; private set; }
        public DateTime DataExpiracaoToken { get; private set; }
    }    
}
