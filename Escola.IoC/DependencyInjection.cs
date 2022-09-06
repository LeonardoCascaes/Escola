using Escola.Domain.Entities;
using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Escola.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection service)
        {
            service.AddScoped<IUserRepository<User>, UserRepository<User>>();
            service.AddScoped<IScholarityRepository<Scholarity>, ScholarityRepository<Scholarity>>();
            service.AddScoped<ISchoolRecordRepository<SchoolRecord>, SchoolRecordRepository<SchoolRecord>>();
            service.AddScoped<ISchoolEvaluationRepository<SchoolEvaluation>, SchoolEvaluationRepository<SchoolEvaluation>>();

            return service;
        }
    }
}
