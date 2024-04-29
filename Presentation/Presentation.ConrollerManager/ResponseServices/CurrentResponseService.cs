

using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.PageDtos;
using Core.Application.Enum;
using Core.Application.Interfaces.ControllerManager.Request;
using Core.Application.Interfaces.ControllerManager.Response;
using Microsoft.AspNetCore.Http;
using Presentation.ConrollerManager.ResponseServices.PageTypeResponseService;
using System.Reflection;

namespace Presentation.ConrollerManager.ResponseServices
{
    public class CurrentResponseService : ICurrentResponseService
    {
        private readonly ICurrentResponse _currentResponse;
        public CurrentResponseService(ICurrentResponse currentResponse)
        {
            _currentResponse = currentResponse;
                
        }
        public Task<ICurrentResponse> Process(ICurrentRequest currentRequest)
        {
            if(currentRequest != null)
            {
                string pageType = Enum.GetName(typeof(PageTypeEnum), currentRequest.CurrentUrl.PageType);

                IBasePageTypeResponseService responseService = AssemblyHelper


            }

            

            throw new NotImplementedException();
        }
  
    }
}
