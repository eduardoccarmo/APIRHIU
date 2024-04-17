using APIRHIU.Core.DomainObjects;
using APIRHIU.Domain.Models;
using APIRHUI.Application.Commands;
using AutoMapper;
using AutoMapper.Internal.Mappers;

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

                    foreach (var item in envelope?.Documents)
                    {
                        DocumentoEnvelopeEmpregado doc = new DocumentoEnvelopeEmpregado(item.DocumentType,
                                                                                        item.UUID,
                                                                                        string.Empty,
                                                                                        DateTime.Parse(item.CreatedDate));

                        command.PopularListaDocumentos(doc);
                    }

                    return command;
                });

            //CreateMap<Document, DocumentoEnvelopeEmpregado>()
            //    .ConstructUsing((documentoEmpregadoUnico, documentoEmpregado) =>
            //    {
            //        DocumentoEnvelopeEmpregado command = new DocumentoEnvelopeEmpregado(documentoEmpregadoUnico.DocumentType,
            //                                                                            documentoEmpregadoUnico.UUID,
            //                                                                            string.Empty,
            //                                                                            DateTime.Parse(documentoEmpregadoUnico.CreatedDate));

            //        return command;
            //    });
        }
    }
}
