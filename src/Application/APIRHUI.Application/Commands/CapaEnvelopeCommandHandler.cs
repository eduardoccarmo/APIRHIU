using APIRHIU.Core.Communication;
using APIRHIU.Core.Message;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using MediatR;

namespace APIRHUI.Application.Commands
{
    public class CapaEnvelopeCommandHandler :
          IRequestHandler<InserirCapaEnvelopeCommand, bool>,
          IRequestHandler<InserirDocumentoEmpregadoCommand, bool>
    {
        private readonly ICapaEnvelopeEmpregadoRepository _repository;
        private readonly IDocumentoEnvelopeEmpregadoRepository _documentoEnvelopeEmpregadoRepository;
        private readonly IMediatorHandler _mediator;

        public CapaEnvelopeCommandHandler(ICapaEnvelopeEmpregadoRepository repository,
                                          IDocumentoEnvelopeEmpregadoRepository documentoEnvelopeEmpregadoRepository,
                                          IMediatorHandler mediator)
        {
            _repository = repository;
            _documentoEnvelopeEmpregadoRepository = documentoEnvelopeEmpregadoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(InserirCapaEnvelopeCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            CapaEnvelopeEmpregado capaEnvelope = new CapaEnvelopeEmpregado(string.Empty,
                                                                           request.DataCriacaoEnvelope,
                                                                           request.SituacaoEnvelope,
                                                                           request.CodigoIdentificaoEnvelope);

            bool comitIsValid = await _repository.Adicionar(capaEnvelope) > 0;

            if (comitIsValid)
            {
                foreach (var doc in request.DocumentosEnvelope)
                {
                    doc.AssociarIdCapaEnvelope(capaEnvelope.Id);

                    await _mediator.EnviarComando(doc);
                }
            }

            return comitIsValid;
        }

        public async Task<bool> Handle(InserirDocumentoEmpregadoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            DocumentoEnvelopeEmpregado documento = new DocumentoEnvelopeEmpregado(request.IdCapaEvelopeEmpregado,
                                                                                  request.NomeDocumento,
                                                                                  request.CodigoIdentificacaoDocumento,
                                                                                  string.Empty,
                                                                                  request.DataInsercaoDocumento);

            documento.AssociarIdCapaEnvelope(request.IdCapaEvelopeEmpregado);

            return await _documentoEnvelopeEmpregadoRepository.Adicionar(documento) > 0; 
        }

        private bool ValidarComando(Command message)
        {
            if (message.EhValido()) return true;

            return false;
        }
    }
}
