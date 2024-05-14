using APIRHIU.Core.Enums;
using APIRHIU.Core.Message.CommomMessage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace APIRHIU.Api.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly DomainNotificationHandler _domainNotificationHandler;

        protected BaseController(INotificationHandler<DomainNotification> domainNotificationHandler)
        {
            _domainNotificationHandler = (DomainNotificationHandler)domainNotificationHandler;
        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    sucesso = true,
                    statusCode = statusCode
                });
            }

            if (TemAviso())
            {
                return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    {"Mensagens",  _domainNotificationHandler
                                   .ObterNotificacoes()
                                   .Where(x => x.Key == ETipoMensagem.warning.ToString())
                                   .Select(x => x.Value).
                                    ToArray()
                    }
                }));
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"Mensagens",  _domainNotificationHandler
                               .ObterNotificacoes()
                               .Where(x => x.Key == ETipoMensagem.error.ToString())
                               .Select(x => x.Value)
                               .ToArray()
                }
            }));
        }

        protected bool OperacaoValida()
        {
            return !_domainNotificationHandler.TemNotificacao();
        }

        protected bool TemAviso()
        {
            return _domainNotificationHandler.TemAviso();
        }
    }
}

