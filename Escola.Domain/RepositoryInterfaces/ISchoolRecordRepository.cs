using Escola.Domain.Entities;
using Escola.Shared.Entities;

namespace Escola.Domain.RepositoryInterfaces
{
    public interface ISchoolRecordRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        Task<SchoolRecord?> GetSchoolRecordByUserId(int userId);
    }
}
