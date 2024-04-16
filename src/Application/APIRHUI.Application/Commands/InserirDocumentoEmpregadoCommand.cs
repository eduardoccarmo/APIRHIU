using APIRHIU.Core.Message;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APIRHUI.Application.Commands
{
    public class InserirDocumentoEmpregadoCommand : Command
    {
        #region Construtores

        public InserirDocumentoEmpregadoCommand(string? nomeDocumento,
                                                string? codigoIdentificacaoDocumento,
                                                string? caminhoFisicoGravacaoDocumento,
                                                DateTime dataInsercaoDocumento)
        {
            NomeDocumento = nomeDocumento;
            CodigoIdentificacaoDocumento = codigoIdentificacaoDocumento;
            CaminhoFisicoGravacaoDocumento = caminhoFisicoGravacaoDocumento;
            DataInsercaoDocumento = dataInsercaoDocumento;
        }

        #endregion

        #region Propriedades

        public Guid IdCapaEvelopeEmpregado { get; private set; }
        public DateTime DataInsercaoDocumento { get; private set; }
        public string? NomeDocumento { get; private set; }
        public string? CodigoIdentificacaoDocumento { get; private set; }
        public string? CaminhoFisicoGravacaoDocumento { get; private set; }

        #endregion

        #region Setters

        public void AssociarIdCapaEnvelope(Guid id)
        {
            IdCapaEvelopeEmpregado = id;
        }

        #endregion 

        #region Métodos 

        public override bool EhValido()
        {
            ValidationResult = new InserirDocumentoEmpregadoCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        #endregion
    }

    public class InserirDocumentoEmpregadoCommandValidation : AbstractValidator<Command>
    {
        public InserirDocumentoEmpregadoCommandValidation()
        {
            
        }
    }
}
