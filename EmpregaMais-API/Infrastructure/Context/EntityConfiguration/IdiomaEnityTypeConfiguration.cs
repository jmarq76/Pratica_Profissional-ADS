using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class IdiomaEnityTypeConfiguration : IEntityTypeConfiguration<IdiomaModel>
    {
        public void Configure(EntityTypeBuilder<IdiomaModel> builder)
        {
            builder
                .HasOne<VagaModel>()
                .WithMany(v => v.Idiomas)
                .HasForeignKey(i => i.IdVaga);
        }
    }
}
