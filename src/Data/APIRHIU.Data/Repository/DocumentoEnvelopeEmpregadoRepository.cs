using APIRHIU.Data.Context;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIRHIU.Data.Repository
{
    public class DocumentoEnvelopeEmpregadoRepository : Repository<DocumentoEnvelopeEmpregado>, IDocumentoEnvelopeEmpregadoRepository
    {
        public DocumentoEnvelopeEmpregadoRepository(ApirhiuContext context) : base(context) { }
    }
}
