using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.ENDERECOS)]
    public class EnderecoModel : BaseModel
    {
        public Guid IdUsuario { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Cep { get; set; }
        public string? Uf { get; set; }
        public string? Pais { get; set; }
        public TipoEndereco TipoEndereco { get; set; }

        [NotMapped]
        public UsuarioModel Usuario { get; set; }
    }
}
