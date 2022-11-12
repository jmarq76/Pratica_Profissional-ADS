using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface ILoginService
    {
        bool CadastrarLogin(LoginModel dadosLogin);
        bool FazerLogin(string userName, string password);
        void FazerLogout();
    }
}
