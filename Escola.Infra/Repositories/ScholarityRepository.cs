using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Contexts;
using Escola.Shared.Entities;

namespace Escola.Infra.Repositories
{
    public class ScholarityRepository<T> : GenericRepository<T>, IScholarityRepository<T> where T : BaseEntity
    {
        public ScholarityRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
