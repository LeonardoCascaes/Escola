using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Contexts;
using Escola.Shared.Entities;

namespace Escola.Infra.Repositories
{
    public class SchoolEvaluationRepository<T> : GenericRepository<T>, ISchoolEvaluationRepository<T> where T : BaseEntity
    {
        public SchoolEvaluationRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
