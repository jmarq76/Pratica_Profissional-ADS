using Infrastructure.BaseClasses;

namespace Infrastructure.Models
{
    public class PerfilPj : BaseModel
    {
        public Guid IdUsuario { get; set; }
        public string? Descricao { get; set; }
        public float Avaliacao { get; set; }
        public int TempoMedioResposta { get; set; }
    }
}
