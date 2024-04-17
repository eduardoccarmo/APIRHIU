using APIRHIU.Core.DomainObjects;

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

        public CapaEnvelopeEmpregado() { }

        public string? MatriculaEmpregado { get; private set; }
        public DateTime DataCriacaoEnvelope { get; private set; }
        public string? SituacaoEnvelope { get; private set; }
        public string? CodigoIdentificaoEnvelope { get; private set; }

        #region Relacionamentos do Entity Framework

        public IReadOnlyCollection<DocumentoEnvelopeEmpregado>? DocumentosEnvelope { get =>  _documentosEnvelope?.ToList(); }

        #endregion

        #region Setters

        public void SetarMatricula(string? matriculaEmpregado) => MatriculaEmpregado = matriculaEmpregado;

        public void SetarDataCriacaoEnvelope(DateTime dataCriacaoEnvelope) => DataCriacaoEnvelope = dataCriacaoEnvelope;

        public void SetarSituacaoEnvelope(string? situacao) => SituacaoEnvelope = situacao;

        public void SetarCodigoIdentificaCaoEnvelope(string? codigoIdentificaoEnvelope) => CodigoIdentificaoEnvelope = codigoIdentificaoEnvelope;

        public void PopularListaDocumentos(DocumentoEnvelopeEmpregado documento) => _documentosEnvelope?.Add(documento);

        #endregion
    }
}
