using Core.Application.Dtos.LanguageDtos;
using Core.Application.Dtos.ResultDataDto;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Features.Queries.LanguageQueries.Queries;
using Core.Application.Features.Queries.UrlQueries.Queries;
using Core.Application.Interfaces.ControllerManager.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Presentation.ConrollerManager.Models;

namespace Presentation.ConrollerManager.RequestServices
{
    public class CurrentRequestService : ICurrentRequestService
    {
        private readonly ICurrentRequest _currentRequest;
        private readonly IMediator _mediator;

        public CurrentRequestService(IMediator mediator)
        {
            _currentRequest = new CurrentRequest();
            _mediator = mediator;
        }
        public async Task<ICurrentRequest> Process(HttpContext httpContext)
        {
            this.ParseUrl(httpContext);
            this.SetLanguage();
            this._currentRequest.Urls = await this.GetAllUrls();
            this._currentRequest.CurrentUrl =  await this.GetCurrentUrl();
            this._currentRequest.HttpContextAccessor = httpContext.RequestServices.GetService<IHttpContextAccessor>();


            return this._currentRequest;
        }

        public Task ParseUrl(HttpContext httpContext)
        {
            _currentRequest.Scheme = httpContext.Request.Scheme;
            _currentRequest.Domain = httpContext.Request.Host.Value;
            _currentRequest.Path = httpContext.Request.Path;
            _currentRequest.FullPath = $"{_currentRequest.Scheme}://{_currentRequest.Domain}{_currentRequest.Path}";
            return Task.CompletedTask;
        }

        public Task ParsePath()
        {
            _currentRequest.ParsedPath = _currentRequest.Path.Split('/', options: StringSplitOptions.RemoveEmptyEntries);
            return Task.CompletedTask;
        }

        public async Task SetLanguage()
        {
            IResultDataDto<List<ReadLanguageDto>> result = await _mediator.Send(new GetAllLanguageQuery());
            if (result.IsSuccess)
                _currentRequest.CurrentLanguage = result.Data.FirstOrDefault(w => w.Code == this._currentRequest.ParsedPath[0]);
            else
                throw new Exception("Language can not be found!");
        }

        // https://atlas.com/sehirler/istanbul sehirler => base, /sehirler/istanbul => currentUrl
        public async Task<ReadUrlDto> GetCurrentUrl()
        {
            return _currentRequest.Urls.Last();
                
        }
        // https://atlas.com/sehirler/istanbul/beyoglu sehirler,istanbul => baseUrls, /sehirler/istanbul/beyoglu => currentUrl
        public async Task<List<ReadUrlDto>> GetAllUrls()
        {
            IResultDataDto<List<ReadUrlDto>> result = await _mediator.Send(new GetBaseUrlsQuery() { ParsedUrl = _currentRequest.ParsedPath});
            return result.Data;

        }
        public void SetQueryString(HttpContext httpContext)
        {
            httpContext.Request.Query?.ToList().ForEach(i =>
            {
                this._currentRequest.QueryString.Add(i.Key, i.Value);
            });
        }
    }
}
