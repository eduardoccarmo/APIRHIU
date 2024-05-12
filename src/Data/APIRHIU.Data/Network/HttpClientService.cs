using APIRHIU.Core.Communication;
using APIRHIU.Core.DomainObjects;
using APIRHIU.Core.Message.CommomMessage;
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
        private readonly IMediatorHandler _mediatorHandler;


        public HttpClientService(HttpClient httpClient,
                                 IOptions<AppSettings> options,
                                 ITokenService tokenService,
                                 IMediatorHandler mediatorHandler)
        {
            _httpClient = httpClient;
            _options = options;
            _tokenService = tokenService;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<string?> GerarBearerToken()
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

            return bearerToken?.access_token;
        }

        public async Task<RetornoUnico> ObterEnvelopeColaborador(string? token)
        {
            var ret = new RetornoUnico();

            var body = new { cpf = "07119115685" };

            //12331044708

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

        public async Task<byte[]?> ObterDocumentoColaborador(string uiid)
        {
            byte[]? byteArrayArquivoEmpregado = null;

            var message = new HttpRequestMessage
            {
                RequestUri = new Uri(_options.Value.BaseAdressSign + _options.Value.EndPointArquivo + $"{uiid}"),
                Method = HttpMethod.Get
            };

            try
            {
                using var response = await _httpClient.SendAsync(message);

                if (response.EnsureSuccessStatusCode().IsSuccessStatusCode)
                { 
                    byteArrayArquivoEmpregado = await response.Content.ReadAsByteArrayAsync();

                    return byteArrayArquivoEmpregado;
                }
            }
            catch (HttpRequestException) 
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("Aviso", $"Erro ao obter o documento {uiid}"));
            }

            return byteArrayArquivoEmpregado;
        }
    }
}

