using Domain.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly IRepository _repository;
        public LoginService(IRepository repository)
        {
            _repository = repository;
        }
        public bool CadastrarLogin(LoginModel dadosLogin)
        {
            _repository.Inserir(dadosLogin);
            return true;
        }

        public LoginModel ObterLogin(string userName)
        {
            return _repository.Obter<LoginModel>(l => l.NomeUsuario == userName);
        }

        public LoginModel ObterPorId(Guid id)
        {
            return _repository.Obter<LoginModel>(l => l.IdUsuario == id);
        }

        public void FazerLogout()
        {
            throw new NotImplementedException();
        }
    }
}
