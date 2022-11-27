using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class VagaUsuarioService : IVagaUsuarioService
    {
        private readonly IRepository _repository;
        public VagaUsuarioService(IRepository repository)
        {
            _repository = repository;
        }
        public void CadastraVagaUsuario(VagaUsuarioModel vagaUsuario)
        {
            _repository.Inserir(vagaUsuario);
        }

        public void DeletaVagaUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<VagaUsuarioModel> ListarVagasUsuario(Guid idPerfil)
        {
            return _repository.ListarTodosPorChave<VagaUsuarioModel>(vu => vu.IdPerfilPf == idPerfil);
        }

        public void ObtemVagaUsuario(Guid id)
        {
            throw new NotImplementedException();
        }

        public VagaUsuarioModel VerificaVagaUsuario(Guid idVaga, Guid idPerfil)
        {
            return _repository.Obter<VagaUsuarioModel>(vu => vu.IdVaga == idVaga && vu.IdPerfilPf == idPerfil);
        }
    }
}
