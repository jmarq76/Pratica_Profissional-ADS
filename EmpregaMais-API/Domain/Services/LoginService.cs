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

        public bool FazerLogin(string userName, string password)
        {
            try
            {
                //var userNameEncrypt = CryptoEngine.EncryptPlainTextToCypher(userName, password);
                //var passwordEncrypt = CryptoEngine.EncryptPlainTextToCypher(password, userName);

                //var loginDb = _repository.Obter<LoginModel>(l => l.NomeUsuario == userNameEncrypt);

                //if(loginDb != null && loginDb.Password.Equals(passwordEncrypt))
                //{
                //    Console.WriteLine("Login efetuado com sucesso");
                //    return true;
                //}
                //else
                //{
                //    Console.WriteLine("Username/Senha errados");
                //    return false;
                //}
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void FazerLogout()
        {
            throw new NotImplementedException();
        }
    }
}
