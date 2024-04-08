using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRHIU.Domain.Models
{
    public class CapaEnvelopeEmpregado
    {
        private readonly IList<DocumentoEnvelopeEmpregado>? _documentosEnvelope;

        public CapaEnvelopeEmpregado(int idCapaEnvelopeEmpregado, 
                                     string? matriculaEmpregado, 
                                     DateTime dataCriacaoEnvelope, 
                                     string? situacaoEnvelope, 
                                     string? codigoIdentificaoEnvelope)
        {
            IdCapaEnvelopeEmpregado = idCapaEnvelopeEmpregado;
            MatriculaEmpregado = matriculaEmpregado;
            DataCriacaoEnvelope = dataCriacaoEnvelope;
            SituacaoEnvelope = situacaoEnvelope;
            CodigoIdentificaoEnvelope = codigoIdentificaoEnvelope;

            _documentosEnvelope = new List<DocumentoEnvelopeEmpregado>();
        }

        public int IdCapaEnvelopeEmpregado { get; private set; }
        public string? MatriculaEmpregado { get; private set; }
        public DateTime DataCriacaoEnvelope { get; private set; }
        public string? SituacaoEnvelope { get; private set; }
        public string? CodigoIdentificaoEnvelope { get; private set; }

        #region Relacionamentos do Entity Framework

        public IReadOnlyCollection<DocumentoEnvelopeEmpregado>? DocumentosEnvelope { get =>  _documentosEnvelope?.ToList(); }

        #endregion
    }
}
