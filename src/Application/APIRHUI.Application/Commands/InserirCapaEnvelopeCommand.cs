using APIRHIU.Core.Message;

namespace APIRHUI.Application.Commands
{
    public class InserirCapaEnvelopeCommand : Command
    {
        
        
        
        
        
        public override bool EhValido()
        {
            ValidationResult = new FluentValidation.Results.ValidationResult();

            return ValidationResult.IsValid;
        }
    }

}
