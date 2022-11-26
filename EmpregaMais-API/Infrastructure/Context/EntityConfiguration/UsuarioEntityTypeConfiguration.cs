using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder
                .HasOne<LoginModel>()
                .WithOne(l => l.Usuario)
                .HasForeignKey<UsuarioModel>(u => u.IdLogin);

            builder
                .HasOne<PerfilPfModel>()
                .WithOne(pf => pf.Usuario)
                .HasForeignKey<UsuarioModel>(u => u.IdPerfil)
                .IsRequired(false);

            builder
                .HasOne<PerfilPjModel>()
                .WithOne(pj => pj.Usuario)
                .HasForeignKey<UsuarioModel>(u => u.IdPerfil)
                .IsRequired(false);
        }
    }
}
