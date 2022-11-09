using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class PerfilPjEntityTypeConfiguration : IEntityTypeConfiguration<PerfilPjModel>
    {
        public void Configure(EntityTypeBuilder<PerfilPjModel> builder)
        {
            builder
                .HasOne<UsuarioModel>()
                .WithOne(u => u.PerfilPj)
                .HasForeignKey<PerfilPjModel>(pj => pj.IdUsuario);
        }
    }
}
