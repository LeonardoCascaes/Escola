using Escola.Domain.Entities;
using Escola.Domain.Handlers.ScholarityHandlers;
using Escola.Domain.Handlers.UserHandlers;
using Escola.Domain.RepositoryInterfaces;
using Escola.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Escola.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencies(this IServiceCollection service)
        {
            //Repositories
            service.AddScoped<IUserRepository<User>, UserRepository<User>>();
            service.AddScoped<IScholarityRepository<Scholarity>, ScholarityRepository<Scholarity>>();
            service.AddScoped<ISchoolRecordRepository<SchoolRecord>, SchoolRecordRepository<SchoolRecord>>();
            service.AddScoped<ISchoolEvaluationRepository<SchoolEvaluation>, SchoolEvaluationRepository<SchoolEvaluation>>();

            //Handlers
            service.AddTransient<CreateUserHandler, CreateUserHandler>();
            service.AddTransient<UpdateUserHandler, UpdateUserHandler>();
            service.AddTransient<DeleteUserHandler, DeleteUserHandler>();
            service.AddTransient<CreateScholarityHandler, CreateScholarityHandler>();
            service.AddTransient<UpdateScholarityHandler, UpdateScholarityHandler>();
            service.AddTransient<DeleteScholarityHandler, DeleteScholarityHandler>();

            return service;
        }
    }
}
