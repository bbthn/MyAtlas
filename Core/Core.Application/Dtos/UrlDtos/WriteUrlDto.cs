
using Core.Application.Interfaces.Dtos;
using Core.Domain.Interfaces;

namespace Core.Application.Dtos.UrlDtos
{
    public class WriteUrlDto : BaseDto,IWriteDto, IUrl, ILanguage, ISeo
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public string Slug { get; set; }
        public string? EntityName { get; set; }
        public Guid? DataId { get; set; }
        public string LanguageCode { get; set; }
        public Guid LanguageId { get; set; }
        public string SeoTitle { get; set; }
        public Guid UrlId { get; set; }

    }
}
