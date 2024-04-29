using Core.Application.Dtos.LanguageDtos;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Interfaces.ControllerManager.Request;
using Microsoft.AspNetCore.Http;
using Presentation.ConrollerManager.Models;

namespace Presentation.ConrollerManager.RequestServices
{
    public class CurrentRequestService : ICurrentRequestService
    {
        private readonly ICurrentRequest _currentRequest;

        public CurrentRequestService()
        {
            _currentRequest = new CurrentRequest();

        }
        public async Task<ICurrentRequest> Process(HttpContext httpContext)
        {
            this.ParseUrl(httpContext);
            this.SetLanguage();
            this._currentRequest.CurrentUrl =  await this.GetCurrentUrl();
            this._currentRequest.BaseUrls = await this.GetBaseUrls();
            this._currentRequest.AddedObjects.Add(nameof(httpContext), httpContext);

            return this._currentRequest;
        }

        public void ParseUrl(HttpContext httpContext)
        {
            _currentRequest.Scheme = httpContext.Request.Scheme;
            _currentRequest.Domain = httpContext.Request.Host.Value;
            _currentRequest.Path = httpContext.Request.Path;
            _currentRequest.FullPath = $"{_currentRequest.Scheme}://{_currentRequest.Domain}{_currentRequest.Path}";
        }

        public void ParsePath()
        {
            _currentRequest.ParsedPath = _currentRequest.Path.Split('/', options: StringSplitOptions.RemoveEmptyEntries);
        }

        public Task<ReadLanguageDto> SetLanguage()
        {
            //TODO  -- Dbden çekilecek  parsedPath[0] = tr,en,de

            throw new NotImplementedException();
        }

        public Task<ReadUrlDto> GetCurrentUrl()
        {
            //TODO  -- Dbden çekilecek.  parsedPath[1], 2, 3,4 base/sub1/sub2/sub3 kaç tane varsa
            throw new NotImplementedException();
        }
        public Task<List<ReadUrlDto>> GetBaseUrls()
        {
            //TODO  -- Dbden çekilecek.  parsedPath[1], 2, 3,4 base/sub1/sub2/sub3 kaç tane varsa
            throw new NotImplementedException();
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
