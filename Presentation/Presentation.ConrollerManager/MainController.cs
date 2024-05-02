using Core.Application.Interfaces.ControllerManager.Request;
using Core.Application.Interfaces.ControllerManager.Response;
using Microsoft.AspNetCore.Mvc;
using Presentation.ConrollerManager.Helpers;
using System.Reflection;

namespace Presentation.ConrollerManager
{
    public class MainController : Controller
    {
        private ICurrentRequest _currentRequest;
        private ICurrentResponse _currentResponse;
        private readonly ICurrentRequestService _currentRequestService;
        private readonly ICurrentResponseService _currentResponseService;
        public MainController(ICurrentRequestService currentRequestService,ICurrentResponseService currentResponseService)
        {
            _currentRequestService = currentRequestService;     
            _currentResponseService = currentResponseService;
        }


        public async Task<IActionResult> CreatePageAsync()
        {           
            this._currentRequest = await _currentRequestService.Process(this.HttpContext);            
            this._currentResponse = await _currentResponseService.Process(this._currentRequest);
            this.HttpContext.Items.Add(nameof(this._currentResponse), this._currentResponse);

            if(_currentResponse != null)
            {
                return await this.InvokeActionAsync(_currentResponse.MyController.ControllerName, _currentResponse.Page.ActionName);
                
            }
            throw new ArgumentNullException();
        }
        private async Task<IActionResult> InvokeActionAsync(string controllerName, string actionName)
        {
            if(!string.IsNullOrEmpty(controllerName) && !string.IsNullOrEmpty(actionName))
            {
                AssemblyHelper assemblyHelper = AssemblyHelper.GetAssemblyHelperSingleton;

                Type type = await assemblyHelper.GetType(controllerName);
                if(type != null)
                {
                    Controller controller = (Controller)Activator.CreateInstance(type, assemblyHelper.GetConstructorParameters(type, (IServiceProvider)this.HttpContext));
                    if (controller != null)
                    {
                        MethodInfo action = controller.GetType().GetMethod(actionName);
                        return (IActionResult)action.Invoke(action, assemblyHelper.GetMethodParameters(action,(IServiceProvider)this.HttpContext));
                    }
                    else throw new ArgumentNullException();
                }
                else throw new ArgumentNullException();
            }
            else throw new ArgumentNullException();
        }














    }
}
