using Discursos.Entities;
using Discursos.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Discursos.DataContext.Configuration
{
    public class TipoConfiguration : IEntityTypeConfiguration<Tipo>
    {


        public void Configure(EntityTypeBuilder<Tipo> builder)
        {
            builder.ToTable("Tipos");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Codigo).HasDefaultValue(ETipoCongregacao.Congregacao).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(100).IsRequired();
            
        }
    }
}
