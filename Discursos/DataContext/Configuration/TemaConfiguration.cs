using Discursos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Discursos.DataContext.Configuration
{
    public class TemaConfiguration : IEntityTypeConfiguration<Tema>
    {
        public void Configure(EntityTypeBuilder<Tema> builder)
        {
            builder.ToTable("Temas");
            builder.HasKey(x => x.Id);
            builder.HasAlternateKey(x => x.Numero);
            builder.Property(x => x.Descricao).HasMaxLength(255).IsRequired();
            builder.Property(x => x.DuracaoEmMinutos).IsRequired();
            builder.Property(x => x.UltimaModificacaoCadastro).HasDefaultValue(DateTime.Now).ValueGeneratedOnAddOrUpdate();
        }
    }
}
