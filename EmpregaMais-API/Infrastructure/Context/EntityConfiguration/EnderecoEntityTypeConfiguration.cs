using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class EnderecoEntityTypeConfiguration : IEntityTypeConfiguration<EnderecoModel>
    {
        public void Configure(EntityTypeBuilder<EnderecoModel> builder)
        {
            builder
                .HasOne<UsuarioModel>()
                .WithMany(u => u.Enderecos)
                .HasForeignKey(e => e.IdUsuario);
        }
    }
}
