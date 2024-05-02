using Core.Application.Dtos.LanguageDtos;
using Core.Application.Dtos.UrlDtos;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace Core.Application.Interfaces.ControllerManager.Request
{
    public interface ICurrentRequestService
    {
        public Task<ICurrentRequest> Process(HttpContext httpContext);
        public Task ParseUrl(HttpContext httpContext);
        public Task ParsePath();
        public Task SetLanguage();
        public Task<ReadUrlDto> GetCurrentUrl();
        public Task<List<ReadUrlDto>> GetAllUrls();
        public void SetQueryString(HttpContext httpContext);

    }
}
