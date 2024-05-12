using APIRHIU.Core.Message;
using APIRHIU.Domain.Models;
using FluentValidation;

namespace APIRHUI.Application.Commands
{
    public class InserirCapaEnvelopeCommand : Command
    {
        #region Propriedades Privadas

        private IList<DocumentoEnvelopeEmpregado> _documentosEnvelope;

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

            _documentosEnvelope = new List<DocumentoEnvelopeEmpregado>();
        }

        #endregion

        #region Propriedades
        public Guid Id { get; private set; }
        public string? MatriculaEmpregado { get; private set; }
        public DateTime DataCriacaoEnvelope { get; private set; }
        public string? SituacaoEnvelope { get; private set; }
        public string? CodigoIdentificaoEnvelope { get; private set; }
        public IReadOnlyCollection<DocumentoEnvelopeEmpregado> DocumentosEnvelope => _documentosEnvelope.ToList();

        #endregion

        #region Metodos

        public override bool EhValido()
        {
            ValidationResult = new InserirCapaEnvelopeCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }

        public void PopularListaDocumentos(DocumentoEnvelopeEmpregado documento)
        {
            _documentosEnvelope?.Add(documento);
        }

        public void SetarIdCommand(Guid id)
        {
            Id = id;
        }

        #endregion
    }

    public class InserirCapaEnvelopeCommandValidation : AbstractValidator<InserirCapaEnvelopeCommand>
    {
        public InserirCapaEnvelopeCommandValidation()
        {
            RuleFor(x => x.CodigoIdentificaoEnvelope)
                .NotNull()
                .NotEmpty()
                .WithMessage("O codigo de identificação do envelope não pode ser nulo ou vazio.");

            RuleForEach(x => x.DocumentosEnvelope)
                .SetValidator(new DocumentoEmpregadoValidation());
        }
    }

    public class DocumentoEmpregadoValidation : AbstractValidator<DocumentoEnvelopeEmpregado>
    {
        public DocumentoEmpregadoValidation()
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
