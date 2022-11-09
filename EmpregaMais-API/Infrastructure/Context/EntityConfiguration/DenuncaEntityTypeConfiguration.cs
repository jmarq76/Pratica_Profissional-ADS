using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class DenuncaEntityTypeConfiguration : IEntityTypeConfiguration<DenunciaModel>
    {
        public void Configure(EntityTypeBuilder<DenunciaModel> builder)
        {
            builder
                .HasOne<VagaModel>()
                .WithMany(v => v.Denuncias)
                .HasForeignKey(d => d.IdVaga);

            builder
                .HasOne<PerfilPjModel>()
                .WithMany(pj => pj.Denuncias)
                .HasForeignKey(d => d.IdPerfilPj);
        }
    }
}
