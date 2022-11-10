using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.PERFILPF)]
    public class PerfilPfModel : BaseModel
    {
        public Guid IdUsuario { get; set; }
        public string? CargoDesejado { get; set; }
        public string? AreasDesejads { get; set; }
        public int PretensaoSalarial { get; set; }
        public string? ResumoProfissional { get; set; }
        public string? InformacoesComplementares { get; set; }
        public string? Escolaridade { get; set; }

        [NotMapped]
        public UsuarioModel Usuario { get; set; }
        [NotMapped]
        public List<VagaUsuarioModel> VagasUsuarios { get; set; }
    }
}
