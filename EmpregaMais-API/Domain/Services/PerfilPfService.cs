using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class PerfilPfService : IPerfilPfService
    {
        private readonly IRepository _repository;

        public PerfilPfService(IRepository repository)
        {
            _repository = repository;
        }

        public void AtualizaPerfilPf(PerfilPfModel perfilPf)
        {
            perfilPf.Id = _repository.Obter<PerfilPfModel>(pf => pf.IdUsuario == perfilPf.IdUsuario).Id;
            _repository.Atualizar(perfilPf);
        }

        public void CadastraPerfilPf(PerfilPfModel perfilPf)
        {
            _repository.Inserir(perfilPf);
        }

        public void DeletaPerfilPf(Guid id)
        {
            throw new NotImplementedException();
        }

        public PerfilPfModel ObtemPerfilPf(Guid idUsuario)
        {
            var perfil = _repository.Obter<PerfilPfModel>(pf => pf.IdUsuario == idUsuario);
            return perfil;
        }
    }
}
