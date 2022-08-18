using System.Linq.Expressions;
using YB.Domain.Models;

namespace YB.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task Incluir(T entity);
        Task Alterar(T entity);
        Task<T> SelecionarPorId(Guid id);
        Task<List<T>> SelecionarTudo();
        Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
        Task<int> SaveChanges();
    }
}