using Infrastructure.Enums;
using Infrastructure.Models;

namespace Application.Requests
{
    public class CadastroRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string NomeCompleto { get; set; }
        public string DataNascimento { get; set; }
        public string Cpfcnpj { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Uf { get; set; }
        public string Pais { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
