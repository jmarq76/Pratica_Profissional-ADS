using Infrastructure.BaseClasses;
using System.Linq.Expressions;

namespace Infrastructure.Interfaces
{
    public interface IRepository
    {
        void Inserir<TEntity>(TEntity entity) where TEntity : BaseModel;
        IEnumerable<TEntity> ListarTodos<TEntity>() where TEntity : BaseModel;
        TEntity Obter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseModel;
        void Atualizar<TEntity>(TEntity entity) where TEntity : BaseModel;
        void Deletar<TEntity>(TEntity entity) where TEntity : BaseModel;
    }
}
