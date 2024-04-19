using APIRHIU.Core.Message;
using APIRHIU.Domain.Models;
using FluentValidation;

namespace APIRHUI.Application.Commands
{
    public class InserirDocumentoEnvelopeCommand : Command
    {
        public InserirDocumentoEnvelopeCommand(DateTime dataInsercaoDocumento,
                                               string? nomeDocumento,
                                               string? codigoIdentificacaoDocumento,
                                               string? caminhoFisicoGravacaoDocumento)
        {
            DataInsercaoDocumento = dataInsercaoDocumento;
            NomeDocumento = nomeDocumento;
            CodigoIdentificacaoDocumento = codigoIdentificacaoDocumento;
            CaminhoFisicoGravacaoDocumento = caminhoFisicoGravacaoDocumento;
        }

        public DateTime DataInsercaoDocumento { get; private set; }
        public string? NomeDocumento { get; private set; }
        public string? CodigoIdentificacaoDocumento { get; private set; }
        public string? CaminhoFisicoGravacaoDocumento { get; private set; }
    }

    public class InserirDocumentoEnvelopeCommandValidation : AbstractValidator<InserirDocumentoEnvelopeCommand>
    {
        public InserirDocumentoEnvelopeCommandValidation()
        {
            RuleFor(x => x.CodigoIdentificacaoDocumento)
                .NotNull()
                .NotEmpty()
                .WithMessage("O codigo de identificação do documento não pode ser nulo ou vazio.");

            RuleFor(x => x.NomeDocumento)
                .NotNull()
                .NotEmpty()
                .WithMessage("O nome do documento não pode ser nulo ou vazio.");
        }
    }
}
