using Escola.Shared.Entities;

namespace Escola.Domain.RepositoryInterfaces
{
    public interface IScholarityRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
    }
}
