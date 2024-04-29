using Core.Application.Dtos.LanguageDtos;
using Core.Application.Dtos.UrlDtos;
using Core.Application.Interfaces.ControllerManager.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Dictionary<string, string> QueryString { get; set; }
        public ReadUrlDto CurrentUrl { get; set; }
        public List<ReadUrlDto> BaseUrls { get; set; }
        public ReadLanguageDto LanguageDto { get; set; }
        public Dictionary<string, object> AddedObjects { get; set; }
    }
}
