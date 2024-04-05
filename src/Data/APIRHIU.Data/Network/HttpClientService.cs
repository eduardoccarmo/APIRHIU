using APIRHIU.Core.DomainObjects;
using APIRHIU.Data.Network.TokenService;
using Microsoft.Extensions.Options;

namespace APIRHIU.Data.Network
{
    public class HttpClientService : IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOptions<AppSettings> _options;
        private readonly ITokenService _tokenService;

        public HttpClientService(IHttpClientFactory httpClientFactory, 
                                 IOptions<AppSettings> options, 
                                 ITokenService tokenService)
        {
            _httpClientFactory = httpClientFactory;
            _options = options;
            _tokenService = tokenService;
        }

        public async Task<BearerToken> GerarBearerToken()
        {
            BearerToken? bearerToken = new();

            string assertion = _tokenService.GerarJwtTokenAssinadoComCriptografiaRsa256();

            var content = new { grant_type = "urn:ietf:params:oauth:grant-type:jwt-bearer", assertion = assertion };

            var body = new Dictionary<string, string>
            {
                { "grant_type", content.grant_type },
                { "assertion", content.assertion }
            };

            var requestBody = new FormUrlEncodedContent(body);

            HttpRequestMessage requestMessage = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                Content = requestBody,
                RequestUri = new Uri(_options.Value.BaseAdress + _options.Value.RessourceUrl)
            };

            try
            {
                using var client = _httpClientFactory.CreateClient();

                using var response = await client.SendAsync(requestMessage);

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                {
                    string? result = await response.Content.ReadAsStringAsync();

                    if (result != null)
                    {
                        bearerToken = System.Text.Json.JsonSerializer.Deserialize<BearerToken>(result);
                    }
                }

            }
            catch (HttpRequestException) { }

            return bearerToken; 
        }
    }
}

