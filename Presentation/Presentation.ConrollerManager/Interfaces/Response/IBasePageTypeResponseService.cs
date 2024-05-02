
using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.PageDtos;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Interfaces.ControllerManager;
using Core.Application.Interfaces.ControllerManager.Response;

namespace Presentation.ConrollerManager.ResponseServices.PageTypeResponseService
{
    public interface IBasePageTypeResponseService
    {
        public Task<ICurrentResponse> Process(ReadUrlDto currentUrl);
        public Task<ReadPageDto> GetPage(Guid urlId);
        public Task<ReadMyControllerDto> GetMyController();

    }
}
