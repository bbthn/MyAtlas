

using Core.Domain.Entities.Languages;
using Core.Domain.Entities.MyControllers;
using Core.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.Entities.Pages
{
    public partial class Page : BaseEntity
    {
        public string Title { get; set; }
        public string Slug { get; set; }
        public string ActionName { get; set; }
    }
    public partial class Page : ILanguage
    {
        public Guid LanguageId { get; set; }
    }
    public partial class Page : ISeo
    {
        public string SeoTitle { get; set; }
    }
    public partial class Page : IUrl
    {
        public Guid UrlId { get; set; }
        public string Path { get; set; }

    }

    #region Relations
    public partial class Page
    {
        public MyController MyController { get; set; }
       
    }
    #endregion
}
