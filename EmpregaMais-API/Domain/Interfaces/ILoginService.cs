using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface ILoginService
    {
        bool CadastrarLogin(LoginModel dadosLogin);
        LoginModel ObterLogin(string userName);
        LoginModel ObterPorId(Guid id);
        void FazerLogout();
    }
}
