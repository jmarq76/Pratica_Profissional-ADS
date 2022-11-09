using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.VAGAS)]
    public class VagaModel : BaseModel
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string? NivelSenioridade { get; set; }
        public string? FaixaSalarial { get; set; }
        public string? Local { get; set; }
        public Beneficios Beneficios { get; set; }
        public string? OutrosRequisitos { get; set; }

        [NotMapped]
        public List<DenunciaModel> Denuncias { get; set; }
        [NotMapped]
        public List<IdiomaModel> Idiomas { get; set; }
        [NotMapped]
        public List<VagaUsuarioModel> VagasUsuarios { get; set; }
    }
}
