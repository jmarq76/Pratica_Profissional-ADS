using Infrastructure.BaseClasses;

namespace Infrastructure.Models
{
    public class Idioma : BaseModel
    {
        public Guid IdVaga { get; set; }
        public string? NomeIdioma { get; set; }
        public string? Nivel { get; set; }
    }
}
