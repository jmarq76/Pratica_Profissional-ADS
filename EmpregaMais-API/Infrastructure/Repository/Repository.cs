using Infrastructure.BaseClasses;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class Repository : IRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public Repository(IDbContextFactory<ApplicationDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public void Atualizar<TEntity>(TEntity entity) where TEntity : BaseModel
        {
            entity.DataAlteracao = DateTime.UtcNow;

            using var context = _contextFactory.CreateDbContext();
            context.Update(entity);
            context.SaveChangesAsync();
        }

        public void Deletar<TEntity>(TEntity entity) where TEntity : BaseModel
        {
            using var context = _contextFactory.CreateDbContext();
            context.Remove(entity);
            context.SaveChangesAsync();
        }

        public void Inserir<TEntity>(TEntity entity) where TEntity : BaseModel
        {
            using var context = _contextFactory.CreateDbContext();
            context.Add(entity);
            context.SaveChangesAsync();
        }

        public IEnumerable<TEntity> ListarTodos<TEntity>() where TEntity : BaseModel
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Set<TEntity>().ToList();
        }

        public TEntity ObterPorId<TEntity>(Guid id) where TEntity : BaseModel
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Set<TEntity>().FirstOrDefault(x => x.Id == id);
        }
    }
}
