using APIRHIU.Core.Message;
using FluentValidation;

namespace APIRHUI.Application.Commands
{
    public class AtualizarCaminhoDocumentoEmpregadoCommand : Command
    {
        #region Propriedades

        public Guid IdDocumentoEmpregado { get; private set; }
        public string? CaminhoDocumentoEmpregado { get; set; }

        #endregion

        #region Métodos

        public override bool EhValido()
        {
            ValidationResult = new AtualizarCaminhoDocumentoEmpregadoCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        #endregion 
    }

    public class AtualizarCaminhoDocumentoEmpregadoCommandValidation : AbstractValidator<AtualizarCaminhoDocumentoEmpregadoCommand>
    {
        public AtualizarCaminhoDocumentoEmpregadoCommandValidation()
        {
            RuleFor(x => x.IdDocumentoEmpregado)
                .NotEqual(Guid.Empty)
                .WithMessage("É obrigatório informar o Id do documento que será atualizado.");

            RuleFor(x => x.CaminhoDocumentoEmpregado)
                .NotNull()
                .NotEmpty()
                .WithMessage("É obrigatório informar o caminho que o documento foi salvo.");
        }
    }
}
