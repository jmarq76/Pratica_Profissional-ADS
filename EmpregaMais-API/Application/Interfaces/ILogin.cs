using Application.Responses;
using Infrastructure.Models;

namespace Application.Interfaces
{
    public interface ILogin
    {
        LoginResponse RealizarLogin(string dadosLogin);
        LoginModel GetById(Guid id);
    }
}
