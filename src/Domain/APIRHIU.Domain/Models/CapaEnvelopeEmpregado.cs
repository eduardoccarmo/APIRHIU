using APIRHIU.Core.DomainInterfaces;
using APIRHIU.Core.DomainObjects;

namespace APIRHIU.Domain.Models
{
    public class CapaEnvelopeEmpregado : Entity, IAgregateRoot
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

        public CapaEnvelopeEmpregado() { }

        public string? MatriculaEmpregado { get; private set; }
        public DateTime DataCriacaoEnvelope { get; private set; }
        public string? SituacaoEnvelope { get; private set; }
        public string? CodigoIdentificaoEnvelope { get; private set; }

        public void SetarMatricula(string? matriculaEmpregado)
        {
            MatriculaEmpregado = matriculaEmpregado;
        }

        #region Relacionamentos do Entity Framework

        public IReadOnlyCollection<DocumentoEnvelopeEmpregado>? DocumentosEnvelope { get =>  _documentosEnvelope?.ToList(); }

        #endregion
    }
}
