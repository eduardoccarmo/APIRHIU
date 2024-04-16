using APIRHIU.Core.DomainObjects;
using APIRHUI.Application.Commands;
using AutoMapper;

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
                                                                                                    string.Empty,
                                                                                                    DateTime.Parse(documentoEmpregadoUnico.CreatedDate));

                    return command;
                });
        }
    }
}
