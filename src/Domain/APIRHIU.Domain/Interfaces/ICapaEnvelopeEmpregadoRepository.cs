using APIRHIU.Domain.Models;

namespace APIRHIU.Domain.Interfaces
{
    public interface ICapaEnvelopeEmpregadoRepository : IRepository<CapaEnvelopeEmpregado>
    {
        void AdicionarDocumentoCapaEnvelope(DocumentoEnvelopeEmpregado documento);

        void SalvarMudancasDocumentoEmpregado();

        void AtualizarDocumentoEmpregado(DocumentoEnvelopeEmpregado? documento);

        Task<DocumentoEnvelopeEmpregado?> ObterDocumentPorId(Guid? id);


    }
}
