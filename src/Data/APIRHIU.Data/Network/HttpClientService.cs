using APIRHIU.Core.DomainObjects;
using APIRHIU.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;

namespace APIRHIU.Data.Network
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<AppSettings> _options;
        private readonly ITokenService _tokenService;

        public HttpClientService(HttpClient httpClient,
                                 IOptions<AppSettings> options,
                                 ITokenService tokenService)
        {
            _httpClient = httpClient;
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
                RequestUri = new Uri(_options.Value.BaseAdressIdentity + _options.Value.EndPointAutenticacao)
            };

            try
            {
                using var response = await _httpClient.SendAsync(requestMessage);

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

            await _tokenService.GravarTokenAcesso(bearerToken);

            return bearerToken;
        }

        public async Task<RetornoUnico> ObterEnvelopeColaborador(string token)
        {
            var ret = new RetornoUnico();

            var body = new { cpf = "10902174630" };

            var serializedBody = System.Text.Json.JsonSerializer.Serialize(body);

            var requestMessage = new StringContent(serializedBody);
            requestMessage.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var requestUrl = _options.Value.BaseAdressSign + _options.Value.EndPointEnvelope;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            try
            {
                using var responseRequest = await _httpClient.PostAsync(requestUrl, requestMessage);

                if (responseRequest.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await responseRequest.Content.ReadAsStringAsync();

                    ret = System.Text.Json.JsonSerializer.Deserialize<RetornoUnico>(result);
                }
            }
            catch (HttpRequestException) { }

            return ret;
        }

        public async Task<string> ObterDocumentoColaborador(string uiid)
        {

            var message = new HttpRequestMessage
            {
                RequestUri = new Uri(_options.Value.BaseAdressSign + _options.Value.EndPointArquivo + $"{uiid}"),
                Method = HttpMethod.Get
            };

            using var response = await _httpClient.SendAsync(message);

            var teste = await response.Content.ReadAsByteArrayAsync();

            File.WriteAllBytes("C:\\Users\\eduar\\OneDrive\\Área de Trabalho\\testeDocUnico.pdf", teste);

            return string.Empty;
        }
    }
}

