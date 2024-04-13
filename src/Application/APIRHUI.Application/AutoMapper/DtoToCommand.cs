using APIRHIU.Core.DomainObjects;
using APIRHIU.Domain.Models;
using AutoMapper;
using System.ComponentModel;

namespace APIRHUI.Application.AutoMapper
{
    public class DtoToCommand : Profile
    {
        public DtoToCommand()
        {
            CreateMap<Envelope, CapaEnvelopeEmpregado>()
                .ConstructUsing((envelope, capaEnvelope) =>
                {
                    CapaEnvelopeEmpregado capaEnvelopeEmpregado = new CapaEnvelopeEmpregado();

                    capaEnvelopeEmpregado.SetarMatricula(string.Empty);
                    capaEnvelopeEmpregado.SetarDataCriacaoEnvelope(DateTime.Parse(envelope.CreatedDate));
                    capaEnvelopeEmpregado.SetarCodigoIdentificaCaoEnvelope(envelope.UUID);
                    capaEnvelopeEmpregado.SetarSituacaoEnvelope(envelope.EnvelopeStatus);
                    
                    return capaEnvelopeEmpregado;
                }
                );

            CreateMap<Document, DocumentoEnvelopeEmpregado>()
                .ConstructUsing((documentoEmpregadoUnico, documentoEmpregado) =>
                {
                    DocumentoEnvelopeEmpregado documento = new DocumentoEnvelopeEmpregado();

                    documento.SetarNomeDocumento(documentoEmpregadoUnico.DocumentType);

                    return documento;
                });
        }
    }
}
