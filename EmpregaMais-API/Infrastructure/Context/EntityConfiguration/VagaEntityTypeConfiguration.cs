using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class VagaEntityTypeConfiguration : IEntityTypeConfiguration<VagaModel>
    {
        public void Configure(EntityTypeBuilder<VagaModel> builder)
        {
            builder
                .HasOne<PerfilPjModel>()
                .WithMany(p => p.Vagas)
                .HasForeignKey(v => v.IdPerfil);
        }
    }
}
