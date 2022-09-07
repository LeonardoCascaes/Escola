using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Contexts;
using Escola.Shared.Entities;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Repositories
{
    public class SchoolRecordRepository<T> : GenericRepository<T>, ISchoolRecordRepository<T> where T : BaseEntity
    {
        private readonly SchoolDbContext _context;
        public SchoolRecordRepository(SchoolDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<SchoolRecord?> GetSchoolRecordByUserId(int userId)
        {
            return await _context.SchoolRecords.Where(x => x.UserId == userId).FirstOrDefaultAsync();
        }
    }
}
