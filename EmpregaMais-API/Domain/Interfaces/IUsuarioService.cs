using Infrastructure.Models;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IUsuarioService
    {
        void CadastraUsuario(UsuarioModel usuario);
        UsuarioModel ObtemUsuario(Expression<Func<UsuarioModel, bool>> predicate);
        void DeletaUsuario(Guid id);
    }
}
