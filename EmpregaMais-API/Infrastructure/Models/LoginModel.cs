using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.LOGINS)]
    public class LoginModel : BaseModel
    {
        public Guid? IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Password { get; set; }

        [NotMapped]
        [JsonIgnore]
        public UsuarioModel Usuario { get; set; }
    }
}
