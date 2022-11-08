using Infrastructure.BaseClasses;
using Infrastructure.Enums;

namespace Infrastructure.Models
{
    public class Contato : BaseModel
    {
        public Guid IdUsuario { get; set; }
        public string? Descricao { get; set; }
        public TipoContato TipoContato { get; set; }
    }
}
