﻿using APIRHIU.Core.Communication;
using APIRHIU.Core.Message;
using APIRHIU.Core.Message.CommomMessage;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using MediatR;

namespace APIRHUI.Application.Commands
{
    public class CapaEnvelopeCommandHandler :
          IRequestHandler<InserirCapaEnvelopeCommand, bool>,
          IRequestHandler<AtualizarCaminhoDocumentoEmpregadoCommand, bool>
    {
        private readonly ICapaEnvelopeEmpregadoRepository _repository;
        private readonly IMediatorHandler _mediator;
        private readonly IUnityOfWork _uow;

        public CapaEnvelopeCommandHandler(ICapaEnvelopeEmpregadoRepository repository,
                                          IMediatorHandler mediator,
                                          IUnityOfWork uow)
        {
            _repository = repository;
            _mediator = mediator;
            _uow = uow;
        }

        public async Task<bool> Handle(InserirCapaEnvelopeCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            CapaEnvelopeEmpregado capaEnvelope = new CapaEnvelopeEmpregado(string.Empty,
                                                                           request.DataCriacaoEnvelope,
                                                                           request.SituacaoEnvelope,
                                                                           request.CodigoIdentificaoEnvelope);
            _repository.Adicionar(capaEnvelope);

            foreach (var doc in request.DocumentosEnvelope)
            {
                doc.AssociarIdCapaEnvelope(capaEnvelope.Id);

                capaEnvelope.PopularListaDocumentos(doc);

                _repository.AdicionarDocumentoCapaEnvelope(doc);
            }

            return await _uow.Commit();
        }

        public async Task<bool> Handle(AtualizarCaminhoDocumentoEmpregadoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) return false;

            DocumentoEnvelopeEmpregado? documento = await _repository.ObterDocumentPorId(request.IdDocumentoEmpregado);

            documento?.SetarCaminhoFisicoArquivo(request.CaminhoDocumentoEmpregado);

            _repository.AtualizarDocumentoEmpregado(documento);

            await _uow.Commit(); 

            return true;
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
