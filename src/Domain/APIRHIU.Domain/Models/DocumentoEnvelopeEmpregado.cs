using APIRHIU.Core.DomainObjects;

namespace APIRHIU.Domain.Models
{
    public class DocumentoEnvelopeEmpregado : Entity
    {
        #region Construtores

        public DocumentoEnvelopeEmpregado(Guid idCapaEnvelopeEmpregado,
                                          string? nomeDocumento,
                                          string? codigoIdentificacaoDocumento,
                                          string? caminhoFisicoGravacaoDocumento,
                                          DateTime dataInsercaoDocumento)
        {
            IdCapaEvelopeEmpregado = idCapaEnvelopeEmpregado;
            NomeDocumento = nomeDocumento;
            CodigoIdentificacaoDocumento = codigoIdentificacaoDocumento;
            CaminhoFisicoGravacaoDocumento = caminhoFisicoGravacaoDocumento;
            DataInsercaoDocumento = dataInsercaoDocumento;
        }

        public DocumentoEnvelopeEmpregado() { }

        #endregion

        public Guid IdCapaEvelopeEmpregado { get; private set; }
        public DateTime DataInsercaoDocumento { get; private set; }
        public string? NomeDocumento { get; private set; }
        public string? CodigoIdentificacaoDocumento { get; private set; }
        public string? CaminhoFisicoGravacaoDocumento { get; private set; }

        #region Relacionamentos do Entity Framework

        public CapaEnvelopeEmpregado? CapaEnvelopeEmpregado { get; private set; }

        #endregion

        #region Setters

        public void SetarNomeDocumento(string nomeDocumento)
        {
            NomeDocumento = nomeDocumento;
        }

        public void AssociarIdCapaEnvelope(Guid id)
        {
            IdCapaEvelopeEmpregado = id;
        }

        #endregion

    }
}
