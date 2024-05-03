

using AutoMapper.Internal;
using Core.Application.Attributes;
using Core.Application.Interfaces.Repositories;
using Infrastructure.Persistance.Contexts;
using Infrastructure.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Persistance
{
    public static class ServiceRegistration
    {
        private readonly static string ConnectionString = "Data Source=DESKTOP-QSHBLNM\\MSSQLSERVER2022;Initial Catalog=MyAtlas;Integrated Security=true;TrustServerCertificate=true";

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.Load("Core.Application");    
            services.AddDbContext<DataContext>(optionsAction => { optionsAction.UseSqlServer(ConnectionString);},ServiceLifetime.Scoped);
            AddRepositoryServices(assembly,services);

            return services;
        }

        private static void AddRepositoryServices(Assembly assembly,IServiceCollection services)
        {
            IEnumerable<Type> repositories = Assembly.GetExecutingAssembly().GetTypes().Where(r => r.CustomAttributes.Any(a=>a.AttributeType == typeof(RepositoryInterface)));
            foreach (var repo in repositories)
            {
                Type @interface = assembly.GetType(repo.GetCustomAttribute<RepositoryInterface>().Interface);
                if(@interface != null && repo.GetInterface(nameof(@interface)) != null)
                    services.AddScoped(@interface, repo);               
            }
        }
    }
}
