
using Core.Application.Dtos.PageDtos;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Interfaces.ControllerManager.Response;
using MediatR;

namespace Presentation.ConrollerManager.ResponseServices.PageTypeResponseService
{
    public class DetailTypeResponseService : BasePageTypeResponseService
    {
        public DetailTypeResponseService(IMediator mediator) : base(mediator)
        {
        }
        public async override Task<ICurrentResponse> Process(ReadUrlDto currentUrl)
        {
            await base.GetMyController();
            await base.GetPage(currentUrl.Id);
            return base.currentResponse;         
        }

        public override Task<ReadPageDto> GetPage(Guid urlId)
        {
            // detail a özel page
            throw new NotImplementedException();
        }
    }
}
