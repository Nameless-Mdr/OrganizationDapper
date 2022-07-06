using Connection.Base;
using Connection.Implement;
using Contracts;
using Contracts.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Service.Implement;
using Service.Interfaces;
using Vacancy.Repository;

namespace Vacancy
{
    public class VacancyModule : IModule
    {
        public void Registry(IServiceCollection services)
        {
            services.AddTransient<IPersonRepository, PersonRepository>();

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            services.AddTransient<IProjectRepository, ProjectRepository>();

            services.AddTransient<IPersonProjectRepository, PersonProjectRepository>();

            services.AddTransient<IPersonService, PersonService>();

            services.AddTransient<IDepartmentService, DepartmentService>();

            services.AddTransient<IProjectService, ProjectService>();

            services.AddTransient<IPersonProjectService, PersonProjectService>();

            services.AddTransient<IDbConnectionFactory, DbConnectionFactory>();
        }
    }
}
