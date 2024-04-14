using APIRHIU.Data.Network;
using APIRHIU.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIRHIU.Api.Controllers
{
    public class TesteController : BaseController
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IProcessarDocumentoColaboradoService _service;

        public TesteController(IHttpClientService httpClientService, 
                               IProcessarDocumentoColaboradoService service)
        {
            _httpClientService = httpClientService;
            _service = service;
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
        public async Task<IActionResult> teste2(List<string> cpfs)
        {
            var result = await _service.GravarDadosControleIntegracao(cpfs);

            List<string>? listaDeIds = new List<string>();

            return Ok(result);
        }
    }
}
