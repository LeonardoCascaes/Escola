using Escola.Shared.Entities;

namespace Escola.Domain.RepositoryInterfaces
{
    public interface ISchoolEvaluationRepository<T> : IGenericRepository<T> where T : BaseEntity 
    {
    }
}
