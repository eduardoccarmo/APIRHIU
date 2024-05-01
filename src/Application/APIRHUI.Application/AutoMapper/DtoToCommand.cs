﻿using APIRHIU.Core.DomainObjects;
using APIRHIU.Domain.Models;
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
                    InserirCapaEnvelopeCommand command = new InserirCapaEnvelopeCommand("3040038",
                                                                                        DateTime.Parse(envelope.CreatedDate),
                                                                                        envelope.EnvelopeStatus,
                                                                                        envelope.UUID);

                    foreach (var doc in envelope.Documents)
                    {
                        DocumentoEnvelopeEmpregado documento = new DocumentoEnvelopeEmpregado(doc.DocumentType,
                                                                                              doc.UUID,
                                                                                              string.Empty,
                                                                                              DateTime.Parse(doc.CreatedDate));

                        command.PopularListaDocumentos(documento);
                    }

                    return command;
                });
        }
    }
}
