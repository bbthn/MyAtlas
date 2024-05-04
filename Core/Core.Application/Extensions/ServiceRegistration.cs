
using Core.Application.Interfaces.RedisService;
using Core.Application.Interfaces.Repositories.LanguageRepository;
using Core.Application.Services.RedisService;
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

        public static IServiceCollection AddRedisServices(this IServiceCollection services,Action<RedisSettings> action)
        {
            services.AddSingleton<IRedisService,RedisService>();
            services.Configure<RedisSettings>(action);

            return services;

        }
    }

}
