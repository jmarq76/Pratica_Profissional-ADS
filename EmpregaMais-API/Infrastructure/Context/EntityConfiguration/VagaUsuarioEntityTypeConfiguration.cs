using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class VagaUsuarioEntityTypeConfiguration : IEntityTypeConfiguration<VagaUsuarioModel>
    {
        public void Configure(EntityTypeBuilder<VagaUsuarioModel> builder)
        {
            builder
                .HasOne<VagaModel>()
                .WithMany(v => v.VagasUsuarios)
                .HasForeignKey(vu => vu.IdVaga);

            builder
                .HasOne<PerfilPfModel>()
                .WithMany(pf => pf.VagasUsuarios)
                .HasForeignKey(vu => vu.IdPerfilPf)
                .IsRequired(false);
        }
    }
}
