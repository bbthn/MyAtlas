
using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.PageDtos;
using Core.Application.Interfaces.ControllerManager.Request;

namespace Core.Application.Interfaces.ControllerManager.Response
{
    public interface ICurrentResponseService
    {
        public Task<ICurrentResponse> Process(ICurrentRequest currentRequest);

    }
}
