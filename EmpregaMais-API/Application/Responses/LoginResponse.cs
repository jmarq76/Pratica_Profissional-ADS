using Infrastructure.Enums;

namespace Application.Responses
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

    }
}
