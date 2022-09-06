using Escola.Shared.Entities;

namespace Escola.Domain.RepositoryInterfaces
{
    public interface ISchoolRecordRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
    }
}
