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
            _context.DocumentoEnvelopeEmpregados.AsQueryable().AsNoTracking();
            _context.Add(documento);
        }

        public void SalvarMudancasDocumentoEmpregado()
        {
            _context.SaveChangesAsync();
        }
    }
}
