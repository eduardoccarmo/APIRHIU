using APIRHIU.Data.Context;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace APIRHIU.Data.Repository
{
    public class CapaEnvelopeEmpregadoRepository : Repository<CapaEnvelopeEmpregado>, ICapaEnvelopeEmpregadoRepository
    {
        private readonly ApirhiuContext _context;

        public CapaEnvelopeEmpregadoRepository(ApirhiuContext context) : base(context) 
        {
            _context = context;
        }

        public void AdicionarDocumentoCapaEnvelope(DocumentoEnvelopeEmpregado documento)
        {
            _context.Add(documento);
        }

        public async void AtualizarDocumentoEmpregado(Guid id)
        {
            DocumentoEnvelopeEmpregado? documentoEnvelopeEmpregado = await ObterDocumentPorId(id);
            
            _context.DocumentoEnvelopeEmpregados.Update(documentoEnvelopeEmpregado);
        }

        public async Task<DocumentoEnvelopeEmpregado?> ObterDocumentPorId(Guid? id)
        {
            return await _context.DocumentoEnvelopeEmpregados.FindAsync(id);
        }

        public void SalvarMudancasDocumentoEmpregado()
        {
            _context.SaveChangesAsync();
        }
    }
}
