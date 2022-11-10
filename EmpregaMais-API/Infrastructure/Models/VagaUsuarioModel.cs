using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.VAGASUSUARIOS)]
    public class VagaUsuarioModel : BaseModel
    {
        public Guid IdVaga { get; set; }
        public Guid IdPerfilPf { get; set; }
        public Guid IdPerfilPj { get; set; }
        public DateTime DataEnvioPerfilPf { get; set; }
        public DateTime DataRespostaPerfilPj { get; set; }

        [NotMapped]
        public VagaModel Vaga { get; set; }
        [NotMapped]
        public PerfilPfModel PerfilPf { get; set; }
        [NotMapped]
        public PerfilPjModel PerfilPj { get; set; }
    }
}
