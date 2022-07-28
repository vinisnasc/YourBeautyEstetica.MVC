using YB.Domain.Models;

namespace YB.Domain.Interfaces.Repository
{
    public interface IBaseRepository<T> : IDisposable where T : BaseEntity
    {
        Task Incluir(T entity);
        Task Alterar(T entity);
        Task<T> SelecionarPorId(Guid id);
        Task<List<T>> SelecionarTudo();
        Task<int> SaveChanges();
    }
}