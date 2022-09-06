using Escola.Shared.Entities;

namespace Escola.Domain.RepositoryInterfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
        Task<T?> Get(int id);
        Task<IEnumerable<T>?> GetAll();
        Task Update(T entity);
        Task Delete(int id);
    }
}
