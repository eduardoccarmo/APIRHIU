using APIRHIU.Core.DomainObjects;
using APIRHIU.Data.Context;
using APIRHIU.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace APIRHIU.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected ApirhiuContext Db;
        protected DbSet<TEntity> DbSet;

        public Repository(ApirhiuContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual void Adicionar(TEntity entity)
        {
            Db.DesativarDeteccaoAutomaticaDeMudancas();

            DbSet.Add(entity);
        }

        public void Atualizar(TEntity entity)
        {
            Db.AtivarDeteccaoAutomaticaDeMudancas();

            DbSet.Update(entity);
        }

        public async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public void Remover(Guid id)
        {
            DbSet.Remove(new TEntity { Id = id });
        }

        public async Task<int> SaveChanges()
        {
            DbSet.AsNoTracking();
            return await Db.SaveChangesAsync();
        }
    }
}
