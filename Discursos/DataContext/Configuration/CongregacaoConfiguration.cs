using Discursos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Discursos.DataContext.Configuration
{
    public class CongregacaoConfiguration : IEntityTypeConfiguration<Congregacao>
    {
        public void Configure(EntityTypeBuilder<Congregacao> builder)
        {
            builder.ToTable("Congregacoes");
            builder.HasKey(p => p.Id);
            builder.HasAlternateKey(p => new { p.Nome, p.Cidade, p.UF });
            builder.Property(p => p.Cidade).HasMaxLength(255).IsRequired();
            builder.Property(p => p.UF).HasMaxLength(2).IsRequired();
            builder.HasOne(x => x.Tipo).WithMany().HasForeignKey(x => x.TipoId);
            builder.HasMany(x => x.OradoresDaCongregacao).WithOne();
            builder.HasOne(x => x.Coordenadora).WithMany().HasForeignKey(x=>x.CoordenadoraId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
