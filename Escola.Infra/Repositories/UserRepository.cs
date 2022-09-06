using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Contexts;
using Escola.Shared.Entities;

namespace Escola.Infra.Repositories
{
    public class UserRepository<T> : GenericRepository<T>, IUserRepository<T> where T : BaseEntity
    {
        public UserRepository(SchoolDbContext context) : base(context)
        {
        }
    }
}
