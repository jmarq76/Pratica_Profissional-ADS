using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class RedeSocialEntityTypeConfiguration : IEntityTypeConfiguration<RedeSocialModel>
    {
        public void Configure(EntityTypeBuilder<RedeSocialModel> builder)
        {
            builder
                .HasOne<PerfilPfModel>()
                .WithMany(p => p.RedesSociais)
                .HasForeignKey(r => r.IdPerfil);

            builder
                .HasOne<PerfilPjModel>()
                .WithMany(p => p.RedesSociais)
                .HasForeignKey(r => r.IdPerfil);
        }
    }
}
