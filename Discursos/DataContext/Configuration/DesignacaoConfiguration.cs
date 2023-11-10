using Discursos.Entities;
using Discursos.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Discursos.DataContext.Configuration
{
    public class DesignacaoConfiguration : IEntityTypeConfiguration<Designacao>
    {
        public void Configure(EntityTypeBuilder<Designacao> builder)
        {
            builder.ToTable("Designacoes");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Codigo).HasDefaultValue(EDesignacao.Anciao).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(100).IsRequired();

        }
    }
}
