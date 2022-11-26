using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.PERFILPJ)]
    public class PerfilPjModel : BaseModel
    {
        public Guid IdUsuario { get; set; }
        public string? Descricao { get; set; }
        public float Avaliacao { get; set; }
        public int TempoMedioResposta { get; set; }

        [NotMapped]
        public IEnumerable<DenunciaModel> Denuncias { get; set; }
        [NotMapped]
        public UsuarioModel Usuario { get; set; }
        [NotMapped]
        public IEnumerable<RedeSocialModel> RedesSociais { get; set; }
        [NotMapped]
        public IEnumerable<VagaModel> Vagas { get; set; }
    }
}
