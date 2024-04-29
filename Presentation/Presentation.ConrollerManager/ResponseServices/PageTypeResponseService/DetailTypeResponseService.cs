
using Core.Application.Dtos.PageDtos;
using Core.Application.Interfaces.ControllerManager.Response;
using MediatR;

namespace Presentation.ConrollerManager.ResponseServices.PageTypeResponseService
{
    public class DetailTypeResponseService : BasePageTypeResponseService
    {
        public DetailTypeResponseService(IMediator mediator) : base(mediator)
        {
        }
        public async override Task<ICurrentResponse> Process()
        {
            await base.GetMyController();
            await this.GetPage();
            return base.currentResponse;         
        }

        public override Task<ReadPageDto> GetPage()
        {
            // detail a özel page
            throw new NotImplementedException();
        }
    }
}
