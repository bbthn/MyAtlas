using Core.Application.Dtos.LanguageDtos;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Interfaces.ControllerManager.Request;
using Microsoft.AspNetCore.Http;


namespace Presentation.ConrollerManager.Models
{
    public class CurrentRequest : ICurrentRequest
    {
        public string Scheme { get; set; }
        public string Domain { get; set; }
        public string Path { get; set; }
        public string Slug { get; set; }
        public string FullPath { get; set; }
        public string[] ParsedPath { get; set; }
        public List<ReadUrlDto> Urls { get; set; }
        public ReadLanguageDto CurrentLanguage { get; set; }
        public Dictionary<string, string> QueryString { get; set; }
        public ReadUrlDto CurrentUrl { get; set; }
        public Dictionary<string, object> AddedObjects { get; set; }
        public IHttpContextAccessor HttpContextAccessor { get; set; }
     
    }
}
