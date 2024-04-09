using APIRHIU.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRHIU.Domain.Models
{
    public class CapaEnvelopeEmpregado : Entity
    {
        private readonly IList<DocumentoEnvelopeEmpregado>? _documentosEnvelope;

        public CapaEnvelopeEmpregado(string? matriculaEmpregado, 
                                     DateTime dataCriacaoEnvelope, 
                                     string? situacaoEnvelope, 
                                     string? codigoIdentificaoEnvelope)
        {
            MatriculaEmpregado = matriculaEmpregado;
            DataCriacaoEnvelope = dataCriacaoEnvelope;
            SituacaoEnvelope = situacaoEnvelope;
            CodigoIdentificaoEnvelope = codigoIdentificaoEnvelope;

            _documentosEnvelope = new List<DocumentoEnvelopeEmpregado>();
        }

        public string? MatriculaEmpregado { get; private set; }
        public DateTime DataCriacaoEnvelope { get; private set; }
        public string? SituacaoEnvelope { get; private set; }
        public string? CodigoIdentificaoEnvelope { get; private set; }

        #region Relacionamentos do Entity Framework

        public IReadOnlyCollection<DocumentoEnvelopeEmpregado>? DocumentosEnvelope { get =>  _documentosEnvelope?.ToList(); }

        #endregion
    }
}
