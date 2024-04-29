
using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.PageDtos;
using Core.Application.Interfaces.ControllerManager;
using Core.Application.Interfaces.ControllerManager.Response;

namespace Presentation.ConrollerManager.ResponseServices.PageTypeResponseService
{
    public interface IBasePageTypeResponseService
    {
        public Task<ICurrentResponse> Process();
        public Task<ReadPageDto> GetPage();
        public Task<ReadMyControllerDto> GetMyController();

    }
}
