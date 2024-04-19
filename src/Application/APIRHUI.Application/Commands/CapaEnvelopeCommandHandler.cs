using APIRHIU.Core.Communication;
using APIRHIU.Core.Message;
using APIRHIU.Core.Message.CommomMessage;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using MediatR;

namespace APIRHUI.Application.Commands
{
    public class CapaEnvelopeCommandHandler :
          IRequestHandler<InserirCapaEnvelopeCommand, bool>
    {
        private readonly ICapaEnvelopeEmpregadoRepository _repository;
        private readonly IMediatorHandler _mediator;

        public CapaEnvelopeCommandHandler(ICapaEnvelopeEmpregadoRepository repository,
                                          IMediatorHandler mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(InserirCapaEnvelopeCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            CapaEnvelopeEmpregado capaEnvelope = new CapaEnvelopeEmpregado(string.Empty,
                                                                           request.DataCriacaoEnvelope,
                                                                           request.SituacaoEnvelope,
                                                                           request.CodigoIdentificaoEnvelope);

            foreach (var doc in request.DocumentosEnvelope)
            {
                doc.AssociarIdCapaEnvelope(capaEnvelope.Id);

                capaEnvelope.PopularListaDocumentos(doc);
            }

            await _repository.Adicionar(capaEnvelope);

            return await _repository.SaveChanges() > 0;
        }

        private bool ValidarComando(Command command)
        {
            if (command.EhValido()) return true;

            foreach (var error in command.ValidationResult.Errors)
            {
                _mediator.PublicarNotificacao(new DomainNotification(command.MessageType, error.ErrorMessage));
            }

            return false;
        }
    }
}
