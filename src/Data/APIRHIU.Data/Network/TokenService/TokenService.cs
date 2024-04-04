using APIRHIU.Core.DomainObjects;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace APIRHIU.Data.Network.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly IOptions<AppSettings> _settings;

        public TokenService(IOptions<AppSettings> settings)
        {
            _settings = settings;
        }

        public ClaimsIdentity GerarPayloadIntegracao()
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim("aud", "https://identity.acesso.io"));
            ci.AddClaim(new Claim("iss", "svcaccene@b874cfcf-3576-494a-8d25-9e03cfd37ecd.iam.acesso.io"));
            ci.AddClaim(new Claim("scope", "*"));
            ci.AddClaim(new Claim("exp", DateTime.UtcNow.ToString()));
            ci.AddClaim(new Claim("iat", DateTime.UtcNow.AddHours(1).ToString()));

            return ci;
        }

        public string GerarJwtTokenAssinadoComCriptografiaRsa256()
        {
            var rsa = RSA.Create();
            rsa.ImportFromPem(_settings.Value.PrivateKey);

            var credentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256);

            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = credentials,
                Subject = GerarPayloadIntegracao(),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor) as JwtSecurityToken;
            token?.Payload.Remove("nbf");

            return tokenHandler.WriteToken(token);
        }
    }
}
