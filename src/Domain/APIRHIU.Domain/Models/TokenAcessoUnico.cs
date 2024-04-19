using APIRHIU.Core.DomainObjects;

namespace APIRHIU.Domain.Models
{
    public class TokenAcessoUnico : Entity
    {
        public TokenAcessoUnico(string? codigoTokenAcesso, DateTime dataExpiracaoToken)
        {
            CodigoTokenAcesso = codigoTokenAcesso;
            DataExpiracaoToken = dataExpiracaoToken;
        }

        public TokenAcessoUnico() { }

        public string? CodigoTokenAcesso { get; private set; }
        public DateTime DataExpiracaoToken { get; private set; }
    }    
}
