using APIRHIU.Core.DomainObjects;
using System.Security.Claims;

namespace APIRHIU.Domain.Interfaces
{
    public interface ITokenService
    {
        ClaimsIdentity GerarPayloadIntegracao();
        string GerarJwtTokenAssinadoComCriptografiaRsa256();
        Task<bool> GravarTokenAcesso(BearerToken? token);
    }
}
