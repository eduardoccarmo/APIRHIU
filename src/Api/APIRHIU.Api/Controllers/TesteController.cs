
using APIRHIU.Data.Network;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;

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
            var result = await _httpClientService.RecuperarDossieAdmissao(token);

            return Ok(result);
        }
    }
}
