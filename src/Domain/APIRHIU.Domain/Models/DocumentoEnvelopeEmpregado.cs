using APIRHIU.Core.DomainObjects;

namespace APIRHIU.Domain.Models
{
    public class DocumentoEnvelopeEmpregado : Entity
    {
        #region Construtores

        public DocumentoEnvelopeEmpregado(string nomeDocumento,
                                          string codigoIdentificacaoDocumento,
                                          string caminhoFisicoGravacaoDocumento,
                                          DateTime dataInsercaoDocumento)
        {
            NomeDocumento = nomeDocumento;
            CodigoIdentificacaoDocumento = codigoIdentificacaoDocumento;
            CaminhoFisicoGravacaoDocumento = caminhoFisicoGravacaoDocumento;
            DataInsercaoDocumento = dataInsercaoDocumento;
        }

        public DocumentoEnvelopeEmpregado() { }

        #endregion

        public Guid IdCapaEvelopeEmpregado { get; private set; }
        public DateTime DataInsercaoDocumento { get; private set; }
        public string NomeDocumento { get; private set; } = string.Empty;
        public string CodigoIdentificacaoDocumento { get; private set; } = string.Empty;
        public string CaminhoFisicoGravacaoDocumento { get; private set; } = string.Empty;

        #region Relacionamentos do Entity Framework

        public CapaEnvelopeEmpregado? CapaEnvelopeEmpregado { get; private set; }

        #endregion

        #region Setters

        public void AssociarIdCapaEnvelope(Guid id) => IdCapaEvelopeEmpregado = id;

        public void SetarDataInsercaoDocumento(DateTime data) => DataInsercaoDocumento = data;

        public void SetarNomeDocumento(string nomeDocumento) => NomeDocumento = nomeDocumento;

        public void SetarCodigoIdentificacaoDocumento(string codigoIdentificacaoDocumento) => CodigoIdentificacaoDocumento = codigoIdentificacaoDocumento;

        public void SetarCaminhoFisicoArquivo(string caminhoFisicoGravacaoDocumento) => CaminhoFisicoGravacaoDocumento = caminhoFisicoGravacaoDocumento;

        #endregion

    }
}
