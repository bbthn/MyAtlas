

using Core.Application.Dtos.MyControllerDtos;
using Core.Application.Dtos.PageDtos;
using Core.Application.Interfaces.ControllerManager.Response;
using MediatR;

namespace Presentation.ConrollerManager.ResponseServices.PageTypeResponseService
{
    public abstract class BasePageTypeResponseService : IBasePageTypeResponseService
    {
        private readonly IMediator _mediator;
        protected ICurrentResponse currentResponse;
        public BasePageTypeResponseService(IMediator mediator)
        {
            _mediator = mediator;

        }
        public virtual async Task<ICurrentResponse> Process()
        {
            this.currentResponse.MyController =await this.GetMyController();
            this.currentResponse.Page = await this.GetPage();
            throw new NotImplementedException();
        }

        public virtual async Task<ReadMyControllerDto> GetMyController()
        {
            // todo getmyController metodu
            throw new NotImplementedException();
            
        }
        public virtual async Task<ReadPageDto> GetPage()
        {
            // todo getPage Metodu
            throw new NotImplementedException();
        }
   
    }
}
