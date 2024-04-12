using Core.Domain.Entities.Languages;
using Core.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities.Url
{
    public partial class Url : BaseEntity
    {
        public string Title { get; set; }
        public string Path { get; set; }
        public string Slug { get; set; }
        public string? EntityName { get; set; }
        public Guid? DataId { get; set; }

    }
    public partial class Url
    {
        public string LanguageCode { get; set; }
        public string LanguageId { get; set; }
    }
    public partial class Url : ISeo
    {
        public string SeoTitle { get; set; }
    }

    public partial class Url : ILanguage
    {
        Guid ILanguage.LanguageId { get; set; }
    }

    #region Relations
    public partial class Url
    {
        [ForeignKey(nameof(LanguageId))]
        public Language Language { get; set; }
    }
    #endregion
}
