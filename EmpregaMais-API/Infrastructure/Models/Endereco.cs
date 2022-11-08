using Infrastructure.BaseClasses;
using Infrastructure.Enums;

namespace Infrastructure.Models
{
    public class Endereco : BaseModel
    {
        public Guid IdUsuario { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Cep { get; set; }
        public string? Uf { get; set; }
        public string? Pais { get; set; }
        public TipoEndereco TipoEndereco { get; set; }
    }
}
