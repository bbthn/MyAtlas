

using Core.Application.Enum;
using Core.Application.Exceptions;
using Core.Application.Interfaces.ControllerManager.Request;
using Core.Application.Interfaces.ControllerManager.Response;
using Microsoft.AspNetCore.Http;
using Presentation.ConrollerManager.Helpers;
using Presentation.ConrollerManager.ResponseServices.PageTypeResponseService;
using System.Reflection;

namespace Presentation.ConrollerManager.ResponseServices
{
    public class CurrentResponseService : ICurrentResponseService
    {
        private  ICurrentResponse _currentResponse;
        public async Task<ICurrentResponse> Process(ICurrentRequest currentRequest)
        {
            if(currentRequest != null)
            {
                string pageType = Enum.GetName(typeof(PageTypeEnum), currentRequest.CurrentUrl.PageType);
                string typeName = pageType + "TypeResponseService";
                AssemblyHelper assemblyHelper = AssemblyHelper.GetAssemblyHelperSingleton;

                Type type = await assemblyHelper.GetType(typeName);
                if(type != null)
                {
                    IBasePageTypeResponseService responseService = (IBasePageTypeResponseService)Activator.CreateInstance(type, assemblyHelper.GetConstructorParameters(type,currentRequest.HttpContextAccessor.HttpContext.RequestServices));
                    if(responseService != null)
                    {
                        this._currentResponse = await responseService.Process(currentRequest.CurrentUrl);
                        return this._currentResponse;
                    }
                    else
                        throw new ControllerManagerException("MainController", "ResponseService is null!");
                }
                else
                    throw new ControllerManagerException("MainController","Type is null!");                             
            }
            else
                throw new ControllerManagerException("MainController", "CurrentRequest is null!");
        }
  
    }
}
