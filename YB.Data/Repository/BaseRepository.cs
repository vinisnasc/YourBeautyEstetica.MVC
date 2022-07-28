using Microsoft.EntityFrameworkCore;
using YB.Domain.Interfaces.Repository;
using YB.Domain.Models;

namespace YB.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly YBContext _context;

        public BaseRepository(YBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public virtual async Task<T> SelecionarPorId(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public virtual async Task<List<T>> SelecionarTudo()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task Alterar(T entity)
        {
            _context.Set<T>().Update(entity);
            await SaveChanges();
        }

        public virtual async Task Incluir(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
           return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}