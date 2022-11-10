using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.CONTATOS)]
    public class ContatoModel : BaseModel
    {
        public Guid IdUsuario { get; set; }
        public string? Descricao { get; set; }
        public TipoContato TipoContato { get; set; }

        [NotMapped]
        public UsuarioModel Usuario { get; set; }
    }
}
