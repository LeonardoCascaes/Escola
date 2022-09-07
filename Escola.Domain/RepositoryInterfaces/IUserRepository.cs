using Escola.Shared.Entities;

namespace Escola.Domain.RepositoryInterfaces
{
    public interface IUserRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
    }
}
