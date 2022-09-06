using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Escola.Infra.Contexts
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Scholarity> Scholarities => Set<Scholarity>();
        public DbSet<SchoolRecord> SchoolRecords => Set<SchoolRecord>();
        public DbSet<SchoolEvaluation> SchoolEvaluations => Set<SchoolEvaluation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolDbContext).Assembly);
        }
    }
}
