using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.DENUNCIAS)]
    public class DenunciaModel : BaseModel
    {
        public Guid IdVaga { get; set; }
        public Guid IdPerfilPj { get; set; }
        public string? Descricao { get; set; }
        public TipoDenuncia TipoDencuncia { get; set; }

        [NotMapped]
        public VagaModel Vaga { get; set; }
        [NotMapped]
        public PerfilPjModel PerfilPj { get; set; }
    }
}
