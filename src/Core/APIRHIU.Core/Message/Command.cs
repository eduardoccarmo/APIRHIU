using FluentValidation.Results;
using MediatR;

namespace APIRHIU.Core.Message
{
    public abstract class Command : Mensagem, IRequest<bool>
    {
        public ValidationResult? ValidationResult { get; set; }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
