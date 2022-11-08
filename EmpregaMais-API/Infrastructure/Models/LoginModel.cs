using Infrastructure.BaseClasses;

namespace Infrastructure.Models
{
    public class LoginModel : BaseModel
    {
        public Guid IdUsuario { get; set; }
        public string? Usuario { get; set; }
        public string? Password { get; set; }
    }
}
