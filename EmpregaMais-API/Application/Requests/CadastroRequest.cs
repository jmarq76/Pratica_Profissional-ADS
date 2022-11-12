using Infrastructure.Models;

namespace Application.Requests
{
    public class CadastroRequest
    {
        public LoginModel Login { get; set; }
        public UsuarioModel Usuario { get; set; }
        public List<ContatoModel> Contatos { get; set; }
        public List<EnderecoModel> Enderecos { get; set; }
    }
}
