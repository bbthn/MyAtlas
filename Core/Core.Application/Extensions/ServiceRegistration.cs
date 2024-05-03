
using Core.Application.Interfaces.Repositories.LanguageRepository;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Application.Extensions
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection serviceCollection)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            serviceCollection.AddMediatR(assembly);
            serviceCollection.AddAutoMapper(assembly);


            return serviceCollection;
        }
    }
}
