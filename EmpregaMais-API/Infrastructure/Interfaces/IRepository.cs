using Infrastructure.BaseClasses;

namespace Infrastructure.Interfaces
{
    public interface IRepository
    {
        void Inserir<TEntity>(TEntity entity) where TEntity : BaseModel;
        IEnumerable<TEntity> ListarTodos<TEntity>() where TEntity : BaseModel;
        TEntity ObterPorId<TEntity>(Guid id) where TEntity : BaseModel;
        void Atualizar<TEntity>(TEntity entity) where TEntity : BaseModel;
        void Deletar<TEntity>(TEntity entity) where TEntity : BaseModel;
    }
}
