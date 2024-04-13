using APIRHIU.Core.Message;
using FluentValidation;

namespace APIRHUI.Application.Commands
{
    public class InserirCapaEnvelopeCommand : Command
    {
        public InserirCapaEnvelopeCommand(string? matriculaEmpregado, 
                                          DateTime dataCriacaoEnvelope, 
                                          string? situacaoEnvelope, 
                                          string? codigoIdentificaoEnvelope)
        {
            MatriculaEmpregado = matriculaEmpregado;
            DataCriacaoEnvelope = dataCriacaoEnvelope;
            SituacaoEnvelope = situacaoEnvelope;
            CodigoIdentificaoEnvelope = codigoIdentificaoEnvelope;
        }

        public string? MatriculaEmpregado { get; private set; }
        public DateTime DataCriacaoEnvelope { get; private set; }
        public string? SituacaoEnvelope { get; private set; }
        public string? CodigoIdentificaoEnvelope { get; private set; }

        public override bool EhValido()
        {
            ValidationResult = new InserirCapaEnvelopeCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }

    public class InserirCapaEnvelopeCommandValidation : AbstractValidator<InserirCapaEnvelopeCommand>
    {
        public InserirCapaEnvelopeCommandValidation()
        {

        }
    }

}
