using APIRHIU.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRHIU.Data.Mappings
{
    public class DocumentoEnvelopeEmpregadoMapping : IEntityTypeConfiguration<DocumentoEnvelopeEmpregado>
    {
        public void Configure(EntityTypeBuilder<DocumentoEnvelopeEmpregado> builder)
        {
            throw new NotImplementedException();
        }
    }
}
