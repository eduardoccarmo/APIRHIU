using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRHUI.Application.Commands
{
    public class CapaEnvelopeCommandHandler
        : IRequestHandler<InserirCapaEnvelopeCommand, bool>
    {
        private readonly ICapaEnvelopeEmpregadoRepository _repository;

        public CapaEnvelopeCommandHandler(ICapaEnvelopeEmpregadoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(InserirCapaEnvelopeCommand request, CancellationToken cancellationToken)
        {
            CapaEnvelopeEmpregado capaEnvelope = new CapaEnvelopeEmpregado(string.Empty, 
                                                                           request.DataCriacaoEnvelope, 
                                                                           request.SituacaoEnvelope, 
                                                                           request.CodigoIdentificaoEnvelope);

            return await _repository.Adicionar(capaEnvelope) > 0;
        }
    }
}
