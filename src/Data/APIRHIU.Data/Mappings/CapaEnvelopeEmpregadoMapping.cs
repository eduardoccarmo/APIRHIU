using APIRHIU.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIRHIU.Data.Mappings
{
    public class CapaEnvelopeEmpregadoMapping : IEntityTypeConfiguration<CapaEnvelopeEmpregado>
    {
        public void Configure(EntityTypeBuilder<CapaEnvelopeEmpregado> builder)
        {
            builder.ToTable("capa_envelope_empregado");

            builder.HasKey(x => x.Id)
                .HasName("id_capa_envelope_empregado");

            builder.Property(x => x.MatriculaEmpregado)
                .HasColumnName("matricula_empregado_envelope");

            builder.Property(x => x.DataCriacaoEnvelope)
                .HasColumnName("data_criacao_envelope");

            builder.Property(x => x.SituacaoEnvelope)
                .HasColumnName("situacao_envelope");

            builder.Property(x => x.CodigoIdentificaoEnvelope)
                .HasColumnName("codigo_identificacao_envelope");
        }
    }
}
