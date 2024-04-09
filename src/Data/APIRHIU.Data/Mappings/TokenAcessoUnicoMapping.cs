using APIRHIU.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIRHIU.Data.Mappings
{
    public class TokenAcessoUnicoMapping : IEntityTypeConfiguration<TokenAcessoUnico>
    {
        public void Configure(EntityTypeBuilder<TokenAcessoUnico> builder)
        {
            builder.ToTable("controle_token_autenticacao_unico");

            builder.HasKey(t => t.Id)
                .HasName("identificador_codigo_acesso");

            builder.Property(t => t.CodigoTokenAcesso)
                .HasColumnName("codigo_token_acesso");

            builder.Property(t => t.DataExpiracaoToken)
                .HasColumnName("data_expiracao_token");
        }
    }
}
