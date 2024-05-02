

using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.PageDtos;
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Features.Queries.MyControllerQueries.Queries;
using Core.Application.Features.Queries.PageQueries.Queries;
using Core.Application.Interfaces.ControllerManager.Response;
using MediatR;
using Presentation.ConrollerManager.Models;

namespace Presentation.ConrollerManager.ResponseServices.PageTypeResponseService
{
    public abstract class BasePageTypeResponseService : IBasePageTypeResponseService 
    {
        private readonly IMediator _mediator;
        protected readonly ICurrentResponse currentResponse;
        public BasePageTypeResponseService(IMediator mediator)
        {
            _mediator = mediator;
            currentResponse = new CurrentResponse();
        }
        public virtual async Task<ICurrentResponse> Process(ReadUrlDto currentUrl)
        {
            this.currentResponse.Page = await this.GetPage(currentUrl.Id);
            this.currentResponse.MyController =await this.GetMyController();
            return this.currentResponse;
        }

        public virtual async Task<ReadMyControllerDto> GetMyController()
        {
            IResultDataDto<ReadMyControllerDto> result = await _mediator.Send(new GetMyControllerByIdQuery() { MyControllerId = this.currentResponse.Page.MyControllerId });
            if (result.IsSuccess)
                return result.Data;
            else
                throw new Exception("MyController can not be found!");
          
            
        }
        public virtual async Task<ReadPageDto> GetPage(Guid urlId)
        {
            IResultDataDto<ReadPageDto> result = await _mediator.Send(new GetPageByUrlIdQuery() { UrlId = urlId });
            if (result.IsSuccess)
                return result.Data;
            else
                throw new Exception("Page can not be found!");

            
        }
   
    }
}
