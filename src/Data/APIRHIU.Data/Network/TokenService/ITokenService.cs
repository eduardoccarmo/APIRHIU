using System.Security.Claims;

namespace APIRHIU.Data.Network.TokenService
{
    public interface ITokenService
    {
        ClaimsIdentity GerarPayloadIntegracao();
        string GerarJwtTokenAssinadoComCriptografiaRsa256();
    }
}
