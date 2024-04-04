using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIRHIU.Data.Network.TokenService
{
    public interface ITokenService
    {
        ClaimsIdentity GerarPayloadIntegracao();
        string GerarJwtTokenAssinadoComCriptografiaRsa256();
    }
}
