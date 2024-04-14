using APIRHIU.Core.Message;
using FluentValidation;

namespace APIRHUI.Application.Commands
{
    public class InserirCapaEnvelopeCommand : Command
    {
        #region Propriedades Privadas

        private IList<InserirDocumentoEmpregadoCommand> _documentosEnvelope;

        #endregion

        #region Construtores

        public InserirCapaEnvelopeCommand(string? matriculaEmpregado, 
                                          DateTime dataCriacaoEnvelope, 
                                          string? situacaoEnvelope, 
                                          string? codigoIdentificaoEnvelope)
        {
            MatriculaEmpregado = matriculaEmpregado;
            DataCriacaoEnvelope = dataCriacaoEnvelope;
            SituacaoEnvelope = situacaoEnvelope;
            CodigoIdentificaoEnvelope = codigoIdentificaoEnvelope;

            _documentosEnvelope = new List<InserirDocumentoEmpregadoCommand>();
        }

        #endregion

        #region Propriedades

        public string? MatriculaEmpregado { get; private set; }
        public DateTime DataCriacaoEnvelope { get; private set; }
        public string? SituacaoEnvelope { get; private set; }
        public string? CodigoIdentificaoEnvelope { get; private set; }
        public IReadOnlyCollection<InserirDocumentoEmpregadoCommand> DocuDocumentosEnvelope => _documentosEnvelope.ToList();

        #endregion

        #region Metodos

        public override bool EhValido()
        {
            ValidationResult = new InserirCapaEnvelopeCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        #endregion
    }

    public class InserirCapaEnvelopeCommandValidation : AbstractValidator<InserirCapaEnvelopeCommand>
    {
        public InserirCapaEnvelopeCommandValidation()
        {

        }
    }

}
