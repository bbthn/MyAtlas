using Core.Application.Interfaces.ControllerManager.Request;
using Core.Application.Interfaces.ControllerManager.Response;
using Microsoft.AspNetCore.Mvc;
using Presentation.ConrollerManager.Models;
using Presentation.ConrollerManager.RequestServices;
using Presentation.ConrollerManager.ResponseServices.PageTypeResponseService;

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


        public async Task<IActionResult> CreatePage()
        {
            this._currentRequest = await _currentRequestService.Process(this.HttpContext);
            
            this._currentResponse = await _currentResponseService.Process(_currentRequest);


            throw new NotImplementedException();



        }



        










    }
}
