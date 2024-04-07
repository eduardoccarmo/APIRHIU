using APIRHIU.Data.Network;
using Microsoft.AspNetCore.Mvc;

namespace APIRHIU.Api.Controllers
{
    public class TesteController : BaseController
    {
        private readonly IHttpClientService _httpClientService;

        public TesteController(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        [HttpGet]
        [Route("teste/api")]
        public async Task<IActionResult> teste()
        {
            var result = await _httpClientService.GerarBearerToken();

            return Ok(result);
        }

        [HttpPost]
        [Route("teste/api")]
        public async Task<IActionResult> teste2(string token)
        {
            var result = await _httpClientService.ObterEnvelopeColaborador(token);

            List<string>? listaDeIds = new List<string>();

            result?.Data?.Envelopes?.First()?.Documents?.ForEach(x => listaDeIds.Add(x.UUID));

            var doc = await _httpClientService.ObterDocumentoColaborador(result.Data.Envelopes.First().Documents.First().UUID);

            return Ok(result);
        }
    }
}
