using Core.Application.Interfaces.ControllerManager.Request;
using Core.Application.Interfaces.ControllerManager.Response;
using Presentation.ConrollerManager;
using Presentation.ConrollerManager.RequestServices;
using Presentation.ConrollerManager.ResponseServices;

namespace Presentation.WebUI.Extensions
{
    public static class ServiceRegistration
    {
       public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddScoped<ICurrentRequestService,CurrentRequestService>();
            services.AddScoped<ICurrentResponseService, CurrentResponseService>();


            return services;    


        }
    }
}
