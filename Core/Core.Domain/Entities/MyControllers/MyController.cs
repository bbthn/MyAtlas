

using Core.Domain.Entities.Pages;

namespace Core.Domain.Entities.MyControllers
{
    public partial class MyController : BaseEntity
    {
        public string Title { get; set; }
        public string ViewLayout { get; set; }
        public string ControllerName { get; set; }
    }
    #region Relations
    public partial class MyController
    {
        public ICollection<Page> Pages { get; set; }

    }
    #endregion
}
