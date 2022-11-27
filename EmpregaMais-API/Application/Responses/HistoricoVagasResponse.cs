using Infrastructure.Models;

namespace Application.Responses
{
    public class HistoricoVagasResponse
    {
        public VagaModel Vaga { get; set; }
        public VagaUsuarioModel VagaUsuario { get; set; }
        public UsuarioModel Empresa { get; set; }
    }
}
