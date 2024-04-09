﻿using APIRHIU.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRHIU.Domain.Models
{
    public class DocumentoEnvelopeEmpregado : Entity
    {
        public DocumentoEnvelopeEmpregado(int idDocumentoEnvelopeEmpregado,
                                          int idCapaEvelopeEmpregado,
                                          string? nomeDocumento,
                                          string? codigoIdentificacaoDocumento,
                                          string? caminhoFisicoGravacaoDocumento)
        {
            IdCapaEvelopeEmpregado = idCapaEvelopeEmpregado;
            NomeDocumento = nomeDocumento;
            CodigoIdentificacaoDocumento = codigoIdentificacaoDocumento;
            CaminhoFisicoGravacaoDocumento = caminhoFisicoGravacaoDocumento;
        }

        public int IdCapaEvelopeEmpregado { get; private set; }
        public DateTime DataInsercaoDocumento { get; private set; }
        public string? NomeDocumento { get; private set; }
        public string? CodigoIdentificacaoDocumento { get; private set; }
        public string? CaminhoFisicoGravacaoDocumento { get; private set; }

        #region Relacionamentos do Entity Framework

        public CapaEnvelopeEmpregado? CapaEnvelopeEmpregado { get; private set; }

        #endregion

    }
}
