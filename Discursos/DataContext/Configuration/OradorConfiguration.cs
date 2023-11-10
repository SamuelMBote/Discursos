using Discursos.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Discursos.DataContext.Configuration
{
    public class OradorConfiguration : IEntityTypeConfiguration<Orador>
    {
        public void Configure(EntityTypeBuilder<Orador> builder)
        {
            builder.ToTable("Oradores");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).HasMaxLength(100).IsRequired();
            builder.HasOne(x => x.Congregacao).WithMany(x => x.OradoresDaCongregacao).HasForeignKey(x=>x.CongregacaoId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Designacao).WithMany().HasForeignKey(x=>x.DesignacaoId);
        }
    }
}
