using APIRHIU.Core.DomainObjects;
using APIRHIU.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIRHIU.Data.Mappings
{
    public class CapaEnvelopeEmpregadoMapping : IEntityTypeConfiguration<CapaEnvelopeEmpregado>
    {
        public void Configure(EntityTypeBuilder<CapaEnvelopeEmpregado> builder)
        {
            throw new NotImplementedException();
        }
    }
}
