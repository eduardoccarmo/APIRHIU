using APIRHIU.Core.Communication;
using APIRHIU.Core.Message;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using MediatR;
using System.Runtime.CompilerServices;

namespace APIRHUI.Application.Commands
{
    public class CapaEnvelopeCommandHandler :
          IRequestHandler<InserirCapaEnvelopeCommand, bool>
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

            
            foreach (var doc in request.DocumentosEnvelope)
            {
                DocumentoEnvelopeEmpregado documento = new DocumentoEnvelopeEmpregado(doc.NomeDocumento,
                                                                                      doc.CodigoIdentificacaoDocumento,
                                                                                      string.Empty,
                                                                                      doc.DataInsercaoDocumento);
                documento.AssociarIdCapaEnvelope(capaEnvelope.Id);

                capaEnvelope.PopularListaDocumentos(documento);
                
            }

            return await _repository.Adicionar(capaEnvelope) > 0;
        }

        private bool ValidarComando(Command command)
        {
            if (command.EhValido()) return true;

            return false;
        }
    }
}
