using APIRHIU.Domain.Models;
using APIRHUI.Application.Commands;
using AutoMapper;

namespace APIRHUI.Application.AutoMapper
{
    public class CommandToDomain : Profile
    {
        public CommandToDomain()
        {
            CreateMap<InserirCapaEnvelopeCommand, CapaEnvelopeEmpregado>()
                .ConstructUsing((command, domain) =>
                {
                    CapaEnvelopeEmpregado capa = new CapaEnvelopeEmpregado(string.Empty,
                                                                           command.DataCriacaoEnvelope,
                                                                           command.SituacaoEnvelope,
                                                                           command.CodigoIdentificaoEnvelope);

                    foreach(var doc in command.DocumentosEnvelope)
                    {
                        DocumentoEnvelopeEmpregado documento = new DocumentoEnvelopeEmpregado(doc.NomeDocumento,
                                                                                              doc.CodigoIdentificacaoDocumento,
                                                                                              string.Empty,
                                                                                              doc.DataInsercaoDocumento);

                        documento.AssociarIdCapaEnvelope(capa.Id);

                        capa.PopularListaDocumentos(documento);
                    }

                    return capa;
                });
        }
    }
}
