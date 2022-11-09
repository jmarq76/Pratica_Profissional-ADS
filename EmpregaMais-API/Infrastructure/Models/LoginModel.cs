using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.LOGINS)]
    public class LoginModel : BaseModel
    {
        public Guid IdUsuario { get; set; }
        public string? NomeUsuario { get; set; }
        public string? Password { get; set; }

        [NotMapped]
        public UsuarioModel Usuario { get; set; }
    }
}
