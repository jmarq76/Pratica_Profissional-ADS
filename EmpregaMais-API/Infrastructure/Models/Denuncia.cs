using Infrastructure.BaseClasses;
using Infrastructure.Enums;

namespace Infrastructure.Models
{
    public class Denuncia : BaseModel
    {
        public Guid IdVaga { get; set; }
        public Guid IdPerfilPj { get; set; }
        public string? Descricao { get; set; }
        public TipoDenuncia TipoDencuncia { get; set; }
    }
}
