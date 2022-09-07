using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Contexts;
using Escola.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Repositories
{
    public class ScholarityRepository<T> : GenericRepository<T>, IScholarityRepository<T> where T : BaseEntity
    {
        private readonly SchoolDbContext _context;
        public ScholarityRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Scholarity?> GetScholarityByUserId(int userId)
        {
            return await _context.Scholarities.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
