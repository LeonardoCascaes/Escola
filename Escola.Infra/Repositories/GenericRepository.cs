using Escola.Domain.Queries;
using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Contexts;
using Escola.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly SchoolDbContext _context;

        public GenericRepository(SchoolDbContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.AddAsync<T>(entity);
            await _context.SaveChangesAsync();
        }


        public async Task<T?> Get(int id)
        {
            return await _context.Set<T>().AsNoTracking().Where(GenericQueries<T>.GetById(id)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>?> GetAll()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task Update(T entity)
        {
            _context.Update<T>(entity);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(T entity)
        {
            _context.Remove<T>(entity);
            await _context.SaveChangesAsync();
        }
    }
}
