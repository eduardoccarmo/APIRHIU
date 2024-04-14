using APIRHIU.Core.DomainObjects;
using APIRHIU.Domain.Models;
using APIRHUI.Application.Commands;
using AutoMapper;
using System.ComponentModel;

namespace APIRHUI.Application.AutoMapper
{
    public class DtoToCommand : Profile
    {
        public DtoToCommand()
        {
            CreateMap<Envelope, InserirCapaEnvelopeCommand>()
                .ConstructUsing((envelope, capaEnvelope) =>
                {
                    InserirCapaEnvelopeCommand command = new InserirCapaEnvelopeCommand(string.Empty,
                                                                                        DateTime.Parse(envelope.CreatedDate),
                                                                                        envelope.EnvelopeStatus,
                                                                                        envelope.UUID);

                    return command;
                });

            CreateMap<Document, InserirDocumentoEmpregadoCommand>()
                .ConstructUsing((documentoEmpregadoUnico, documentoEmpregado) =>
                {
                    InserirDocumentoEmpregadoCommand command = new InserirDocumentoEmpregadoCommand(documentoEmpregadoUnico.DocumentType,
                                                                                                    documentoEmpregadoUnico.UUID,
                                                                                                    string.Empty);

                    return command;
                });
        }
    }
}
