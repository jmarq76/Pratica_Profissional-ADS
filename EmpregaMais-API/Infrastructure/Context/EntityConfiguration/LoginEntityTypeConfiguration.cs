using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class LoginEntityTypeConfiguration : IEntityTypeConfiguration<LoginModel>
    {
        public void Configure(EntityTypeBuilder<LoginModel> builder)
        {
            builder
                .HasOne<UsuarioModel>()
                .WithOne(u => u.Login)
                .HasForeignKey<LoginModel>(l => l.IdUsuario);
        }
    }
}
