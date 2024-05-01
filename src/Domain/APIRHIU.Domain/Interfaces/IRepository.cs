using APIRHIU.Core.DomainObjects;
using System.Linq.Expressions;

namespace APIRHIU.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        void Adicionar(TEntity entity);
        Task<TEntity> ObterPorId(Guid id);
        Task<List<TEntity>> ObterTodos();
        void Atualizar(TEntity entity);
        void Remover(Guid id);
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);
        Task<int> SaveChanges();
    }
}
