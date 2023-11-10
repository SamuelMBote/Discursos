using Discursos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Discursos.DataContext.Configuration
{
    public class ProgramacaoConfiguration : IEntityTypeConfiguration<Programacao>
    {
        public void Configure(EntityTypeBuilder<Programacao> builder)
        {
            builder.ToTable("Programacao");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Orador).WithOne().HasForeignKey<Programacao>(x => x.OradorId);
            builder.HasOne(x => x.Tema).WithOne().HasForeignKey<Programacao>(x => x.TemaId);


        }
    }
}
