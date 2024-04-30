
using Core.Application.Interfaces.ControllerManager.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.Reflection;
using System.Runtime.Remoting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Presentation.ConrollerManager.Helpers
{
    public class AssemblyHelper
    {
        public static Assembly _assembly;
        private static readonly object lockObject = new object();

        public AssemblyHelper()
        {
            _assembly = Assembly.Load("Cora.Application");    
          
        }
        private static AssemblyHelper assemblyHelper;
        public static AssemblyHelper GetAssemblyHelperSingleton
        {
            get
            {
                lock (lockObject)
                {
                    if (assemblyHelper == null) { assemblyHelper = new AssemblyHelper(); return assemblyHelper; }
                    else return assemblyHelper;
                }
               
            }
        }

        public async Task<Type> GetType(string name)
        {
            return _assembly.GetType(name);
        }

        public async Task<object[]> GetConstructorParameters(Type type,IServiceProvider serviceProvider,List<object> customParameters=null)
        {
            List<object> parameters = new List<object>();

            type.GetConstructors().ToList().ForEach(ctor =>
            {
                ctor.GetParameters().ToList().ForEach(param =>
                {
                 object service = serviceProvider.GetService(param.ParameterType);
                    if(service != null)
                    {
                        parameters.Add(service.GetType());
                    }
                    object customParam = customParameters.FirstOrDefault(cp => cp.GetType() == param.ParameterType || cp.GetType().GetInterface(param.ParameterType.Name) != null);
                    if (customParam != null)
                    {
                        parameters.Add(customParam.GetType());
                    }
                    else
                    {
                        parameters.Add(null);
                    }
                });
            });

            return parameters.ToArray();
        }

        public object[] GetMethodParameters(MethodInfo methodInfo, IServiceProvider serviceProvider, List<object> customParams = null)
        {
            List<object> parameters = new List<object>();

            methodInfo.GetParameters().ToList().ForEach(param =>
            {
                object paramater = serviceProvider.GetService(param.ParameterType);
                if (paramater != null)
                {
                    parameters.Add(paramater.GetType());
                }
                else
                {
                    object cParam = customParams.Where(cp => cp.GetType() == param.GetType() || cp.GetType().GetInterface(param.ParameterType.Name) != null);
                    if(cParam != null)
                    {
                        parameters.Add(cParam.GetType());
                    }
                }
            });       
            return parameters.ToArray();
        }

















    }
}
