using Infrastructure.BaseClasses;
using Infrastructure.Enums;

namespace Infrastructure.Models
{
    public class Vaga : BaseModel
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string? NivelSenioridade { get; set; }
        public string? FaixaSalarial { get; set; }
        public string? Local { get; set; }
        public Beneficios Beneficios { get; set; }
        public string? OutrosRequisitos { get; set; }
    }
}
