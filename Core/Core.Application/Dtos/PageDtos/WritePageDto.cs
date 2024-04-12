using Core.Application.Interfaces.Dtos;
using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Dtos.PageDtos
{
    public class WritePageDto : BaseDto, IReadDto, ILanguage, ISeo, IUrl
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ActionName { get; set; }
        public Guid LanguageId { get; set; }
        public string SeoTitle { get; set; }
        public Guid UrlId { get; set; }
        public string Path { get; set; }

    }
}
