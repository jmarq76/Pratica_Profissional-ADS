using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Context.EntityConfiguration
{
    public class ContatoEntityTypeConfiguration : IEntityTypeConfiguration<ContatoModel>
    {
        public void Configure(EntityTypeBuilder<ContatoModel> builder)
        {
            builder
                .HasOne<UsuarioModel>()
                .WithMany(u => u.Contatos)
                .HasForeignKey(c => c.IdUsuario);
        }
    }
}
