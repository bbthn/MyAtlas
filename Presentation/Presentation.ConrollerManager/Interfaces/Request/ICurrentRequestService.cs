using Core.Application.Dtos.LanguageDtos;
using Core.Application.Dtos.UrlDtos;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Core.Application.Interfaces.ControllerManager.Request
{
    public interface ICurrentRequestService
    {
        public Task<ICurrentRequest> Process(HttpContext httpContext);
        public void ParseUrl(HttpContext httpContext);
        public void ParsePath();
        public Task<ReadLanguageDto> SetLanguage();
        public Task<ReadUrlDto> GetCurrentUrl();
        public Task<List<ReadUrlDto>> GetBaseUrls();
        public void SetQueryString(HttpContext httpContext);

    }
}
