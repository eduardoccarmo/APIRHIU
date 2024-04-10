using APIRHIU.Data.Context;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;

namespace APIRHIU.Data.Repository
{
    public class TokenRepository : Repository<TokenAcessoUnico>, ITokenRepository
    {
        public TokenRepository(ApirhiuContext context) : base(context) { }
    }
}
