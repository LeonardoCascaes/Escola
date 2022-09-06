using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Contexts;
using Escola.Shared.Entities;

namespace Escola.Infra.Repositories
{
    public class SchoolRecordRepository<T> : GenericRepository<T>, ISchoolRecordRepository<T> where T : BaseEntity
    {
        public SchoolRecordRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
