

using Core.Application.Dtos.PageDtos;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Interfaces.ControllerManager.Response;
using MediatR;

namespace Presentation.ConrollerManager.ResponseServices.PageTypeResponseService
{
    public class ListTypeResponseService : BasePageTypeResponseService
    {
        public ListTypeResponseService(IMediator mediator):base(mediator){}


        public async override Task<ICurrentResponse> Process(ReadUrlDto readUrlDto)
        {
            await base.GetPage(readUrlDto.Id);
            await base.GetMyController();
            return base.currentResponse;
            
        }

        public async override Task<ReadPageDto> GetPage(Guid urlId)
        {

            throw new NotImplementedException();
        }
    }
}
