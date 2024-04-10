using APIRHIU.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace APIRHIU.Data.Context
{
    public class ApirhiuContext : DbContext
    {
        public ApirhiuContext(DbContextOptions<ApirhiuContext> options) : base (options) { }

        public DbSet<CapaEnvelopeEmpregado> CapaEnvelopes { get; set; }
        public DbSet<DocumentoEnvelopeEmpregado> DocumentoEnvelopeEmpregados { get; set; }
        public DbSet<TokenAcessoUnico> TokenAcessos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApirhiuContext).Assembly);
        }
    }
}
