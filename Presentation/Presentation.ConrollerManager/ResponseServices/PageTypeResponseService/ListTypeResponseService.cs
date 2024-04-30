

using Core.Application.Dtos.PageDtos;
using Core.Application.Interfaces.ControllerManager.Response;
using MediatR;

namespace Presentation.ConrollerManager.ResponseServices.PageTypeResponseService
{
    public class ListTypeResponseService : BasePageTypeResponseService
    {
        public ListTypeResponseService(IMediator mediator):base(mediator){}


        public async override Task<ICurrentResponse> Process()
        {
            await this.GetPage();
            await base.GetMyController();
            return base.currentResponse;
            
        }

        public async override Task<ReadPageDto> GetPage()
        {

            throw new NotImplementedException();
        }
    }
}
