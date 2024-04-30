using APIRHIU.Core.Message.CommomMessage;
using APIRHIU.Data.Network;
using APIRHIU.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace APIRHIU.Api.Controllers
{
    public class TesteController : BaseController
    {
        private readonly IHttpClientService _httpClientService;
        private readonly IProcessarDocumentoColaboradoService _service;

        public TesteController(IHttpClientService httpClientService, 
                               IProcessarDocumentoColaboradoService service,
                               INotificationHandler<DomainNotification> domainNotificationHandler) : base(domainNotificationHandler)
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
            var result = await _service.ProcessarDadosEnvelopeEmpregado(cpfs);

            List<string>? listaDeIds = new List<string>();

            return CustomResponse();
        }
    }
}
