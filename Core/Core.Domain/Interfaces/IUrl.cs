
namespace Core.Domain.Interfaces
{
    public interface IUrl
    {
        public Guid UrlId { get; set; }
        public string Path { get; set; }
    }
}
