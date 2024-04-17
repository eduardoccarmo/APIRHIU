using APIRHIU.Data.Context;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;

namespace APIRHIU.Data.Repository
{
    public class CapaEnvelopeEmpregadoRepository : Repository<CapaEnvelopeEmpregado>, ICapaEnvelopeEmpregadoRepository
    {
        public CapaEnvelopeEmpregadoRepository(ApirhiuContext context) : base(context) { }
    }
}
