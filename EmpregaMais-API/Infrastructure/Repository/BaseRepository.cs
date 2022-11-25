using Infrastructure.BaseClasses;
using Infrastructure.Context;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Repository
{
    public class BaseRepository : IRepository
    {
        private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

        public BaseRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
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
            entity.DataCriacao = DateTime.UtcNow;
            using var context = _contextFactory.CreateDbContext();
            context.Add(entity);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> ListarTodos<TEntity>() where TEntity : BaseModel
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> ListarTodosPorChave<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseModel
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Set<TEntity>().Where(predicate).ToList();
        }

        public TEntity Obter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : BaseModel
        {
            using var context = _contextFactory.CreateDbContext();
            return context.Set<TEntity>().FirstOrDefault(predicate);
        }
    }
}
