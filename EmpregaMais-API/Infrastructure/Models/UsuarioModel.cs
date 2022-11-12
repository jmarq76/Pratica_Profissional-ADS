using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.USUARIOS)]
    public class UsuarioModel : BaseModel
    {
        public Guid? IdPerfil { get; set; }
        public Guid? IdLogin { get; set; }
        public string? Nome { get; set; }
        public string? CpfCnpj { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        [NotMapped]
        public List<ContatoModel> Contatos { get; set; }
        [NotMapped]
        public List<EnderecoModel> Enderecos { get; set; }
        [NotMapped]
        public LoginModel Login { get; set; }
        [NotMapped]
        public PerfilPfModel PerfilPf { get; set; }
        [NotMapped]
        public PerfilPjModel PerfilPj { get; set; }
    }
}
