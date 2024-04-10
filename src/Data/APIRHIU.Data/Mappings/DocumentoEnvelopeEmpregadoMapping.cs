using APIRHIU.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIRHIU.Data.Mappings
{
    public class DocumentoEnvelopeEmpregadoMapping : IEntityTypeConfiguration<DocumentoEnvelopeEmpregado>
    {
        public void Configure(EntityTypeBuilder<DocumentoEnvelopeEmpregado> builder)
        {
            builder.ToTable("documento_envelope_empregado");

            builder.HasKey(x => x.Id)
                .HasName("id_documento_envelope_empregado");

            builder.Property(x => x.IdCapaEvelopeEmpregado)
                .HasColumnName("id_capa_envelope_empregado");

            builder.Property(x => x.DataInsercaoDocumento)
                .HasColumnName("data_insercao");

            builder.Property(x => x.CodigoIdentificacaoDocumento)
                .HasColumnName("codigo_identificacao_documento");

            builder.Property(x => x.CaminhoFisicoGravacaoDocumento)
                .HasColumnName("caminho_fisico_gravacao_documento");

            builder.HasOne(x => x.CapaEnvelopeEmpregado)
                .WithMany(x => x.DocumentosEnvelope)
                .HasForeignKey(x => x.Id);
        }
    }
}
